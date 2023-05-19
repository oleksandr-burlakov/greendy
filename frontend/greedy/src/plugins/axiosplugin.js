import axios from 'axios'

function createInstance(url) {
	return axios.create({
		baseURL: url,
		headers: {
			'Content-Type': 'application/json',
			'Authorization': `Bearer ${localStorage.getItem('token')}`
		}
	});
}

export default {
	install: (app) => {
		const axiosInstance = createInstance("http://localhost:5269");
		axiosInstance.interceptors.response.use(response => response, error => {
			if (error.response.status === 401) {
				localStorage.removeItem('token');
			}
			return Promise.reject(error);
		});
		app.config.globalProperties.$axios = axiosInstance;
	}
};
