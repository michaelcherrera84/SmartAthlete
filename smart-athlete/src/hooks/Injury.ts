import { useQuery } from '@tanstack/react-query';
import { getInjuries } from '../queries/injuryQueries.ts';

/**
 * Custom hook to query injuries.
 */
export const useInjury = () => {

    // Fetch injuries
    const {data: injuries, isLoading: loadingInjuries, isError: injuriesError} = useQuery({
        queryKey: ['injuries'],
        queryFn: getInjuries,
    });

    return {
        loadingInjuries,
        injuriesError,
        injuries,
    };
};