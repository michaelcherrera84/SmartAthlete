import axios from 'axios';

/**
 * Axios instance for making API requests.
 */
export const api = axios.create({
    baseURL: 'https://localhost:7273',
    withCredentials: true,  // Allow cookies to be sent with requests
});