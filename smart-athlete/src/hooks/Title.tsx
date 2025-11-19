import { useEffect } from "react";

/**
 * Custom hook to update the page title dynamically.
 * @param title - The new title to set.
 */
export function usePageTitle(title: string) {
    useEffect(() => {
        document.title = `Smart Athlete — ${title}`;
    }, [title]);
}