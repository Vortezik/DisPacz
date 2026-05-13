import { apiUrl } from '../config/apiConfig';

async function parseJsonSafe(res: Response): Promise<unknown> {
  const text = await res.text();
  if (!text) {
    return null;
  }
  try {
    return JSON.parse(text);
  } catch {
    return text;
  }
}

export class ApiError extends Error {
  constructor(
    message: string,
    public status: number,
    public body?: unknown,
  ) {
    super(message);
    this.name = 'ApiError';
  }
}

export async function apiGet<T>(path: string): Promise<T> {
  const res = await fetch(apiUrl(path), {
    headers: { Accept: 'application/json' },
  });
  const body = await parseJsonSafe(res);
  if (!res.ok) {
    throw new ApiError(
      typeof body === 'string' ? body : `Request failed (${res.status})`,
      res.status,
      body,
    );
  }
  return body as T;
}

export async function apiPost<T>(path: string, json?: unknown): Promise<T> {
  const res = await fetch(apiUrl(path), {
    method: 'POST',
    headers: {
      Accept: 'application/json',
      'Content-Type': 'application/json',
    },
    body: json === undefined ? undefined : JSON.stringify(json),
  });
  const body = await parseJsonSafe(res);
  if (!res.ok) {
    throw new ApiError(
      typeof body === 'string' ? body : `Request failed (${res.status})`,
      res.status,
      body,
    );
  }
  return body as T;
}

export async function apiPostNoContent(path: string, json?: unknown): Promise<void> {
  const res = await fetch(apiUrl(path), {
    method: 'POST',
    headers: {
      Accept: 'application/json',
      'Content-Type': 'application/json',
    },
    body: json === undefined ? undefined : JSON.stringify(json),
  });
  if (!res.ok) {
    const body = await parseJsonSafe(res);
    throw new ApiError(
      typeof body === 'string' ? body : `Request failed (${res.status})`,
      res.status,
      body,
    );
  }
}

export async function apiPutNoContent(path: string, json?: unknown): Promise<void> {
  const res = await fetch(apiUrl(path), {
    method: 'PUT',
    headers: {
      Accept: 'application/json',
      'Content-Type': 'application/json',
    },
    body: json === undefined ? undefined : JSON.stringify(json),
  });
  if (!res.ok) {
    const body = await parseJsonSafe(res);
    throw new ApiError(
      typeof body === 'string' ? body : `Request failed (${res.status})`,
      res.status,
      body,
    );
  }
}
