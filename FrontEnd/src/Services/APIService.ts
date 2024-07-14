// src/services/apiService.ts

import axios from 'axios';

const API_URL = 'http://localhost:5249/api'; // Ajusta la URL a tu API

const apiService = {
    getAll: async (endpoint: string) => {
        const response = await axios.get(`${API_URL}/${endpoint}`);
        return response.data;
    },
    getById: async (endpoint: string, id: number) => {
        const response = await axios.get(`${API_URL}/${endpoint}/${id}`);
        return response.data;
    },
    create: async (endpoint: string, data: any) => {
        const response = await axios.post(`${API_URL}/${endpoint}`, data);
        return response.data;
    },
    update: async (endpoint: string, id: number, data: any) => {
        const response = await axios.put(`${API_URL}/${endpoint}/${id}`, data);
        return response.data;
    },
    delete: async (endpoint: string, id: number) => {
        const response = await axios.delete(`${API_URL}/${endpoint}/${id}`);
        return response.data;
    }
};

export default apiService;
