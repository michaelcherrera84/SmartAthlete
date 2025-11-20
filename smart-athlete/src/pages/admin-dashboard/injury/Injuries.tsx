import { usePageTitle } from '../../../hooks/Title.tsx';
import { useInjury } from '../../../hooks/Injury.ts';
import Sidebar from '../../shared/Sidebar.tsx';
import DashboardHeader from '../../shared/DashboardHeader.tsx';
import { Card } from 'primereact/card';
import { DataTable } from 'primereact/datatable';
import { Column } from 'primereact/column';

function Injuries() {
    usePageTitle('Injuries');

    const { injuries, loadingInjuries, injuriesError } = useInjury();

    if (loadingInjuries) return <p>Loading...</p>;
    if (injuriesError) return <p>Error loading injuries.</p>;

    return (
        <div id="wrapper" className="flex h-screen w-screen bg-gray-50 overflow-hidden">
            <Sidebar />
            <div className="flex flex-column h-full w-full overflow-y-auto overflow-x-hidden">
                <DashboardHeader title="Injuries" />
                <div id="main" className="flex justify-content-center px-8 py-5">
                    <Card className="w-6 h-fit">
                        <DataTable value={ injuries } size="large" className="w-full" rowHover>
                            <Column field="id" header="ID" />
                            <Column field="type" header="Type" />
                        </DataTable>
                    </Card>
                </div>
            </div>
        </div>
    );
}

export default Injuries;