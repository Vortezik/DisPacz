import React, { useCallback, useState } from 'react';
import { Alert, Modal, Pressable, ScrollView, StyleSheet, Text, TouchableOpacity, View, } from 'react-native';
import { useFocusEffect } from '@react-navigation/native';
import type { NativeStackNavigationProp } from '@react-navigation/native-stack';
import type { RouteProp } from '@react-navigation/native';
import { SafeAreaView } from 'react-native-safe-area-context';
import { assignWorkerToJob, fetchJob, fetchWorkers, } from '../../api/disPaczApi';
import { ApiError } from '../../api/httpClient';
import { ErrorBlock, ListRowCard, LoadingBlock } from '../../components/ListRowCard';
import { StatusChip } from '../../components/StatusChip';
import { JOB_STATUS } from '../../constants/jobStatus';
import type { JobsStackParamList } from '../../navigation/types';
import { colors, radius, spacing, typography } from '../../theme/theme';
import type { JobDto, WorkerDto } from '../../types/models';

type Nav = NativeStackNavigationProp<JobsStackParamList, 'JobDetail'>;
type Route = RouteProp<JobsStackParamList, 'JobDetail'>;

type Props = { navigation: Nav; route: Route };

const formatWhen = (iso: string) => {
  try {
    return new Date(iso).toLocaleString(undefined, {
      weekday: 'long',
      month: 'short',
      day: 'numeric',
      hour: '2-digit',
      minute: '2-digit',
    });
  } catch {
    return iso;
  }
};

const JobDetailScreen: React.FC<Props> = ({ navigation, route }) => {
  const { id } = route.params;
  const [job, setJob] = useState<JobDto | null>(null);
  const [workers, setWorkers] = useState<WorkerDto[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const [assignOpen, setAssignOpen] = useState(false);
  const [assigning, setAssigning] = useState<number | null>(null);

  const load = useCallback(async () => {
    setError(null);
    try {
      const [j, w] = await Promise.all([fetchJob(id), fetchWorkers()]);
      setJob(j);
      setWorkers(w);
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
  }, [id]);

  useFocusEffect(
    useCallback(() => {
      setLoading(true);
      load();
    }, [load]),
  );

  const onAssign = async (workerId: number) => {
    setAssigning(workerId);
    try {
      await assignWorkerToJob(id, workerId);
      setAssignOpen(false);
      Alert.alert('Assigned', 'Technician is on the job. Status is now In Progress.');
      load();
    } catch (e) {
      const msg =
        e instanceof ApiError
          ? `${e.message} (${e.status})`
          : e instanceof Error
            ? e.message
            : 'Unknown error';
      Alert.alert('Assignment failed', msg);
    } finally {
      setAssigning(null);
    }
  };

  if (loading) {
    return (
      <SafeAreaView style={styles.safe} edges={['top']}>
        <LoadingBlock />
      </SafeAreaView>
    );
  }

  if (error || !job) {
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
          <Text style={styles.backText}>‹ Back</Text>
        </TouchableOpacity>

        <View style={styles.hero}>
          <Text style={styles.kicker}>Work order #{job.id}</Text>
          <Text style={styles.headline}>{job.title}</Text>
          <StatusChip status={job.status} />
        </View>

        <Text style={styles.section}>Schedule</Text>
        <Text style={styles.body}>{formatWhen(job.scheduledDate)}</Text>

        <Text style={styles.section}>Customer</Text>
        <Text style={styles.body}>{job.clientName}</Text>

        <Text style={styles.section}>Site</Text>
        <Text style={styles.body}>{job.locationAddress}</Text>

        <Text style={styles.section}>Scope</Text>
        <Text style={styles.body}>{job.description || '—'}</Text>

        {job.status !== JOB_STATUS.COMPLETED ? (
          <TouchableOpacity style={styles.primaryBtn} onPress={() => setAssignOpen(true)}>
            <Text style={styles.primaryBtnText}>Assign technician</Text>
          </TouchableOpacity>
        ) : (
          <Text style={styles.completedNote}>This work order is completed.</Text>
        )}
      </ScrollView>

      <Modal visible={assignOpen} animationType="slide" transparent>
        <Pressable style={styles.modalOverlay} onPress={() => setAssignOpen(false)}>
          <Pressable style={styles.sheet} onPress={e => e.stopPropagation()}>
            <Text style={styles.sheetTitle}>Choose technician</Text>
            <ScrollView style={styles.sheetList}>
              {workers.map(w => (
                <ListRowCard
                  key={w.id}
                  title={w.fullName}
                  subtitle={w.phone}
                  onPress={() => onAssign(w.id)}
                  right={
                    assigning === w.id ? (
                      <Text style={styles.assigning}>…</Text>
                    ) : (
                      <Text style={styles.pick}>Add</Text>
                    )
                  }
                />
              ))}
            </ScrollView>
            <TouchableOpacity style={styles.cancelBtn} onPress={() => setAssignOpen(false)}>
              <Text style={styles.cancelText}>Cancel</Text>
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
  hero: { marginBottom: spacing.md },
  kicker: { ...typography.overline, color: colors.textMuted },
  headline: {
    ...typography.title,
    color: colors.textPrimary,
    marginVertical: spacing.sm,
  },
  section: {
    ...typography.overline,
    color: colors.textMuted,
    marginTop: spacing.lg,
    marginBottom: spacing.sm,
  },
  body: { ...typography.body, color: colors.textSecondary, lineHeight: 22 },
  primaryBtn: {
    marginTop: spacing.xl,
    backgroundColor: colors.accent,
    borderRadius: radius.md,
    paddingVertical: spacing.md,
    alignItems: 'center',
  },
  primaryBtnText: {
    ...typography.subtitle,
    color: colors.background,
  },
  completedNote: {
    ...typography.body,
    color: colors.success,
    marginTop: spacing.xl,
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
  assigning: { ...typography.caption, color: colors.textMuted },
  cancelBtn: { padding: spacing.md, alignItems: 'center' },
  cancelText: { ...typography.subtitle, color: colors.textSecondary },
});

export default JobDetailScreen;
