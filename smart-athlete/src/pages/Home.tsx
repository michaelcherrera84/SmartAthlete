import { usePageTitle } from '../hooks/Title.tsx';
import Sidebar from './shared/Sidebar.tsx';
import { Divider } from 'primereact/divider';
import { useCurrentUser } from '../hooks/CurrentUser.ts';

function Home() {
    usePageTitle('Dashboard');

    const {data: user} = useCurrentUser();

    return (
        <div id="wrapper" className="flex h-screen w-screen bg-gray-50 overflow-hidden">
            <Sidebar />
            <div className="flex flex-column h-full w-full overflow-y-auto overflow-x-hidden">
                <div className="text-gray-600 flex justify-content-between align-items-center px-8 pt-6">
                    <h1 className="m-0">Hello{ user ? ', ' + user.firstName : '!' }</h1>
                    <p className="m-0">{ user?.role ?? '' }</p>
                </div>
                <Divider className="mx-4 my-3" />
                <div id="main" className="flex flex-grow-1 flex-wrap gap-5 p-8 justify-content-center">
                    <h1>Welcome to Smart Athlete</h1>
                </div>
            </div>
        </div>
    );
}

export default Home;