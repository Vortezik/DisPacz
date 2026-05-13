import React, { useCallback, useState } from 'react';
import {
  Alert,
  Modal,
  Pressable,
  ScrollView,
  StyleSheet,
  Text,
  TouchableOpacity,
  View,
} from 'react-native';
import { useFocusEffect } from '@react-navigation/native';
import type { NativeStackNavigationProp } from '@react-navigation/native-stack';
import type { RouteProp } from '@react-navigation/native';
import { SafeAreaView } from 'react-native-safe-area-context';
import {
  assignEquipmentToJob,
  fetchDispatch,
  fetchEquipments,
  fetchJob,
  updateJob,
} from '../../api/disPaczApi';
import { ApiError } from '../../api/httpClient';
import { ErrorBlock, ListRowCard, LoadingBlock } from '../../components/ListRowCard';
import { StatusChip } from '../../components/StatusChip';
import { JOB_STATUS } from '../../constants/jobStatus';
import type { DispatchStackParamList } from '../../navigation/types';
import { colors, radius, spacing, typography } from '../../theme/theme';
import type { DispatchDto, EquipmentDto, JobDto } from '../../types/models';

type Nav = NativeStackNavigationProp<DispatchStackParamList, 'DispatchDetail'>;
type R = RouteProp<DispatchStackParamList, 'DispatchDetail'>;

type Props = { navigation: Nav; route: R };

const formatWhen = (iso: string) => {
  try {
    return new Date(iso).toLocaleString(undefined, {
      weekday: 'short',
      month: 'short',
      day: 'numeric',
      hour: '2-digit',
      minute: '2-digit',
    });
  } catch {
    return iso;
  }
};

const DispatchDetailScreen: React.FC<Props> = ({ navigation, route }) => {
  const { dispatchId } = route.params;
  const [dispatch, setDispatch] = useState<DispatchDto | null>(null);
  const [job, setJob] = useState<JobDto | null>(null);
  const [catalog, setCatalog] = useState<EquipmentDto[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const [equipOpen, setEquipOpen] = useState(false);
  const [addingId, setAddingId] = useState<number | null>(null);
  const [finishing, setFinishing] = useState(false);

  const load = useCallback(async () => {
    setError(null);
    try {
      const d = await fetchDispatch(dispatchId);
      const [j, eq] = await Promise.all([fetchJob(d.jobId), fetchEquipments()]);
      setDispatch(d);
      setJob(j);
      setCatalog(eq);
    } catch (e) {
      const msg =
        e instanceof ApiError
          ? `${e.message} (${e.status})`
          : e instanceof Error
            ? e.message
            : 'Unknown error';
      setError(msg);
    } finally {
      setLoading(false);
    }
  }, [dispatchId]);

  useFocusEffect(
    useCallback(() => {
      setLoading(true);
      load();
    }, [load]),
  );

  const assigned = job?.assignedEquipment ?? [];
  const assignedIds = new Set(assigned.map(a => a.id));
  const available = catalog.filter(e => !assignedIds.has(e.id));
  const isCompleted = job?.status === JOB_STATUS.COMPLETED;

  const onAddEquipment = async (equipmentId: number) => {
    if (!job) {
      return;
    }
    setAddingId(equipmentId);
    try {
      await assignEquipmentToJob(job.id, equipmentId);
      setEquipOpen(false);
      await load();
    } catch (e) {
      const msg =
        e instanceof ApiError
          ? `${e.message} (${e.status})`
          : e instanceof Error
            ? e.message
            : 'Unknown error';
      Alert.alert('Could not add equipment', msg);
    } finally {
      setAddingId(null);
    }
  };

  const onFinishJob = () => {
    if (!job) {
      return;
    }
    Alert.alert(
      'Finish work order',
      'Mark this job as completed? You can still view it from the Jobs tab.',
      [
        { text: 'Cancel', style: 'cancel' },
        {
          text: 'Complete',
          style: 'default',
          onPress: async () => {
            setFinishing(true);
            try {
              await updateJob(job.id, {
                title: job.title,
                description: job.description ?? '',
                status: JOB_STATUS.COMPLETED,
                scheduledDate: job.scheduledDate,
                clientId: job.clientId,
                locationId: job.locationId,
              });
              navigation.goBack();
            } catch (e) {
              const msg =
                e instanceof ApiError
                  ? `${e.message} (${e.status})`
                  : e instanceof Error
                    ? e.message
                    : 'Unknown error';
              Alert.alert('Update failed', msg);
            } finally {
              setFinishing(false);
            }
          },
        },
      ],
    );
  };

  if (loading) {
    return (
      <SafeAreaView style={styles.safe} edges={['top']}>
        <LoadingBlock />
      </SafeAreaView>
    );
  }

  if (error || !dispatch || !job) {
    return (
      <SafeAreaView style={styles.safe} edges={['top']}>
        <ErrorBlock message={error ?? 'Not found'} onRetry={load} />
      </SafeAreaView>
    );
  }

  return (
    <SafeAreaView style={styles.safe} edges={['top']}>
      <ScrollView contentContainerStyle={styles.content}>
        <TouchableOpacity onPress={() => navigation.goBack()} style={styles.back}>
          <Text style={styles.backText}>‹ Dispatch board</Text>
        </TouchableOpacity>

        <Text style={styles.kicker}>Dispatch #{dispatch.id}</Text>
        <Text style={styles.headline}>{dispatch.jobTitle}</Text>
        <Text style={styles.meta}>Assigned {formatWhen(dispatch.assignedAt)}</Text>

        <View style={styles.row}>
          <Text style={styles.labelInline}>Technician</Text>
          <Text style={styles.valueStrong}>{dispatch.workerName}</Text>
        </View>

        <Text style={styles.section}>Work order</Text>
        <View style={styles.card}>
          <View style={styles.statusRow}>
            <Text style={styles.cardTitle}>{job.title}</Text>
            <StatusChip status={job.status} />
          </View>
          <Text style={styles.cardMuted}>{job.clientName}</Text>
          <Text style={styles.cardMuted}>{job.locationAddress}</Text>
          <Text style={styles.cardBody}>{job.description || '—'}</Text>
        </View>

        <Text style={styles.section}>Equipment on this job</Text>
        {assigned.length === 0 ? (
          <Text style={styles.hint}>No equipment linked yet.</Text>
        ) : (
          assigned.map(eq => (
            <View key={eq.id} style={styles.equipRow}>
              <Text style={styles.equipName}>{eq.name}</Text>
              <Text style={styles.equipSn}>{eq.serialNumber || '—'}</Text>
            </View>
          ))
        )}

        {!isCompleted ? (
          <TouchableOpacity style={styles.secondaryBtn} onPress={() => setEquipOpen(true)}>
            <Text style={styles.secondaryBtnText}>Add equipment</Text>
          </TouchableOpacity>
        ) : null}

        {!isCompleted ? (
          <TouchableOpacity
            style={[styles.primaryBtn, finishing && styles.primaryBtnDisabled]}
            onPress={onFinishJob}
            disabled={finishing}>
            <Text style={styles.primaryBtnText}>
              {finishing ? 'Saving…' : 'Finish job (mark completed)'}
            </Text>
          </TouchableOpacity>
        ) : (
          <Text style={styles.doneNote}>This work order is completed.</Text>
        )}
      </ScrollView>

      <Modal visible={equipOpen} animationType="slide" transparent>
        <Pressable style={styles.modalOverlay} onPress={() => setEquipOpen(false)}>
          <Pressable style={styles.sheet} onPress={e => e.stopPropagation()}>
            <Text style={styles.sheetTitle}>Add equipment</Text>
            {available.length === 0 ? (
              <Text style={styles.hint}>All catalog items are already on this job.</Text>
            ) : (
              <ScrollView style={styles.sheetList}>
                {available.map(eq => (
                  <ListRowCard
                    key={eq.id}
                    title={eq.name}
                    subtitle={eq.serialNumber ? `S/N ${eq.serialNumber}` : undefined}
                    onPress={() => onAddEquipment(eq.id)}
                    right={
                      addingId === eq.id ? (
                        <Text style={styles.pick}>…</Text>
                      ) : (
                        <Text style={styles.pick}>Add</Text>
                      )
                    }
                  />
                ))}
              </ScrollView>
            )}
            <TouchableOpacity style={styles.cancelBtn} onPress={() => setEquipOpen(false)}>
              <Text style={styles.cancelText}>Close</Text>
            </TouchableOpacity>
          </Pressable>
        </Pressable>
      </Modal>
    </SafeAreaView>
  );
};

const styles = StyleSheet.create({
  safe: { flex: 1, backgroundColor: colors.background },
  content: { padding: spacing.lg, paddingBottom: spacing.xl * 2 },
  back: { marginBottom: spacing.md },
  backText: { ...typography.subtitle, color: colors.accent },
  kicker: { ...typography.overline, color: colors.textMuted },
  headline: { ...typography.title, color: colors.textPrimary, marginTop: spacing.xs },
  meta: { ...typography.caption, color: colors.accent, marginTop: spacing.sm, marginBottom: spacing.md },
  row: { marginBottom: spacing.lg },
  labelInline: { ...typography.caption, color: colors.textMuted },
  valueStrong: { ...typography.subtitle, color: colors.textPrimary, marginTop: 4 },
  section: {
    ...typography.overline,
    color: colors.textMuted,
    marginTop: spacing.md,
    marginBottom: spacing.sm,
  },
  card: {
    backgroundColor: colors.surfaceElevated,
    borderRadius: radius.md,
    borderWidth: 1,
    borderColor: colors.border,
    padding: spacing.md,
  },
  statusRow: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'flex-start',
    gap: spacing.sm,
    marginBottom: spacing.sm,
  },
  cardTitle: { flex: 1, ...typography.subtitle, color: colors.textPrimary },
  cardMuted: { ...typography.caption, color: colors.textSecondary, marginBottom: 4 },
  cardBody: { ...typography.body, color: colors.textSecondary, marginTop: spacing.sm, lineHeight: 22 },
  hint: { ...typography.body, color: colors.textMuted, marginBottom: spacing.md },
  equipRow: {
    paddingVertical: spacing.sm,
    borderBottomWidth: 1,
    borderBottomColor: colors.border,
  },
  equipName: { ...typography.subtitle, color: colors.textPrimary },
  equipSn: { ...typography.caption, color: colors.textSecondary, marginTop: 2 },
  secondaryBtn: {
    marginTop: spacing.lg,
    borderWidth: 1,
    borderColor: colors.accent,
    borderRadius: radius.md,
    paddingVertical: spacing.md,
    alignItems: 'center',
  },
  secondaryBtnText: { ...typography.subtitle, color: colors.accent },
  primaryBtn: {
    marginTop: spacing.md,
    backgroundColor: colors.accent,
    borderRadius: radius.md,
    paddingVertical: spacing.md,
    alignItems: 'center',
  },
  primaryBtnDisabled: { opacity: 0.6 },
  primaryBtnText: { ...typography.subtitle, color: colors.background },
  doneNote: {
    ...typography.body,
    color: colors.success,
    marginTop: spacing.lg,
    textAlign: 'center',
  },
  modalOverlay: {
    flex: 1,
    backgroundColor: colors.overlay,
    justifyContent: 'flex-end',
  },
  sheet: {
    backgroundColor: colors.surface,
    borderTopLeftRadius: radius.lg,
    borderTopRightRadius: radius.lg,
    padding: spacing.lg,
    maxHeight: '70%',
    borderWidth: 1,
    borderColor: colors.border,
  },
  sheetTitle: { ...typography.subtitle, color: colors.textPrimary, marginBottom: spacing.md },
  sheetList: { marginBottom: spacing.md },
  pick: { ...typography.caption, color: colors.accent },
  cancelBtn: { padding: spacing.md, alignItems: 'center' },
  cancelText: { ...typography.subtitle, color: colors.textSecondary },
});

export default DispatchDetailScreen;
