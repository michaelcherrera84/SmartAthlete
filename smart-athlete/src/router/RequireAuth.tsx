import { Navigate, Outlet, useLocation } from 'react-router';
import { useCurrentUser } from '../hooks/CurrentUser.ts';

function RequireAuth() {
    console.log('RequireAuth');
    const location = useLocation();
    const { isLoading, error } = useCurrentUser();

    if (isLoading) return <div>Loading...</div>;

    // When backend returns 401, React Query sets error
    if (error) {
        return <Navigate to="/login" state={ { from: location } } replace />;
    }

    return (
        <Outlet />
    );
}

export default RequireAuth;