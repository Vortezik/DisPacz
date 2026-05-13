import React from 'react';
import { createNativeStackNavigator } from '@react-navigation/native-stack';
import JobsListScreen from '../screens/jobs/JobsListScreen';
import JobDetailScreen from '../screens/jobs/JobDetailScreen';
import type { JobsStackParamList } from './types';
import { colors } from '../theme/theme';

const Stack = createNativeStackNavigator<JobsStackParamList>();

const JobsStack = () => (
  <Stack.Navigator
    screenOptions={{
      headerShown: false,
      contentStyle: { backgroundColor: colors.background },
    }}>
    <Stack.Screen name="JobsList" component={JobsListScreen} />
    <Stack.Screen name="JobDetail" component={JobDetailScreen} />
  </Stack.Navigator>
);

export default JobsStack;
