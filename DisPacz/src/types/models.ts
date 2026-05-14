export interface EquipmentOnJobDto {
  id: number;
  name: string;
  serialNumber: string;
}

export interface JobDto {
  id: number;
  title: string;
  description: string;
  scheduledDate: string;
  status: string;
  clientId: number;
  clientName: string;
  locationId: number;
  locationAddress: string;
  assignedEquipment?: EquipmentOnJobDto[];
}

export interface DispatchDto {
  id: number;
  assignedAt: string;
  jobId: number;
  jobTitle: string;
  workerId: number;
  workerName: string;
}

export interface WorkerDto {
  id: number;
  fullName: string;
  phone: string;
}

export interface ClientDto {
  id: number;
  name: string;
  phone: string;
  email: string;
}

export interface LocationDto {
  id: number;
  address: string;
  city: string;
}

export interface EquipmentDto {
  id: number;
  name: string;
  serialNumber: string;
}
