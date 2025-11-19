import axios from 'axios';

// Axios instance for API
export const api = axios.create({
    baseURL: 'https://localhost:7273',
    withCredentials: true,  // Allow cookies to be sent with requests
});