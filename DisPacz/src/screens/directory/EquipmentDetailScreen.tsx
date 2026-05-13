import React, { useCallback, useState } from 'react';
import { ScrollView, StyleSheet, Text, TouchableOpacity, View } from 'react-native';
import { useFocusEffect } from '@react-navigation/native';
import type { NativeStackNavigationProp } from '@react-navigation/native-stack';
import type { RouteProp } from '@react-navigation/native';
import { SafeAreaView } from 'react-native-safe-area-context';
import { fetchEquipment } from '../../api/disPaczApi';
import { ApiError } from '../../api/httpClient';
import { ErrorBlock, LoadingBlock } from '../../components/ListRowCard';
import type { DirectoryStackParamList } from '../../navigation/types';
import { colors, radius, spacing, typography } from '../../theme/theme';
import type { EquipmentDto } from '../../types/models';

type Nav = NativeStackNavigationProp<DirectoryStackParamList, 'EquipmentDetail'>;
type R = RouteProp<DirectoryStackParamList, 'EquipmentDetail'>;

type Props = { navigation: Nav; route: R };

const EquipmentDetailScreen: React.FC<Props> = ({ navigation, route }) => {
  const { id } = route.params;
  const [eq, setEq] = useState<EquipmentDto | null>(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  const load = useCallback(async () => {
    setError(null);
    try {
      setEq(await fetchEquipment(id));
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

  if (loading) {
    return (
      <SafeAreaView style={styles.safe} edges={['top']}>
        <LoadingBlock />
      </SafeAreaView>
    );
  }

  if (error || !eq) {
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
        <Text style={styles.kicker}>Equipment #{eq.id}</Text>
        <Text style={styles.title}>{eq.name}</Text>
        <View style={styles.card}>
          <Text style={styles.label}>Serial number</Text>
          <Text style={styles.value}>{eq.serialNumber || '—'}</Text>
        </View>
      </ScrollView>
    </SafeAreaView>
  );
};

const styles = StyleSheet.create({
  safe: { flex: 1, backgroundColor: colors.background },
  content: { padding: spacing.lg, paddingBottom: spacing.xl * 2 },
  back: { marginBottom: spacing.md },
  backText: { ...typography.subtitle, color: colors.accent },
  kicker: { ...typography.overline, color: colors.textMuted },
  title: { ...typography.title, color: colors.textPrimary, marginVertical: spacing.md },
  card: {
    backgroundColor: colors.surfaceElevated,
    borderRadius: radius.md,
    borderWidth: 1,
    borderColor: colors.border,
    padding: spacing.lg,
  },
  label: { ...typography.caption, color: colors.textMuted },
  value: { ...typography.body, color: colors.textPrimary, marginTop: spacing.xs },
});

export default EquipmentDetailScreen;
