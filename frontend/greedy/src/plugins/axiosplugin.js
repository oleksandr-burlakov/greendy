import axios from 'axios'
import {useAuthorizationStore} from '../stores/authorization';
import router from '../router/index';

function createInstance(url) {
	const authorization = useAuthorizationStore();
	let localAxios = axios.create({
		baseURL: url,
		headers: {
			'Content-Type': 'application/json',
		}
	});
	localAxios.interceptors.request.use(
		(config) => {
			const token = authorization.token;
			if (token) {
				config.headers['Authorization'] = `Bearer ${token}`;
			}
			return config;
		},
		(error) => {
			return Promise.reject(error);
		}
	)
	localAxios.interceptors.response.use(response => response, error => {
		if (error.response.status === 401) {
			authorization.setToken(null);
			router.push('/');
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
