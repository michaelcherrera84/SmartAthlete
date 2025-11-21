import { useAthlete } from '../../../hooks/Athlete.ts';
import { Divider } from 'primereact/divider';
import { DataTable } from 'primereact/datatable';
import { Column } from 'primereact/column';

type Props = {
    id: string;
};

function AthleteDetails({ id }: Props) {

    const { athlete, loadingAthlete } = useAthlete(id);

    if (loadingAthlete) return <p>Loading...</p>;
    if (!athlete) return <p>Athlete not found.</p>;

    return (
        <div className="flex gap-2 px-4">
            <div>
                <dl>
                    <div className="grid grid-cols-2 pb-4">
                        <dt className="font-bold w-7rem">Id</dt>
                        <dd>{ athlete.id }</dd>
                    </div>
                    <div className="grid grid-cols-2 pb-4">
                        <dt className="font-bold w-7rem">Date of Birth</dt>
                        <dd>{ athlete.dateOfBirth }</dd>
                    </div>

                    <div className="grid grid-cols-2 pb-4">
                        <dt className="font-bold w-7rem">Email</dt>
                        <dd>{ athlete.email }</dd>
                    </div>

                    <div className="grid grid-cols-2 pb-4">
                        <dt className="font-bold w-7rem">Sport</dt>
                        <dd>{ athlete.sport.name }</dd>
                    </div>

                    <div className="grid grid-cols-2 pb-4">
                        <dt className="font-bold w-7rem">Coach</dt>
                        <dd>{ athlete.coach.firstName + ' ' + athlete.coach.lastName } </dd>
                    </div>
                </dl>
            </div>
            <Divider layout="vertical" />
            <div>
                <DataTable value={ athlete.athleteInjuries }
                           scrollable
                           scrollHeight="500px"
                           tableStyle={{ maxWidth: '45rem', minWidth: '31rem'}}
                           emptyMessage="No reported injuries."
                >
                    <Column field="injury.type" header="Injury Type" style={{width: '9rem'}}/>
                    <Column field="date" header="Date" />
                    <Column field="description" header="Description" />
                </DataTable>
            </div>
        </div>
    );
}

export default AthleteDetails;