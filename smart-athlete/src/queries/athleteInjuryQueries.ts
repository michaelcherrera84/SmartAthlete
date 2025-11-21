import { api } from '../lib/api/api.ts';
import type { AthleteInjuries } from '../schemas/athleteInjurySchemas.ts';

/**
 * Fetch all athlete injuries
 */
export const getAthleteInjuries = async () => {
    const response = await api.get<AthleteInjuries[]>('/AthleteInjuries');

    return response.data.map(ai => ({
        ...ai,
        date: new Date(ai.date).toLocaleDateString(),
    }));
};

export const getAthleteInjury = async (athleteId: string, injuryId: number, date: string) => {
    const response = await api.get(`/AthleteInjuries/${athleteId}/${injuryId}/${date}`);
    response.data.date = new Date(response.data.date).toLocaleDateString();
    return response.data;
};