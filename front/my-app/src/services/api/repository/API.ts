import axiosInstance from '../';
import { APIRequestBase } from '../../../models/api/request/base/APIRequestBase';
import { ErrorModel } from '../../../models/api/response/base/ErrorModel';
import { PagedRequest } from '../../../models/api/request/base/PagedRequest';
import axios from 'axios';

interface APIResponse<T> {
	success: boolean;
	data?: T;
	error?: ErrorModel;
}

export const API = {
	get: async <TResponse>(url: string): Promise<APIResponse<TResponse>> => {
		 try {
			  const response = await axiosInstance.get<TResponse>(url);
			  return { success: true, data: response.data };
		 } catch (error: any) {
			  return { success: false, error: error.response?.data };
		 }
	},

	
	post: async <TRequest extends APIRequestBase, TResponse>(
		url: string,
		data: TRequest,
		headers?: { [key: string]: string }
  		): Promise<APIResponse<TResponse>> => {
		try {
			const response = await axios.post<TResponse>('http://localhost:7243/api' + url, data, {
				headers: {
					 'Authorization': 'Bearer ' + localStorage.getItem('accessToken'),
					 ...headers
				}
		  });
			 return { success: true, data: response.data };
		} catch (error: any) {
			console.error(error);
			return { success: false, error: error.response?.data };
		}
  },

	put: async <TRequest extends APIRequestBase, TResponse>(
        url: string,
        data: TRequest
    ): Promise<APIResponse<TResponse>> => {
        try {
            const response = await axiosInstance.put<TResponse>(url, data);
            return { success: true, data: response.data };
        } catch (error: any) {
            return { success: false, error: error.response?.data };
        }
    },

    delete: async <TResponse>(url: string): Promise<APIResponse<TResponse>> => {
        try {
            const response = await axiosInstance.delete<TResponse>(url);
            return { success: true, data: response.data };
        } catch (error: any) {
            return { success: false, error: error.response?.data };
        }
    },
};

export default API;