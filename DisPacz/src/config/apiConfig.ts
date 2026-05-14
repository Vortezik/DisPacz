import { Platform } from 'react-native';

const DEV_HOST = Platform.OS === 'android' ? '10.0.2.2' : 'localhost';
const DEV_API_PORT = '5215';

export const API_BASE_URL = __DEV__
  ? `http://${DEV_HOST}:${DEV_API_PORT}`
  : 'https://your-production-api.example.com';

export const apiUrl = (path: string) =>
  `${API_BASE_URL.replace(/\/$/, '')}/${path.replace(/^\//, '')}`;
