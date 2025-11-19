import { api } from '../lib/api/api.ts';
import type { LoginDto, User } from '../schemas/userSchemas.ts';


export const login = async (data: LoginDto) => {
    const response = await api.post('/auth/login', data);
    return response.data;
};

export const fetchMe = async () : Promise<User> => {
    const response = await api.get('/auth/me');
    console.log(response.data);
    return response.data;
}

export const logout = async () => {
    const response = await api.post('/auth/logout');
    return response.data;
};