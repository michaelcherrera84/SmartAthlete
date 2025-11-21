import { useCoach } from '../../../hooks/Coach.ts';

type Props = {
    id: string;
};

function CoachDetails({ id }: Props) {

    const { coach, loadingCoach } = useCoach(id);

    if (loadingCoach) return <p>Loading...</p>;
    if (!coach) return <p>Coach not found.</p>;

    return (
        <div className="px-4">
            <dl>
                <div className="grid grid-cols-2 pb-4">
                    <dt className="font-bold w-7rem">Id</dt>
                    <dd>{ coach.id }</dd>
                </div>

                <div className="grid grid-cols-2 pb-4">
                    <dt className="font-bold w-7rem">Date of Birth</dt>
                    <dd>{ coach.dateOfBirth }</dd>
                </div>

                <div className="grid grid-cols-2 pb-4">
                    <dt className="font-bold w-7rem">Email</dt>
                    <dd>{ coach.email }</dd>
                </div>

                <div className="grid grid-cols-2 pb-4">
                    <dt className="font-bold w-7rem">Sport</dt>
                    <dd>{ coach.sport.name }</dd>
                </div>
            </dl>
        </div>
    );
}

export default CoachDetails;