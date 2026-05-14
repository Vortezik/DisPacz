import React, { useCallback, useState } from 'react';
import { FlatList, RefreshControl, StyleSheet, Text, View, } from 'react-native';
import { useFocusEffect } from '@react-navigation/native';
import type { NativeStackNavigationProp } from '@react-navigation/native-stack';
import { SafeAreaView } from 'react-native-safe-area-context';
import { fetchWorkers } from '../../api/disPaczApi';
import { ApiError } from '../../api/httpClient';
import { ErrorBlock, ListRowCard, LoadingBlock } from '../../components/ListRowCard';
import type { TeamStackParamList } from '../../navigation/types';
import { colors, spacing, typography } from '../../theme/theme';
import type { WorkerDto } from '../../types/models';

type Nav = NativeStackNavigationProp<TeamStackParamList, 'WorkersList'>;

type Props = { navigation: Nav };

const WorkersListScreen: React.FC<Props> = ({ navigation }) => {
  const [workers, setWorkers] = useState<WorkerDto[]>([]);
  const [loading, setLoading] = useState(true);
  const [refreshing, setRefreshing] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const load = useCallback(async () => {
    setError(null);
    try {
      const data = await fetchWorkers();
      setWorkers(data.sort((a, b) => a.fullName.localeCompare(b.fullName)));
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

  if (error && workers.length === 0) {
    return (
      <SafeAreaView style={styles.safe} edges={['top']}>
        <ErrorBlock message={error} onRetry={load} />
      </SafeAreaView>
    );
  }

  return (
    <SafeAreaView style={styles.safe} edges={['top']}>
      <View style={styles.header}>
        <Text style={styles.title}>Technicians</Text>
        <Text style={styles.subtitle}>Field team directory</Text>
      </View>
      <FlatList
        data={workers}
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
          <Text style={styles.empty}>No technicians on file.</Text>
        }
        renderItem={({ item }) => (
          <ListRowCard
            title={item.fullName}
            subtitle={item.phone}
            onPress={() => navigation.navigate('WorkerDetail', { id: item.id })}
            right={<Text style={styles.chev}>›</Text>}
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
  chev: { fontSize: 22, color: colors.accent },
});

export default WorkersListScreen;
