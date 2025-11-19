// Schema for login data transfer object
export interface LoginDto {
    username: string;
    passwordHash: string;
}

// Schema for user data transfer object
export interface User {
    id: string;
    username: string;
    firstName: string;
    lastName: string;
    email: string;
    role: string;
}