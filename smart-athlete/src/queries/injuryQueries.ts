import { api } from '../lib/api/api.ts';
import type { Injury } from '../schemas/injurySchemas.ts';

/**
 * Fetch all injuries
 */
export const getInjuries = async () => {
    const response = await api.get<Injury[]>('/injury');
    return response.data;
};