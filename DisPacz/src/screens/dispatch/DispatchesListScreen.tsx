import React, { useCallback, useState } from 'react';
import {
  FlatList,
  RefreshControl,
  StyleSheet,
  Text,
  View,
} from 'react-native';
import { useFocusEffect } from '@react-navigation/native';
import type { NativeStackNavigationProp } from '@react-navigation/native-stack';
import { SafeAreaView } from 'react-native-safe-area-context';
import { fetchDispatches } from '../../api/disPaczApi';
import { ApiError } from '../../api/httpClient';
import { ErrorBlock, ListRowCard, LoadingBlock } from '../../components/ListRowCard';
import type { DispatchStackParamList } from '../../navigation/types';
import { colors, spacing, typography } from '../../theme/theme';
import type { DispatchDto } from '../../types/models';

type Nav = NativeStackNavigationProp<DispatchStackParamList, 'DispatchesList'>;

type Props = { navigation: Nav };

const formatWhen = (iso: string) => {
  try {
    return new Date(iso).toLocaleString(undefined, {
      month: 'short',
      day: 'numeric',
      hour: '2-digit',
      minute: '2-digit',
    });
  } catch {
    return iso;
  }
};

const DispatchesListScreen: React.FC<Props> = ({ navigation }) => {
  const [rows, setRows] = useState<DispatchDto[]>([]);
  const [loading, setLoading] = useState(true);
  const [refreshing, setRefreshing] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const load = useCallback(async () => {
    setError(null);
    try {
      const data = await fetchDispatches();
      setRows(
        [...data].sort(
          (a, b) =>
            new Date(b.assignedAt).getTime() - new Date(a.assignedAt).getTime(),
        ),
      );
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

  if (loading && !refreshing) {
    return (
      <SafeAreaView style={styles.safe} edges={['top']}>
        <LoadingBlock />
      </SafeAreaView>
    );
  }

  if (error && rows.length === 0) {
    return (
      <SafeAreaView style={styles.safe} edges={['top']}>
        <ErrorBlock message={error} onRetry={load} />
      </SafeAreaView>
    );
  }

  return (
    <SafeAreaView style={styles.safe} edges={['top']}>
      <View style={styles.header}>
        <Text style={styles.title}>Dispatch board</Text>
        <Text style={styles.subtitle}>Who is assigned to which work order</Text>
      </View>
      <FlatList
        data={rows}
        keyExtractor={item => String(item.id)}
        contentContainerStyle={styles.list}
        refreshControl={
          <RefreshControl
            refreshing={refreshing}
            onRefresh={() => {
              setRefreshing(true);
              load();
            }}
            tintColor={colors.accent}
          />
        }
        ListEmptyComponent={
          <Text style={styles.empty}>No dispatches yet. Assign technicians from a job.</Text>
        }
        renderItem={({ item }) => (
          <ListRowCard
            title={item.jobTitle}
            subtitle={`${item.workerName} · ${formatWhen(item.assignedAt)}`}
            right={<Text style={styles.badge}>#{item.id}</Text>}
            onPress={() => navigation.navigate('DispatchDetail', { dispatchId: item.id })}
          />
        )}
      />
    </SafeAreaView>
  );
};

const styles = StyleSheet.create({
  safe: { flex: 1, backgroundColor: colors.background },
  header: { paddingHorizontal: spacing.lg, paddingBottom: spacing.sm },
  title: { ...typography.title, color: colors.textPrimary },
  subtitle: { ...typography.caption, color: colors.textSecondary, marginTop: 4 },
  list: { paddingHorizontal: spacing.lg, paddingBottom: spacing.xl },
  empty: {
    ...typography.body,
    color: colors.textMuted,
    textAlign: 'center',
    marginTop: spacing.xl,
  },
  badge: {
    ...typography.caption,
    color: colors.accent,
    fontVariant: ['tabular-nums'],
  },
});

export default DispatchesListScreen;
