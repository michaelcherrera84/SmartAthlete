import { useCurrentUser } from '../../hooks/CurrentUser.ts';
import { Divider } from 'primereact/divider';
import { Button } from 'primereact/button';
import { useLocation, useNavigate } from 'react-router';

type Props = {
    title?: string;
}

function DashboardHeader({ title }: Props) {
    const { data: user } = useCurrentUser();
    const location = useLocation();
    const navigate = useNavigate();

    return (
        <>
            <div className="text-gray-600 flex justify-content-between align-items-center px-8 pt-6">
                { location.pathname == '/dashboard/manage-data' ? (
                    <h1 className="m-0">Dashboard</h1>
                ) : (
                    <Button label="Dashboard"
                            icon="pi pi-angle-left"
                            className="p-button-text text-gray-700 w-9rem"
                            onClick={ () => navigate('/dashboard/manage-data')}
                    />
                ) }
                <h1 className="m-0">{ title }</h1>
                <p className="m-0 w-9rem text-right">{ user?.role ?? '' }</p>
            </div>
            <Divider className="mx-4 my-3" />
        </>
    );
}

export default DashboardHeader;