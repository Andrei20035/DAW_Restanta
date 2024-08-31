﻿import axios from 'axios';

const api = axios.create({
    baseURL: 'https://localhost:44330/api',
});

export const registerUser = async (userData) => {
    try {
        const response = await api.post('/auth/register', userData);
        return response.data;
    } catch (error) {
        console.error('Error registering user:', error);
        throw error;
    }
};
