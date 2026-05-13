import React from 'react';
import { Text } from 'react-native';
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';
import HomeStack from './HomeStack';
import JobsStack from './JobsStack';
import DispatchStack from './DispatchStack';
import TeamStack from './TeamStack';
import DirectoryStack from './DirectoryStack';
import type { MainTabParamList } from './types';
import { colors } from '../theme/theme';

const Tab = createBottomTabNavigator<MainTabParamList>();

const tabIcon = (emoji: string, focused: boolean) => (
  <Text style={{ fontSize: 20, opacity: focused ? 1 : 0.45 }}>{emoji}</Text>
);

const MainTabNavigator = () => (
  <Tab.Navigator
    screenOptions={{
      headerShown: false,
      tabBarStyle: {
        backgroundColor: colors.surface,
        borderTopColor: colors.border,
      },
      tabBarActiveTintColor: colors.accent,
      tabBarInactiveTintColor: colors.textMuted,
      tabBarLabelStyle: { fontSize: 11, fontWeight: '600' },
    }}>
    <Tab.Screen
      name="HomeTab"
      component={HomeStack}
      options={{
        title: 'Home',
        tabBarIcon: ({ focused }) => tabIcon('⌂', focused),
      }}
    />
    <Tab.Screen
      name="JobsTab"
      component={JobsStack}
      options={{
        title: 'Jobs',
        tabBarIcon: ({ focused }) => tabIcon('▤', focused),
      }}
    />
    <Tab.Screen
      name="DispatchTab"
      component={DispatchStack}
      options={{
        title: 'Dispatch',
        tabBarIcon: ({ focused }) => tabIcon('⛟', focused),
      }}
    />
    <Tab.Screen
      name="TeamTab"
      component={TeamStack}
      options={{
        title: 'Team',
        tabBarIcon: ({ focused }) => tabIcon('👷', focused),
      }}
    />
    <Tab.Screen
      name="DirectoryTab"
      component={DirectoryStack}
      options={{
        title: 'Directory',
        tabBarIcon: ({ focused }) => tabIcon('☰', focused),
      }}
    />
  </Tab.Navigator>
);

export default MainTabNavigator;
