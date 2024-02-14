// import axios from 'axios';
// const axiosConfig = {
//   headers: {
//     'Authorization': 'Bearer ' + localStorage.getItem('accessToken'),
//   }
// };

// const axiosInstance: AxiosInstance = axios.create(axiosConfig);

// export const client = new Client('http://localhost:7243', axiosInstance);

import axios from 'axios';

const API_URL = 'http://localhost:7243/api';

const axiosInstance = axios.create({
  baseURL: API_URL,
});

// Add a request interceptor
axiosInstance.interceptors.request.use(
  (config) => {
    const token = localStorage.getItem('accessToken');
    if (token) {
      config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
  },
  (error) => Promise.reject(error)
);

export default axiosInstance;