import axios from 'axios'
import {useAuthorizationStore} from '../stores/authorization';

function createInstance(url) {
	const authorization = useAuthorizationStore();
	let localAxios = axios.create({
		baseURL: url,
		headers: {
			'Content-Type': 'application/json',
			'Authorization': `Bearer ${authorization.token}`
		}
	});
	localAxios.interceptors.response.use(response => response, error => {
		if (error.response.status === 401) {
			authorization.setToken(null);
		}
		return Promise.reject(error);
	});
	return localAxios;
}

export default {
	install: (app) => {
		const axiosInstance = createInstance("http://localhost:5269");
		app.config.globalProperties.$axios = axiosInstance;
	}
}
