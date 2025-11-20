import { createBrowserRouter } from 'react-router';
import App from '../App.tsx';
import Home from '../pages/Home.tsx';
import Login from '../pages/Login.tsx';
import RequireAuth from './RequireAuth.tsx';
import RequireRole from './RequireRole.tsx';
import ManageData from '../pages/admin-dashboard/ManageData.tsx';
import Athletes from '../pages/admin-dashboard/athlete/Athletes.tsx';
import Sports from '../pages/admin-dashboard/sport/Sports.tsx';
import Injuries from '../pages/admin-dashboard/injury/Injuries.tsx';

/**
 * Browser router for the application.
 */
export const router = createBrowserRouter([
    {
        path: '/',
        element: <App />,
        children: [
            {
                element: <RequireAuth />, children: [
                    { path: '', element: <Home /> },

                    // Admin-only
                    {
                        element: <RequireRole allowed={ ['Admin'] } />, children: [
                            // Admin Dashboard
                            { path: '/dashboard/manage-data', element: <ManageData /> },

                            // Athlete Management
                            { path: '/dashboard/manage-data/athletes', element: <Athletes /> },

                            // Sport Management
                            { path: '/dashboard/manage-data/sports', element: <Sports /> },

                            // Injury Management
                            { path: '/dashboard/manage-data/injuries', element: <Injuries /> },
                        ],
                    },
                ],
            },
            { path: 'login', element: <Login /> },
        ],
    },
]);