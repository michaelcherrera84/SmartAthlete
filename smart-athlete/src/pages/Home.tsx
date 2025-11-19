import { Button } from 'primereact/button';
import { useMutation, useQueryClient } from '@tanstack/react-query';
import { logout } from '../queries/userQueries.ts';
import { useNavigate } from 'react-router';

function Home() {
    const queryClient = useQueryClient();
    const navigate = useNavigate();

    // Custom hook to handle logout.
    const logoutMutation = useMutation({
        mutationFn: logout,
        onSuccess: () => {
            // Clear the cached user so RequireAuth redirects to login
            queryClient.removeQueries({ queryKey: ['me'] });

            // Navigate to the login page
            navigate('/login');
        },
    });

    return (
        <div>
            <Button label="Log Out" onClick={ () => logoutMutation.mutate() } />
        </div>
    );
}

export default Home;