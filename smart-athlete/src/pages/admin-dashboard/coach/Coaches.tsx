import { usePageTitle } from '../../../hooks/Title.tsx';
import Sidebar from '../../shared/Sidebar.tsx';
import DashboardHeader from '../../shared/DashboardHeader.tsx';
import { Card } from 'primereact/card';
import { DataTable } from 'primereact/datatable';
import { Column } from 'primereact/column';
import { useCoach } from '../../../hooks/Coach.ts';
import { useState } from 'react';
import { Dialog } from 'primereact/dialog';
import CoachDetails from './CoachDetails.tsx';

function Coaches() {
    usePageTitle('Coaches');

    const { coaches, loadingCoaches, coachesError } = useCoach();
    const [selectedCoach, setSelectedCoach] = useState<string | null>(null);

    if (loadingCoaches) return <p>Loading...</p>;
    if (coachesError) return <p>Error loading athlete.</p>;

    return (
        <div id="wrapper" className="flex h-screen w-screen bg-gray-50 overflow-hidden">
            <Sidebar />
            <div className="flex flex-column h-full w-full overflow-y-auto overflow-x-hidden">
                <DashboardHeader title="Coaches" />
                <div id="main" className="flex justify-content-center px-8 py-5">
                    <Card className="w-10 h-fit">
                        <DataTable value={ coaches }
                                   size="large"
                                   className="w-full"
                                   rowHover
                                   onRowClick={ (e) => setSelectedCoach(e.data.id) }
                        >
                            <Column field="firstName" header="First Name" />
                            <Column field="middleName" header="Middle Name" />
                            <Column field="lastName" header="Last Name" />
                            <Column field="dateOfBirth" header="Date of Birth" dataType="date" />
                            <Column field="email" header="Email" />
                        </DataTable>
                        <Dialog header={ coaches?.find(coach => coach.id === selectedCoach)?.firstName + ' '
                            + coaches?.find(coach => coach.id === selectedCoach)?.middleName + ' '
                            + coaches?.find(coach => coach.id === selectedCoach)?.lastName }
                                visible={ !!selectedCoach }
                                onHide={ () => setSelectedCoach(null) }
                        >
                            <CoachDetails id={ selectedCoach! } />
                        </Dialog>
                    </Card>
                </div>
            </div>
        </div>
    );
}

export default Coaches;