import { usePageTitle } from '../../../hooks/Title.tsx';
import DashboardHeader from '../../shared/DashboardHeader.tsx';
import Sidebar from '../../shared/Sidebar.tsx';
import { DataTable } from 'primereact/datatable';
import { Column } from 'primereact/column';
import { useSport } from '../../../hooks/Sport.ts';
import { Card } from 'primereact/card';

function Sports() {
    usePageTitle('Sports');

    const { sports, loadingSports, sportsError } = useSport();

    if (loadingSports) return <p>Loading...</p>;
    if (sportsError) return <p>Error loading sports.</p>;

    return (
        <div id="wrapper" className="flex h-screen w-screen bg-gray-50 overflow-hidden">
            <Sidebar />
            <div className="flex flex-column h-full w-full overflow-y-auto overflow-x-hidden">
                <DashboardHeader title="Sports" />
                <div id="main" className="flex justify-content-center px-8 py-5">
                    <Card className="w-6 h-fit">
                        <DataTable value={ sports } size="large" className="w-full">
                            <Column field="id" header="ID" />
                            <Column field="name" header="Name" />
                        </DataTable>
                    </Card>
                </div>
            </div>
        </div>
    );
}

export default Sports;