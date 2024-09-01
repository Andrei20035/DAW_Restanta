import axios from 'axios';

const api = axios.create({
  baseURL: 'https://localhost:44330/api',
});

export const getProducts = async () => {
  try {
    const response = await api.get('/products');
    return response.data;
  } catch (error) {
    console.error('Error fetching products:', error);
    throw error;
  }
};
