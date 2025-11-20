import { api } from '../lib/api/api.ts';

/**
 * Fetch all sports
 */
export const getSports = async () => {
    const response = await api.get('/sport');
    return response.data;
};