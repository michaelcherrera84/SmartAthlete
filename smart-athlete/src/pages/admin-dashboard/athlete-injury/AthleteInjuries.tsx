import { usePageTitle } from '../../../hooks/Title.tsx';
import { useAthleteInjury } from '../../../hooks/AthleteInjury.ts';
import Sidebar from '../../shared/Sidebar.tsx';
import DashboardHeader from '../../shared/DashboardHeader.tsx';
import { Card } from 'primereact/card';
import { DataTable, type DataTableFilterMeta } from 'primereact/datatable';
import { Column } from 'primereact/column';
import { useState } from 'react';
import { FilterMatchMode } from 'primereact/api';
import { IconField } from 'primereact/iconfield';
import { InputIcon } from 'primereact/inputicon';
import { InputText } from 'primereact/inputtext';

function AthleteInjuries() {
    usePageTitle('Athlete Injuries');

    const { athleteInjuries, loadingAthleteInjuries, athleteInjuriesError } = useAthleteInjury();
    const [filters, setFilters] = useState<DataTableFilterMeta>({
        global: { value: null, matchMode: FilterMatchMode.CONTAINS },
    });
    const [globalFilter, setGlobalFilter] = useState('');

    if (loadingAthleteInjuries) return <p>Loading...</p>;
    if (athleteInjuriesError) return <p>Error loading athlete injuries.</p>;

    return (
        <div id="wrapper" className="flex h-screen w-screen bg-gray-50 overflow-hidden">
            <Sidebar />
            <div className="flex flex-column h-full w-full overflow-y-auto overflow-x-hidden">
                <DashboardHeader title="Athlete Injuries" />
                <div id="main" className="flex justify-content-center px-8 py-5">
                    <Card id="card" className="w-full" pt={{body: {style: {paddingTop: '0'}}}}>
                        <div className="flex justify-content-end">
                            <IconField iconPosition="left" className="mb-3">
                                <InputIcon className="pi pi-search" />
                                <InputText value={ globalFilter }
                                           onChange={ (e) => {
                                               const value = e.target.value;

                                               setFilters((prev) => ({
                                                   ...prev,
                                                   global: { ...prev.global, value },
                                               }));

                                               setGlobalFilter(value);
                                           } }
                                           placeholder="Search"
                                           className="h-2rem w-15rem"
                                />
                            </IconField>
                        </div>
                        <DataTable value={ athleteInjuries }
                                   scrollable
                                   scrollHeight="650px"
                                   size="large"
                                   filters={ filters }
                                   globalFilterFields={ [
                                       'athlete.firstName',
                                       'athlete.lastName',
                                       'injury.type',
                                       'date',
                                       'description',
                                   ] }
                                   className="w-full"
                                   rowHover
                        >
                            <Column field="athlete.firstName" header="First Name" />
                            <Column field="athlete.lastName" header="Last Name" />
                            <Column field="injury.type" header="Injury Type" style={ { width: '9rem' } } />
                            <Column field="date" header="Date" />
                            <Column field="description" header="Description" />
                        </DataTable>
                    </Card>
                </div>
            </div>
        </div>
    );
}

export default AthleteInjuries;