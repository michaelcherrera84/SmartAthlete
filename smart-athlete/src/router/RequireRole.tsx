import { useCurrentUser } from '../hooks/CurrentUser.ts';
import { Navigate, Outlet } from 'react-router';

interface RequireRoleProps {
    allowed: string[];
}

function RequireRole({ allowed }: RequireRoleProps) {
    const { data: user, isLoading } = useCurrentUser();

    if (isLoading) return <div>Loading...</div>;

    if (!user) {
        return <Navigate to="/login" replace />;
    }

    if (!allowed.includes(user.role)) {
        return <Navigate to="/" replace />;
    }

    return <Outlet />;
}

export default RequireRole;