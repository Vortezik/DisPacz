import type { NavigatorScreenParams } from '@react-navigation/native';

export type HomeStackParamList = {
  Dashboard: undefined;
};

export type JobsStackParamList = {
  JobsList: undefined;
  JobDetail: { id: number };
};

export type DispatchStackParamList = {
  DispatchesList: undefined;
  DispatchDetail: { dispatchId: number };
};

export type TeamStackParamList = {
  WorkersList: undefined;
  WorkerDetail: { id: number };
};

export type DirectoryStackParamList = {
  DirectoryMenu: undefined;
  ClientsList: undefined;
  ClientDetail: { id: number };
  LocationsList: undefined;
  LocationDetail: { id: number };
  EquipmentList: undefined;
  EquipmentDetail: { id: number };
};

export type MainTabParamList = {
  HomeTab: NavigatorScreenParams<HomeStackParamList>;
  JobsTab: NavigatorScreenParams<JobsStackParamList>;
  DispatchTab: NavigatorScreenParams<DispatchStackParamList>;
  TeamTab: NavigatorScreenParams<TeamStackParamList>;
  DirectoryTab: NavigatorScreenParams<DirectoryStackParamList>;
};
