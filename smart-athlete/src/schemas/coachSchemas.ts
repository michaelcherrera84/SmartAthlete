import type { Sport } from './sportSchemas.ts';

/**
 * Schema for coaches data transfer object
 */
export interface Coaches {
    id: string;
    firstName: string;
    middleName: string;
    lastName: string;
    dateOfBirth: string;
    email: string;
}

/**
 * Schema for coach data transfer object with sport
 */
export interface Coach extends Coaches {
    sport: Sport;
}

/**
 * Schema for simple coach data transfer object
 */
export interface SimpleCoach {
    id: string;
    firstName: string;
    lastName: string;
    email: string;
}