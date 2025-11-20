import { useCurrentUser } from '../../hooks/CurrentUser.ts';
import { Button } from 'primereact/button';
import { TieredMenu } from 'primereact/tieredmenu';
import { useRef } from 'react';
import { useMutation, useQueryClient } from '@tanstack/react-query';
import { logout } from '../../queries/userQueries.ts';
import { useNavigate } from 'react-router';
import { Avatar } from 'primereact/avatar';

function Sidebar() {
    const { data: user } = useCurrentUser();
    const queryClient = useQueryClient();
    const navigate = useNavigate();

    const menu = useRef<TieredMenu>(null);
    const items = [
        { label: 'Log out', icon: 'pi pi-fw pi-sign-out', command: () => logoutMutation.mutate() },
    ];

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
        <div id="sidebar" className="h-full w-fit bg-blue-500">
            <div className="h-full flex flex-column align-items-center w-6rem">
                <Avatar icon="pi pi-stopwatch"
                        size="xlarge"
                        shape="circle"
                        className="mt-3 text-white border-3 border-white bg-blue-900 w-5rem h-5rem"
                />

                {/* Navigation buttons */ }
                <div className="flex flex-column flex-grow-1 pt-11 gap-5">
                    <Button icon="pi pi-home"
                            raised rounded
                            className="bg-blue-700 border-3 border-double border-white hover:bg-blue-500"
                            onClick={ () => navigate('/') }
                    />
                    { user?.role === 'Admin' &&
                        <Button icon="pi pi-database"
                                raised rounded
                                className="bg-blue-700 border-3 border-double border-white hover:bg-blue-500"
                                onClick={ () => navigate('/dashboard/manage-data') }
                        />
                    }
                    <Button icon="pi pi-envelope"
                            raised rounded
                            className="bg-blue-700 border-3 border-double border-white hover:bg-blue-500"
                    />
                </div>

                {/* User menu */ }
                <div className="py-5">
                    <TieredMenu model={ items } popup ref={ menu } />
                    <Button icon="pi pi-user"
                            aria-label="User"
                            rounded raised
                            className="bg-white text-blue-500 hover:bg-blue-100"
                            onClick={ (e) => menu.current?.toggle(e) }
                    />
                </div>
            </div>
        </div>
    );
}

export default Sidebar;