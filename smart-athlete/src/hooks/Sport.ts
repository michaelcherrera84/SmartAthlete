import { useQuery } from '@tanstack/react-query';
import { getSports } from '../queries/sportQueries.ts';

/**
 * Custom hook to query sports.
 */
export const useSport = () => {

    // Fetch sports
    const {data: sports, isLoading: loadingSports, isError: sportsError} = useQuery({
        queryKey: ['sports'],
        queryFn: getSports,
    });

    return {
        loadingSports,
        sportsError,
        sports,
    };
};