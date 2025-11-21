import { useQuery } from '@tanstack/react-query';
import { getCoach, getCoaches } from '../queries/coachQueries.ts';

/**
 * Custom hook to query coaches.
 * @param id coach id
 */
export const useCoach = (id?: string) => {

    // Fetch coaches
    const { data: coaches, isLoading: loadingCoaches, isError: coachesError } = useQuery({
        queryKey: ['coaches'],
        queryFn: getCoaches,
        enabled: !id,
    });

    // Fetch coach by id
    const { data: coach, isLoading: loadingCoach, isError: errorCoach} = useQuery({
        queryKey: ['coach', id],
        queryFn: () => getCoach(id!),
        enabled: !!id,
    })

    return {
        loadingCoaches,
        coachesError,
        coaches,
        loadingCoach,
        errorCoach,
        coach,
    };
};