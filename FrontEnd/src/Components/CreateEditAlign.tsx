// src/components/MetaAlineamientoForm.tsx

import React, { useState, useEffect } from 'react';
import apiService from '../Services/APIService.ts';

interface MetaAlineamientoFormProps {
    id?: number;
}

const MetaAlineamientoForm: React.FC<MetaAlineamientoFormProps> = ({ id }) => {
    const [metaAlineamiento, setMetaAlineamiento] = useState({ codigo: '', descripcion: '' });

    useEffect(() => {
        if (id) {
            fetchMetaAlineamiento(id);
        }
    }, [id]);

    const fetchMetaAlineamiento = async (id: number) => {
        const data = await apiService.getById('MetaAlineamiento', id);
        setMetaAlineamiento(data);
    };

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setMetaAlineamiento({ ...metaAlineamiento, [e.target.name]: e.target.value });
    };

    const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        if (id) {
            await apiService.update('MetaAlineamiento', id, metaAlineamiento);
        } else {
            await apiService.create('MetaAlineamiento', metaAlineamiento);
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <div>
                <label>Codigo:</label>
                <input type="text" name="codigo" value={metaAlineamiento.codigo} onChange={handleChange} />
            </div>
            <div>
                <label>Descripcion:</label>
                <input type="text" name="descripcion" value={metaAlineamiento.descripcion} onChange={handleChange} />
            </div>
            <button type="submit">Save</button>
        </form>
    );
};

export default MetaAlineamientoForm;
