import type { SimpleCoach } from './coachSchemas.ts';
import type { Sport } from './sportSchemas.ts';
import type { SimpleAthleteInjury } from './athleteInjurySchemas.ts';

/**
 * Schema for athletes data transfer object
 */
export interface Athletes {
    id: string;
    firstName: string;
    middleName: string;
    lastName: string;
    dateOfBirth: string;
    email: string;
}

/**
 * Schema for athlete data transfer object with coach, sport, and injuries
 */
export interface Athlete extends Athletes {
    coach: SimpleCoach;
    sport: Sport;
    athleteInjuries: SimpleAthleteInjury[];
}