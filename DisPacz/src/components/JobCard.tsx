import React from 'react';
import { StyleSheet, Text, TouchableOpacity, View } from 'react-native';
import { colors, radius, spacing, typography } from '../theme/theme';
import { StatusChip } from './StatusChip';
import type { JobDto } from '../types/models';

type Props = {
  job: JobDto;
  onPress?: () => void;
};

const formatWhen = (iso: string) => {
  try {
    const d = new Date(iso);
    return d.toLocaleString(undefined, {
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

const JobCard: React.FC<Props> = ({ job, onPress }) => {
  const body = (
    <>
      <View style={styles.header}>
        <Text style={styles.title} numberOfLines={2}>
          {job.title}
        </Text>
        <StatusChip status={job.status} />
      </View>
      <Text style={styles.meta}>{formatWhen(job.scheduledDate)}</Text>
      <Text style={styles.line} numberOfLines={1}>
        {job.clientName}
      </Text>
      <Text style={styles.lineMuted} numberOfLines={2}>
        {job.locationAddress}
      </Text>
    </>
  );

  if (onPress) {
    return (
      <TouchableOpacity style={styles.card} onPress={onPress} activeOpacity={0.8}>
        {body}
      </TouchableOpacity>
    );
  }

  return <View style={styles.card}>{body}</View>;
};

const styles = StyleSheet.create({
  card: {
    backgroundColor: colors.surfaceElevated,
    borderRadius: radius.lg,
    borderWidth: 1,
    borderColor: colors.border,
    padding: spacing.md,
    marginBottom: spacing.md,
  },
  header: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'flex-start',
    gap: spacing.sm,
    marginBottom: spacing.sm,
  },
  title: {
    flex: 1,
    ...typography.subtitle,
    color: colors.textPrimary,
  },
  meta: {
    ...typography.caption,
    color: colors.accent,
    marginBottom: spacing.sm,
  },
  line: {
    ...typography.body,
    color: colors.textPrimary,
    marginBottom: 2,
  },
  lineMuted: {
    ...typography.caption,
    color: colors.textSecondary,
  },
});

export default JobCard;
