export interface LoginDto {
    username: string;
    passwordHash: string;
}

export interface User {
    id: string;
    username: string;
    firstName: string;
    lastName: string;
    email: string;
    role: string;
}