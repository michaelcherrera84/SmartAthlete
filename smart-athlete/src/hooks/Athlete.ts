import { useQuery } from '@tanstack/react-query';
import { getAthlete, getAthletes } from '../queries/athleteQueries.ts';

/**
 * Custom hook to query athletes.
 * @param id athlete id
 */
export const useAthlete = (id?: string) => {

    // Fetch athletes
    const { data: athletes, isLoading: loadingAthletes, isError: athletesError } = useQuery({
        queryKey: ['athletes'],
        queryFn: getAthletes,
        enabled: !id,
    });

    // Fetch athlete by id
    const { data: athlete, isLoading: loadingAthlete, isError: athleteError } = useQuery({
        queryKey: ['athlete', id],
        queryFn: () => getAthlete(id!),
        enabled: !!id,
    });

    return {
        loadingAthletes,
        athletesError,
        athletes,
        loadingAthlete,
        athleteError,
        athlete,
    };
};