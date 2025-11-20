import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import "./index.css";
import './App.css'
import { PrimeReactProvider } from "primereact/api";
import { RouterProvider } from "react-router";
import { router } from "./router/Routes.tsx";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import { ReactQueryDevtools } from '@tanstack/react-query-devtools';

const queryClient = new QueryClient();

createRoot(document.getElementById('root')!).render(
    <StrictMode>
        <QueryClientProvider client={ queryClient }>
            <PrimeReactProvider>
                <ReactQueryDevtools />
                <RouterProvider router={ router } />
            </PrimeReactProvider>
        </QueryClientProvider>
    </StrictMode>,
)
