import { usePageTitle } from '../hooks/Title.tsx';
import Sidebar from './shared/Sidebar.tsx';
import { useCurrentUser } from '../hooks/CurrentUser.ts';
import TriCarousel from './shared/TriCarousel.tsx';

function Home() {
    usePageTitle('Dashboard');

    const { data: user } = useCurrentUser();
    const images = [
        { src: 'images/injuries/injury001.png', alt: 'Injury1' },
        { src: 'images/injuries/injury002.png', alt: 'Injury1' },
        { src: 'images/injuries/injury003.png', alt: 'Injury1' },
    ];

    return (
        <div id="wrapper" className="flex h-screen w-screen bg-gray-50 overflow-hidden">
            <Sidebar />
            <div className="flex flex-column h-full w-full overflow-y-auto overflow-x-hidden">
                <div className="text-gray-600 flex justify-content-between align-items-center px-8 pt-6">
                    <h1 className="m-0">Hello{ user ? ', ' + user.firstName : '!' }</h1>
                    <p className="m-0">{ user?.role ?? '' }</p>
                </div>
                <div className="mx-5 my-2 border-1 border-gray-300"></div>
                <div id="main" className="flex flex-column flex-grow-1 p-8 align-items-center text-gray-600">
                    <h1 className="m-0 edu-nsw-act-hand-pre-700">Welcome to Smart Athlete</h1>
                    <h3 className="edu-nsw-act-hand-pre-400 m-0">Helping coaches, trainers, and sports programs manage
                        athletes and their injuries.</h3>
                    <div className="mt-7">
                        <TriCarousel images={ images } intervalMs={ 10000 } />
                    </div>
                </div>
            </div>
        </div>
    );
}

export default Home;