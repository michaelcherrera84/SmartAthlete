import { useQuery } from '@tanstack/react-query';
import { getAthleteInjuries, getAthleteInjury } from '../queries/athleteInjuryQueries.ts';

/**
 * Custom hook to query athlete injuries.
 * @param athleteId athlete id
 * @param injuryId injury id
 * @param date date of injury
 */
export const useAthleteInjury = (athleteId?: string, injuryId?: number, date?: string) => {

    // Fetch athlete injuries
    const { data: athleteInjuries, isLoading: loadingAthleteInjuries, isError: athleteInjuriesError } = useQuery({
        queryKey: ['athleteInjuries'],
        queryFn: getAthleteInjuries,
        enabled: !athleteId && !injuryId && !date,
    });

    // Fetch athlete injury by id
    const { data: athleteInjury, isLoading: loadingAthleteInjury, isError: athleteInjuryError } = useQuery({
        queryKey: ['athleteInjury', athleteId, injuryId, date],
        queryFn: () => getAthleteInjury(athleteId!, injuryId!, date!),
        enabled: !!athleteId && !!injuryId && !!date,
    });

    return {
        loadingAthleteInjuries,
        athleteInjuriesError,
        athleteInjuries,
        loadingAthleteInjury,
        athleteInjuryError,
        athleteInjury,
    };
};