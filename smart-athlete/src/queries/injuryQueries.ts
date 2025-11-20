import { api } from '../lib/api/api.ts';

/**
 * Fetch all injuries
 */
export const getInjuries = async () => {
    const response = await api.get('/injury');
    return response.data;
};