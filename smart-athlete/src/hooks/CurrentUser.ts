import { useQuery } from '@tanstack/react-query';
import { fetchMe } from '../queries/userQueries.ts';

/**
 * Custom hook to fetch the current user's data.
 */
export function useCurrentUser() {
    return useQuery({
        queryKey: ['me'],
        queryFn: fetchMe,
        retry: false,
    });
}