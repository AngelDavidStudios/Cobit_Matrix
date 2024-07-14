// src/components/MetaAlineamientoList.tsx

import React, { useEffect, useState } from 'react';
import apiService from '../Services/APIService.ts';

const MetaAlineamientoList: React.FC = () => {
    const [metaAlineamientos, setMetaAlineamientos] = useState([]);

    useEffect(() => {
        fetchMetaAlineamientos();
    }, []);

    const fetchMetaAlineamientos = async () => {
        const data = await apiService.getAll('MetaAlineamiento');
        setMetaAlineamientos(data);
    };

    const handleDelete = async (id: number) => {
        await apiService.delete('MetaAlineamiento', id);
        fetchMetaAlineamientos();
    };

    return (
        <div>
            <h2>Meta Alineamientos</h2>
            <ul>
                {metaAlineamientos.map((metaAlineamiento: any) => (
                    <li key={metaAlineamiento.idAlineamiento}>
                        {metaAlineamiento.descripcion}
                        <button onClick={() => handleDelete(metaAlineamiento.idAlineamiento)}>Delete</button>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default MetaAlineamientoList;
