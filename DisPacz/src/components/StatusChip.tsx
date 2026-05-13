import React from 'react';
import { StyleSheet, Text, View } from 'react-native';
import { colors, radius, typography } from '../theme/theme';

const statusColor = (status: string): string => {
  const s = status.toLowerCase();
  if (s.includes('complete')) {
    return colors.success;
  }
  if (s.includes('progress')) {
    return colors.warning;
  }
  if (s.includes('open') || s.includes('pending') || s.includes('schedule')) {
    return colors.info;
  }
  if (s.includes('cancel')) {
    return colors.danger;
  }
  return colors.textMuted;
};

type Props = { status: string };

export const StatusChip: React.FC<Props> = ({ status }) => (
  <View style={[styles.wrap, { backgroundColor: statusColor(status) + '22' }]}>
    <Text style={[styles.text, { color: statusColor(status) }]}>{status}</Text>
  </View>
);

const styles = StyleSheet.create({
  wrap: {
    alignSelf: 'flex-start',
    paddingHorizontal: 10,
    paddingVertical: 4,
    borderRadius: radius.sm,
  },
  text: {
    ...typography.caption,
    textTransform: 'uppercase',
  },
});
