import React from 'react';
import { createNativeStackNavigator } from '@react-navigation/native-stack';
import DispatchesListScreen from '../screens/dispatch/DispatchesListScreen';
import DispatchDetailScreen from '../screens/dispatch/DispatchDetailScreen';
import type { DispatchStackParamList } from './types';
import { colors } from '../theme/theme';

const Stack = createNativeStackNavigator<DispatchStackParamList>();

const DispatchStack = () => (
  <Stack.Navigator
    screenOptions={{
      headerShown: false,
      contentStyle: { backgroundColor: colors.background },
    }}>
    <Stack.Screen name="DispatchesList" component={DispatchesListScreen} />
    <Stack.Screen name="DispatchDetail" component={DispatchDetailScreen} />
  </Stack.Navigator>
);

export default DispatchStack;
