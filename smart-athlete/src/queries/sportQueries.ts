import { api } from '../lib/api/api.ts';
import type { Sport } from '../schemas/sportSchemas.ts';

/**
 * Fetch all sports
 */
export const getSports = async () => {
    const response = await api.get<Sport[]>('/sport');
    return response.data;
};