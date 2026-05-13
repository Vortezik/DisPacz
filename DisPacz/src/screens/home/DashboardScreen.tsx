import React, { useCallback, useMemo, useState } from 'react';
import {
  RefreshControl,
  ScrollView,
  StyleSheet,
  Text,
  TouchableOpacity,
  View,
} from 'react-native';
import { useFocusEffect } from '@react-navigation/native';
import type { NativeStackNavigationProp } from '@react-navigation/native-stack';
import { SafeAreaView } from 'react-native-safe-area-context';
import { colors, radius, spacing, typography } from '../../theme/theme';
import {
  fetchDispatches,
  fetchJobs,
  fetchWorkers,
} from '../../api/disPaczApi';
import { ApiError } from '../../api/httpClient';
import { LoadingBlock, ErrorBlock } from '../../components/ListRowCard';
import type { HomeStackParamList, MainTabParamList } from '../../navigation/types';
import type { CompositeNavigationProp } from '@react-navigation/native';
import type { BottomTabNavigationProp } from '@react-navigation/bottom-tabs';

type Nav = CompositeNavigationProp<
  NativeStackNavigationProp<HomeStackParamList, 'Dashboard'>,
  BottomTabNavigationProp<MainTabParamList>
>;

type Props = { navigation: Nav };

const DashboardScreen: React.FC<Props> = ({ navigation }) => {
  const [loading, setLoading] = useState(true);
  const [refreshing, setRefreshing] = useState(false);
  const [error, setError] = useState<string | null>(null);
  const [jobCount, setJobCount] = useState(0);
  const [openJobs, setOpenJobs] = useState(0);
  const [dispatchCount, setDispatchCount] = useState(0);
  const [workerCount, setWorkerCount] = useState(0);

  const load = useCallback(async () => {
    setError(null);
    try {
      const [jobs, dispatches, workers] = await Promise.all([
        fetchJobs(),
        fetchDispatches(),
        fetchWorkers(),
      ]);
      setJobCount(jobs.length);
      setOpenJobs(
        jobs.filter(
          j => !j.status.toLowerCase().includes('complete'),
        ).length,
      );
      setDispatchCount(dispatches.length);
      setWorkerCount(workers.length);
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
      setRefreshing(false);
    }
  }, []);

  useFocusEffect(
    useCallback(() => {
      setLoading(true);
      load();
    }, [load]),
  );

  const onRefresh = () => {
    setRefreshing(true);
    load();
  };

  const tiles = useMemo(
    () => [
      { label: 'Work orders', value: jobCount, hint: `${openJobs} active` },
      { label: 'Dispatches', value: dispatchCount, hint: 'Assignments' },
      { label: 'Technicians', value: workerCount, hint: 'Field team' },
    ],
    [jobCount, openJobs, dispatchCount, workerCount],
  );

  if (loading) {
    return (
      <SafeAreaView style={styles.safe} edges={['top']}>
        <LoadingBlock />
      </SafeAreaView>
    );
  }

  if (error) {
    return (
      <SafeAreaView style={styles.safe} edges={['top']}>
        <ErrorBlock message={error} onRetry={load} />
      </SafeAreaView>
    );
  }

  return (
    <SafeAreaView style={styles.safe} edges={['top']}>
      <ScrollView
      style={styles.screen}
      contentContainerStyle={styles.content}
      refreshControl={
        <RefreshControl refreshing={refreshing} onRefresh={onRefresh} tintColor={colors.accent} />
      }>
      <Text style={styles.kicker}>Field service</Text>
      <Text style={styles.headline}>Operations overview</Text>
      <Text style={styles.lead}>
        Monitor open work, crew assignments, and customer sites from one place.
      </Text>

      <View style={styles.grid}>
        {tiles.map(t => (
          <View key={t.label} style={styles.statCard}>
            <Text style={styles.statValue}>{t.value}</Text>
            <Text style={styles.statLabel}>{t.label}</Text>
            <Text style={styles.statHint}>{t.hint}</Text>
          </View>
        ))}
      </View>

      <Text style={styles.section}>Shortcuts</Text>
      <TouchableOpacity
        style={styles.linkRow}
        onPress={() => navigation.navigate('JobsTab', { screen: 'JobsList' })}>
        <Text style={styles.linkTitle}>View all jobs</Text>
        <Text style={styles.linkChevron}>›</Text>
      </TouchableOpacity>
      <TouchableOpacity
        style={styles.linkRow}
        onPress={() => navigation.navigate('DispatchTab', { screen: 'DispatchesList' })}>
        <Text style={styles.linkTitle}>Dispatch board</Text>
        <Text style={styles.linkChevron}>›</Text>
      </TouchableOpacity>
      <TouchableOpacity
        style={styles.linkRow}
        onPress={() => navigation.navigate('DirectoryTab', { screen: 'DirectoryMenu' })}>
        <Text style={styles.linkTitle}>Clients, sites & equipment</Text>
        <Text style={styles.linkChevron}>›</Text>
      </TouchableOpacity>
    </ScrollView>
    </SafeAreaView>
  );
};

const styles = StyleSheet.create({
  safe: { flex: 1, backgroundColor: colors.background },
  screen: { flex: 1 },
  content: { padding: spacing.lg, paddingBottom: spacing.xl * 2 },
  kicker: {
    ...typography.overline,
    color: colors.accent,
    marginBottom: spacing.xs,
  },
  headline: { ...typography.title, color: colors.textPrimary, marginBottom: spacing.sm },
  lead: {
    ...typography.body,
    color: colors.textSecondary,
    marginBottom: spacing.lg,
    lineHeight: 22,
  },
  grid: { flexDirection: 'row', flexWrap: 'wrap', gap: spacing.sm, marginBottom: spacing.lg },
  statCard: {
    flexGrow: 1,
    flexBasis: '30%',
    minWidth: 100,
    backgroundColor: colors.surfaceElevated,
    borderRadius: radius.md,
    borderWidth: 1,
    borderColor: colors.border,
    padding: spacing.md,
  },
  statValue: { ...typography.title, color: colors.textPrimary },
  statLabel: {
    ...typography.caption,
    color: colors.textSecondary,
    marginTop: spacing.xs,
  },
  statHint: { ...typography.caption, color: colors.textMuted, marginTop: 4 },
  section: {
    ...typography.overline,
    color: colors.textMuted,
    marginBottom: spacing.sm,
    marginTop: spacing.sm,
  },
  linkRow: {
    flexDirection: 'row',
    alignItems: 'center',
    justifyContent: 'space-between',
    backgroundColor: colors.surfaceElevated,
    borderRadius: radius.md,
    borderWidth: 1,
    borderColor: colors.border,
    padding: spacing.md,
    marginBottom: spacing.sm,
  },
  linkTitle: { ...typography.subtitle, color: colors.textPrimary, flex: 1 },
  linkChevron: { fontSize: 22, color: colors.accent, marginLeft: spacing.sm },
});

export default DashboardScreen;
