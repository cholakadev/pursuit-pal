import axios from 'axios';

const API_BASE_URL = 'https://api.example.com';

const apiService = axios.create({
  baseURL: API_BASE_URL,
});

// export const register = async () => {
//   try {
//     const response = await apiService.get('/someEndpoint');
//     console.log('hit');
//     return response.data;
//   } catch (error) {
//     throw error;
//   }
// };