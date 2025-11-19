import { useQuery } from '@tanstack/react-query';
import { fetchMe } from '../queries/userQueries.ts';

export function useCurrentUser() {
    return useQuery({
        queryKey: ['me'],
        queryFn: fetchMe,
        retry: false,
        // staleTime: 0,
        // refetchOnWindowFocus: false,
        // refetchOnMount: 'always',
    });
}