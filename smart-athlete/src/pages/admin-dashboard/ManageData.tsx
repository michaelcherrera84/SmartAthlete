import { Card } from 'primereact/card';
import Sidebar from '../shared/Sidebar.tsx';
import { usePageTitle } from '../../hooks/Title.tsx';
import { Link } from 'react-router';
import DashboardHeader from '../shared/DashboardHeader.tsx';

function ManageData() {
    usePageTitle('Manage Data');

    return (
        <div id="wrapper" className="flex h-screen w-screen bg-gray-50 overflow-hidden">
            <Sidebar />
            <div className="flex flex-column h-full w-full overflow-y-auto overflow-x-hidden">
                <DashboardHeader />
                <div id="main" className="flex flex-grow-1 flex-wrap gap-5 px-8 py-5">
                    <Card title="Athletes" className="w-20rem h-22rem hover:shadow-5">
                        <Link to="/dashboard/manage-data/athletes" className="text-lg">View</Link>
                    </Card>
                    <Card title="Athlete Injuries" className="w-20rem h-22rem hover:shadow-5"></Card>
                    <Card title="Coaches" className="w-20rem h-22rem hover:shadow-5"></Card>
                    <Card title="Sports" className="w-20rem h-22rem hover:shadow-5">
                        <Link to="/dashboard/manage-data/sports" className="text-lg">View</Link>
                    </Card>
                    <Card title="Injuries" className="w-20rem h-22rem hover:shadow-5">
                        <Link to="/dashboard/manage-data/injuries" className="text-lg">View</Link>
                    </Card>
                </div>
            </div>
        </div>
    );
}

export default ManageData;