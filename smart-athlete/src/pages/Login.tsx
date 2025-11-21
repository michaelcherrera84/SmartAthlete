import { usePageTitle } from '../hooks/Title.tsx';
import { Card } from 'primereact/card';
import { Button } from 'primereact/button';
import { InputText } from 'primereact/inputtext';
import { useMutation /*useQueryClient*/ } from '@tanstack/react-query';
import { useLocation, useNavigate } from 'react-router';
import { login } from '../queries/userQueries.ts';
import { Message } from 'primereact/message';
import { useState } from 'react';

function Login() {
    usePageTitle('Login');

    const [error, setError] = useState<string | null>(null);

    const navigate = useNavigate();
    const location = useLocation();

    // Get the previous page from the location state.
    const from = location.state?.from?.pathname || '/';

    // Custom hook to handle login mutation.
    const mutation = useMutation({
        mutationFn: login,
        onSuccess: (data) => {
            console.log('Login successful', data);
            setError(null);
            navigate(from, { replace: true });
        },
        onError: (err) => {
            console.error('Login failed', err);
            setError('Invalid username or password');
        },
    });

    // Background image style
    const backgroundStyle = {
        backgroundImage: 'url(\'images/login-background.jpg\')',
        backgroundSize: 'cover', // Ensures the image covers the entire element
        backgroundPosition: 'center', // Centers the image
        backgroundRepeat: 'no-repeat', // Prevents image repetition
        minHeight: '100vh', // Ensures the background covers the full viewport height
    };

    /**
     * Handle form submission.
     * @param e - The form submission event.
     */
    const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        const form = e.currentTarget;
        const formData = new FormData(form);


        // Call the login mutation with the form data.
        mutation.mutate({
            username: formData.get('username') as string,
            passwordHash: formData.get('password') as string,
        });
    };

    return (
        <div id="wrapper"
             className="w-full h-screen flex flex-column justify-content-center align-items-center"
             style={ backgroundStyle }
        >
            {/* Login form */ }
            <form onSubmit={ handleSubmit }>
                <Card title="Welcome"
                      subTitle="Please log in to continue"
                      footer={
                          <Button type="submit"
                                  label="Log In"
                                  className="w-full hover:bg-blue-600 move-on-hover"
                                  rounded
                                  raised
                          />
                      }
                      className="w-36rem px-11 py-5 text-center fadeinup animation-duration-500 border-round-3xl bg-white-alpha-90"
                >
                    <div className="flex flex-column gap-3">
                        <InputText type="text" placeholder="Username" name="username" />
                        <InputText type="password" placeholder="Password" name="password" />
                        { error && <Message severity="error" text={ error } /> }
                    </div>
                </Card>
            </form>
            {/* Credits */ }
            <div className="fixed bottom-0 left-0 pl-3 pr-5 pb-1 link-gradient">
                <a href="https://www.vecteezy.com/free-photos/sports-background"
                   target="_blank"
                   rel="noopener noreferrer"
                   className="text-white-alpha-30 font-italic"
                >
                    Sports Background Stock photos by Vecteezy
                </a>
            </div>
        </div>
    );
}

export default Login;