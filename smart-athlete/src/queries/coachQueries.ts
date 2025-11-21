import { api } from '../lib/api/api.ts';
import type { Coach, Coaches } from '../schemas/coachSchemas.ts';

/**
 * Fetch all coaches
 */
export const getCoaches = async () => {
    const response = await api.get<Coaches[]>('/coach');

    return response.data.map(c => ({
        ...c,
        dateOfBirth: new Date(c.dateOfBirth).toLocaleDateString()
    }));
}

/**
 * Fetch a single coach by ID
 * @param id - The ID of the coach to fetch
 */
export const getCoach = async (id: string) => {
    const response = await api.get<Coach>(`/coach/${id}`);
    response.data.dateOfBirth = new Date(response.data.dateOfBirth).toLocaleDateString();
    return response.data;
}