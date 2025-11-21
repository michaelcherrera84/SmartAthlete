import type { Injury } from './injurySchemas.ts';
import type { Athlete } from './athleteSchemas.ts';

/**
 * Schema for athlete injury data transfer object with athlete
 */
export interface AthleteInjuries {
    athlete: Athlete;
    injury: Injury;
    date: string;
    description: string;
}

/**
 * Schema for athlete injury data transfer object
 */
export interface SimpleAthleteInjury {
    injury: Injury;
    date: string;
    description: string;
}