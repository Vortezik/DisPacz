import React from 'react';
import { StyleSheet, Text, TouchableOpacity, View } from 'react-native';
import type { NativeStackNavigationProp } from '@react-navigation/native-stack';
import { SafeAreaView } from 'react-native-safe-area-context';
import type { DirectoryStackParamList } from '../../navigation/types';
import { colors, radius, spacing, typography } from '../../theme/theme';

type Nav = NativeStackNavigationProp<DirectoryStackParamList, 'DirectoryMenu'>;

type Props = { navigation: Nav };

type DirectoryListTarget = 'ClientsList' | 'LocationsList' | 'EquipmentList';

const items: { title: string; desc: string; target: DirectoryListTarget }[] = [
  {
    title: 'Clients',
    desc: 'Accounts you service & bill',
    target: 'ClientsList',
  },
  {
    title: 'Locations',
    desc: 'Sites, addresses & cities',
    target: 'LocationsList',
  },
  {
    title: 'Equipment',
    desc: 'Assets tracked on jobs',
    target: 'EquipmentList',
  },
];

const DirectoryMenuScreen: React.FC<Props> = ({ navigation }) => (
  <SafeAreaView style={styles.safe} edges={['top']}>
    <Text style={styles.headline}>Directory</Text>
    <Text style={styles.lead}>Reference data shared across work orders and dispatch.</Text>
    <View style={styles.grid}>
      {items.map(it => (
        <TouchableOpacity
          key={it.title}
          style={styles.tile}
          onPress={() => navigation.navigate(it.target)}
          activeOpacity={0.85}>
          <Text style={styles.tileTitle}>{it.title}</Text>
          <Text style={styles.tileDesc}>{it.desc}</Text>
        </TouchableOpacity>
      ))}
    </View>
  </SafeAreaView>
);

const styles = StyleSheet.create({
  safe: { flex: 1, backgroundColor: colors.background, padding: spacing.lg },
  headline: { ...typography.title, color: colors.textPrimary },
  lead: {
    ...typography.body,
    color: colors.textSecondary,
    marginTop: spacing.sm,
    marginBottom: spacing.lg,
    lineHeight: 22,
  },
  grid: { gap: spacing.md },
  tile: {
    backgroundColor: colors.surfaceElevated,
    borderRadius: radius.lg,
    borderWidth: 1,
    borderColor: colors.border,
    padding: spacing.lg,
  },
  tileTitle: { ...typography.subtitle, color: colors.textPrimary },
  tileDesc: { ...typography.caption, color: colors.textSecondary, marginTop: spacing.xs },
});

export default DirectoryMenuScreen;
