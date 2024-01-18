import axios from 'axios';

const Users = {
	async uploadAvatar(file: File): Promise<boolean> {
		 const formData = new FormData();
		 formData.append('file', file);
		 const response = await axios.post('/users/avatar', formData).then(x => x.data);
		 return response.success;
	},

	async deleteAvatar(): Promise<boolean> {
		 const response = await axios.delete('/users/avatar').then(x => x.data);
		 return response.success;
	}
}

export default Users;
