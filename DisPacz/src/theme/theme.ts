export const colors = {
  background: '#0B1220',
  surface: '#151D2E',
  surfaceElevated: '#1C2639',
  border: '#2A3548',
  textPrimary: '#F2F5FA',
  textSecondary: '#9AA8BC',
  textMuted: '#6B7A90',
  accent: '#2DD4BF',
  accentMuted: 'rgba(45, 212, 191, 0.15)',
  danger: '#F87171',
  warning: '#FBBF24',
  success: '#4ADE80',
  info: '#60A5FA',
  overlay: 'rgba(7, 11, 18, 0.72)',
};

export const spacing = {
  xs: 4,
  sm: 8,
  md: 16,
  lg: 24,
  xl: 32,
};

export const radius = {
  sm: 8,
  md: 12,
  lg: 16,
};

export const typography = {
  title: { fontSize: 22, fontWeight: '700' as const },
  subtitle: { fontSize: 16, fontWeight: '600' as const },
  body: { fontSize: 15, fontWeight: '400' as const },
  caption: { fontSize: 13, fontWeight: '500' as const },
  overline: { fontSize: 11, fontWeight: '600' as const, letterSpacing: 0.8 },
};
