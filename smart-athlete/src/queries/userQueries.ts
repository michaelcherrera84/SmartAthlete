import { api } from '../lib/api/api.ts';
import type { LoginDto, User } from '../schemas/userSchemas.ts';

/**
 * Login function
 * @param data
 */
export const login = async (data: LoginDto) => {
    const response = await api.post('/auth/login', data);
    return response.data;
};

/**
 * Fetch current user
 */
export const fetchMe = async () : Promise<User> => {
    const response = await api.get('/auth/me');
    return response.data;
}

/**
 * Logout function
 */
export const logout = async () => {
    const response = await api.post('/auth/logout');
    return response.data;
};