import { apiGet, apiPostNoContent, apiPutNoContent } from './httpClient';
import type {
  ClientDto,
  DispatchDto,
  EquipmentDto,
  JobDto,
  LocationDto,
  WorkerDto,
} from '../types/models';

const json = (path: string) => apiGet<unknown>(path);

export async function fetchJobs(): Promise<JobDto[]> {
  const data = await json('api/Jobs');
  return Array.isArray(data) ? (data as JobDto[]) : [];
}

export async function fetchJob(id: number): Promise<JobDto> {
  return apiGet<JobDto>(`api/Jobs/${id}`);
}

export async function fetchDispatches(): Promise<DispatchDto[]> {
  const data = await json('api/Dispatches');
  return Array.isArray(data) ? (data as DispatchDto[]) : [];
}

export async function fetchDispatch(id: number): Promise<DispatchDto> {
  return apiGet<DispatchDto>(`api/Dispatches/${id}`);
}

export async function fetchWorkers(): Promise<WorkerDto[]> {
  const data = await json('api/Workers');
  return Array.isArray(data) ? (data as WorkerDto[]) : [];
}

export async function fetchWorker(id: number): Promise<WorkerDto> {
  return apiGet<WorkerDto>(`api/Workers/${id}`);
}

export async function fetchClients(): Promise<ClientDto[]> {
  const data = await json('api/Clients');
  return Array.isArray(data) ? (data as ClientDto[]) : [];
}

export async function fetchClient(id: number): Promise<ClientDto> {
  return apiGet<ClientDto>(`api/Clients/${id}`);
}

export async function fetchLocations(): Promise<LocationDto[]> {
  const data = await json('api/Locations');
  return Array.isArray(data) ? (data as LocationDto[]) : [];
}

export async function fetchLocation(id: number): Promise<LocationDto> {
  return apiGet<LocationDto>(`api/Locations/${id}`);
}

export async function fetchEquipments(): Promise<EquipmentDto[]> {
  const data = await json('api/Equipments');
  return Array.isArray(data) ? (data as EquipmentDto[]) : [];
}

export async function fetchEquipment(id: number): Promise<EquipmentDto> {
  return apiGet<EquipmentDto>(`api/Equipments/${id}`);
}

export function assignWorkerToJob(jobId: number, workerId: number) {
  return apiPostNoContent(`api/Jobs/${jobId}/workers/${workerId}`);
}

export type UpdateJobPayload = {
  title: string;
  description: string;
  status: string;
  scheduledDate: string;
  clientId: number;
  locationId: number;
};

export function updateJob(jobId: number, body: UpdateJobPayload) {
  return apiPutNoContent(`api/Jobs/${jobId}`, body);
}

export function assignEquipmentToJob(jobId: number, equipmentId: number) {
  return apiPostNoContent(`api/Jobs/${jobId}/equipment/${equipmentId}`);
}
