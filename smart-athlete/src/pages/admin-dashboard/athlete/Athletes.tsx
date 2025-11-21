import { usePageTitle } from '../../../hooks/Title.tsx';
import { useAthlete } from '../../../hooks/Athlete.ts';
import Sidebar from '../../shared/Sidebar.tsx';
import DashboardHeader from '../../shared/DashboardHeader.tsx';
import { Card } from 'primereact/card';
import { DataTable } from 'primereact/datatable';
import { Column } from 'primereact/column';
import { useState } from 'react';
import { Dialog } from 'primereact/dialog';
import AthleteDetails from './AthleteDetails.tsx';

function Athletes() {
    usePageTitle('Athletes');

    const { athletes, loadingAthletes, athletesError } = useAthlete();
    const [selectedAthlete, setSelectedAthlete] = useState<string | null>(null);

    if (loadingAthletes) return <p>Loading...</p>;
    if (athletesError) return <p>Error loading athlete.</p>;

    return (
        <div id="wrapper" className="flex h-screen w-screen bg-gray-50 overflow-hidden">
            <Sidebar />
            <div className="flex flex-column h-full w-full overflow-y-auto overflow-x-hidden">
                <DashboardHeader title="Athletes" />
                <div id="main" className="flex justify-content-center px-8 py-5">
                    <Card className="w-10 h-fit">
                        <DataTable value={ athletes }
                                   size="large"
                                   className="w-full"
                                   rowHover
                                   onRowClick={ (e) => setSelectedAthlete(e.data.id) }
                        >
                            <Column field="firstName" header="First Name" />
                            <Column field="middleName" header="Middle Name" />
                            <Column field="lastName" header="Last Name" />
                            <Column field="dateOfBirth" header="Date of Birth" dataType="date" />
                            <Column field="email" header="Email" />
                        </DataTable>
                        <Dialog header={ athletes?.find(athlete => athlete.id === selectedAthlete)?.firstName + ' '
                            + athletes?.find(athlete => athlete.id === selectedAthlete)?.middleName + ' '
                            + athletes?.find(athlete => athlete.id === selectedAthlete)?.lastName }
                                visible={ !!selectedAthlete }
                                onHide={ () => setSelectedAthlete(null) }
                        >
                            <AthleteDetails id={ selectedAthlete! } />
                        </Dialog>
                    </Card>
                </div>
            </div>
        </div>
    );
}

export default Athletes;