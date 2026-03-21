import React from 'react';
import { createNativeStackNavigator } from '@react-navigation/native-stack';
import JobList from '../views/JobList';
import JobDetail from '../views/JobDetail';

const Stack = createNativeStackNavigator();

const AppNavigator = () => (
  <Stack.Navigator>
    <Stack.Screen name="JobList" component={JobList} />
    <Stack.Screen name="JobDetail" component={JobDetail} />
  </Stack.Navigator>
);

export default AppNavigator;