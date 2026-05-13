import React from 'react';
import { createNativeStackNavigator } from '@react-navigation/native-stack';
import WorkersListScreen from '../screens/workers/WorkersListScreen';
import WorkerDetailScreen from '../screens/workers/WorkerDetailScreen';
import type { TeamStackParamList } from './types';
import { colors } from '../theme/theme';

const Stack = createNativeStackNavigator<TeamStackParamList>();

const TeamStack = () => (
  <Stack.Navigator
    screenOptions={{
      headerShown: false,
      contentStyle: { backgroundColor: colors.background },
    }}>
    <Stack.Screen name="WorkersList" component={WorkersListScreen} />
    <Stack.Screen name="WorkerDetail" component={WorkerDetailScreen} />
  </Stack.Navigator>
);

export default TeamStack;
