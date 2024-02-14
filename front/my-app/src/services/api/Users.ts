import axios from 'axios';
import API from './repository/API';

export type UpdateUserInfo = { [key: string]: string }

const Users = {
	async uploadAvatar(file: File): Promise<boolean> {
		 const formData = new FormData();
		 formData.append('file', file);
		 const response = await API.post('/user/upload-avatar', formData, { 'Content-Type': 'multipart/form-data' });
		 return response.success;
	},

	async addImage (file: File): Promise<boolean> {
		await fetch('http://localhost:7243/user/upload-avatar',
		{
			method: 'POST',
			mode: 'cors',
			headers: {
				'Authorization': 'bearer ' + localStorage.getItem('accessToken'),
				'Accept': 'application/json',
			},
			body: file
		});
		return true;
	},

	async deleteAvatar(): Promise<boolean> {
		//  const response = await axios.delete('/users/avatar').then(x => x.data);
		const response = await API.delete('/user/delete-avatar');
		 return response.success;
	},

	async updateInfo(requestBody: UpdateUserInfo): Promise<any> {
		const response = await API.put('/users/me', requestBody);
		return response.success;
  },
}


export default Users;
