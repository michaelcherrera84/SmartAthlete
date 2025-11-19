import { createBrowserRouter } from "react-router";
import App from "../App.tsx";
import Home from "../pages/Home.tsx";
import Login from "../pages/Login.tsx";
import RequireAuth from "./RequireAuth.tsx";

export const router = createBrowserRouter([
    {
        path: '/',
        element: <App />,
        children: [
            {
                element: <RequireAuth />, children: [
                    { path: '', element: <Home /> },
                ],
            },
            { path: 'login', element: <Login /> },
        ],
    },
]);