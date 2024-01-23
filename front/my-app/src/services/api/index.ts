import { Client } from './client';
import { Axios, AxiosInstance } from 'axios';

const axios = new Axios({
  headers: {
    'Authorization': 'Bearer ' + localStorage.getItem('accessToken'),
  }
})

export const client = new Client('http://localhost:7243', axios);

// import axios from 'axios';
// const axiosConfig = {
//   headers: {
//     'Authorization': 'Bearer ' + localStorage.getItem('accessToken'),
//   }
// };

// const axiosInstance: AxiosInstance = axios.create(axiosConfig);

// export const client = new Client('http://localhost:7243', axiosInstance);
