import { Platform } from 'react-native';

/**
 * Dev API port must match how you run DisPacz.API:
 * - `dotnet run` / Visual Studio: see Properties/launchSettings.json (default http port below).
 * - Docker (docker-compose-api.yml): host port 5000 → set DEV_API_PORT to '5000'.
 *
 * Windows: TCP port 5000 is often used by "AirPlay Receiver". Requests there can return 404
 * for `/api/...` even though the app "loads" — you were not hitting ASP.NET.
 *
 * Physical device: set DEV_HOST to your PC's LAN IP (same Wi‑Fi), not localhost / 10.0.2.2.
 */
const DEV_HOST = Platform.OS === 'android' ? '10.0.2.2' : 'localhost';
const DEV_API_PORT = '5215';

export const API_BASE_URL = __DEV__
  ? `http://${DEV_HOST}:${DEV_API_PORT}`
  : 'https://your-production-api.example.com';

export const apiUrl = (path: string) =>
  `${API_BASE_URL.replace(/\/$/, '')}/${path.replace(/^\//, '')}`;
