import React from 'react';
import { createNativeStackNavigator } from '@react-navigation/native-stack';
import DirectoryMenuScreen from '../screens/directory/DirectoryMenuScreen';
import ClientsListScreen from '../screens/directory/ClientsListScreen';
import ClientDetailScreen from '../screens/directory/ClientDetailScreen';
import LocationsListScreen from '../screens/directory/LocationsListScreen';
import LocationDetailScreen from '../screens/directory/LocationDetailScreen';
import EquipmentListScreen from '../screens/directory/EquipmentListScreen';
import EquipmentDetailScreen from '../screens/directory/EquipmentDetailScreen';
import type { DirectoryStackParamList } from './types';
import { colors } from '../theme/theme';

const Stack = createNativeStackNavigator<DirectoryStackParamList>();

const DirectoryStack = () => (
  <Stack.Navigator
    screenOptions={{
      headerShown: false,
      contentStyle: { backgroundColor: colors.background },
    }}>
    <Stack.Screen name="DirectoryMenu" component={DirectoryMenuScreen} />
    <Stack.Screen name="ClientsList" component={ClientsListScreen} />
    <Stack.Screen name="ClientDetail" component={ClientDetailScreen} />
    <Stack.Screen name="LocationsList" component={LocationsListScreen} />
    <Stack.Screen name="LocationDetail" component={LocationDetailScreen} />
    <Stack.Screen name="EquipmentList" component={EquipmentListScreen} />
    <Stack.Screen name="EquipmentDetail" component={EquipmentDetailScreen} />
  </Stack.Navigator>
);

export default DirectoryStack;
