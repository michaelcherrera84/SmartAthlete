import { useEffect, useState } from 'react';
import { Image } from 'primereact/image';

interface TriShowcaseProps {
    images: { src: string; alt?: string }[];
    intervalMs?: number;
}

export default function TriShowcase({ images, intervalMs = 4000 }: TriShowcaseProps) {
    const count = images.length;
    const [current, setCurrent] = useState(0);

    useEffect(() => {
        const timer = window.setInterval(() => {
            setCurrent((c) => (c + 1) % count);
        }, intervalMs);
        return () => window.clearInterval(timer);
    }, [count, intervalMs]);

    // Compute indexes for left, center, right
    const left = (current - 1 + count) % count;
    const right = (current + 1) % count;

    return (
        <div className="flex">
            <Image src={ images[left].src }
                   alt={ images[left].alt }
                   width="600"
                   imageClassName="border-round-3xl shadow-5 opacity-50"
                   style={ {
                       translate: '200px 100px',
                       transform: 'scale(0.85)',
                   } }
            />
            <Image src={ images[current].src }
                   alt={ images[current].alt }
                   width="600"
                   imageClassName="border-blue-300 border-round-3xl shadow-8"
                   className="z-5"
            />
            <Image src={ images[right].src }
                   alt={ images[right].alt }
                   width="600"
                   imageClassName="border-round-3xl shadow-5 opacity-50"
                   style={ {
                       translate: '-200px 100px',
                       transform: 'scale(0.85)',
                   } }
            />
        </div>
    );
}