import { api } from '../lib/api/api.ts';
import type { Athlete, Athletes } from '../schemas/athleteSchemas.ts';

/**
 * Fetch all athletes
 */
export const getAthletes = async () => {
    const response = await api.get<Athletes[]>('/athlete');

    return response.data.map(a => ({
        ...a,
        dateOfBirth: new Date(a.dateOfBirth).toLocaleDateString(),
    }));
};

/**
 * Fetch a single athlete by ID
 * @param id - The ID of the athlete to fetch
 */
export const getAthlete = async (id: string) => {
    const response = await api.get<Athlete>(`/athlete/${ id }`);
    response.data.dateOfBirth = new Date(response.data.dateOfBirth).toLocaleDateString();
    response.data.athleteInjuries = response.data.athleteInjuries.map(ai => ({
        ...ai,
        date: new Date(ai.date).toLocaleDateString(),
    }));
    return response.data;
};