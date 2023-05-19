import {createRouter, createWebHistory} from 'vue-router'
import HomeView from '../views/HomeView.vue'
import LoginView from '../views/LoginView.vue'
import RegistrationView from '../views/authentication/RegistrationView.vue'

const router = createRouter({
	history: createWebHistory(import.meta.env.BASE_URL),
	base: '/',
	routes: [
		{
			path: '/',
			redirect: '/home'
		},
		{
			path: '/home',
			name: 'home',
			component: () => import("../views/HomeView.vue")
		},
		{
			path: '/login',
			name: 'login',
			component: () => import("../views/LoginView.vue")
		},
		{
			path: '/registration',
			name: 'registration',
			component: () => import("../views/authentication/RegistrationView.vue")
		},
		{
			path: '/about',
			name: 'about',
			// route level code-splitting
			// this generates a separate chunk (About.[hash].js) for this route
			// which is lazy-loaded when the route is visited.
			component: () => import('../views/AboutView.vue')
		}
	]
})

router.beforeEach((to, from, next) => {
	let isAuthenticated = localStorage.getItem('token') != null;
	if (to.name !== 'login' && to.name !== 'registration' && !isAuthenticated) {
		console.log("Redirect to login");
		next('/login')
	}
	else if ((to.name === 'login' || to.name === 'registration') && isAuthenticated) {
		next('/home');
	}
	else {
		next();
	}
})

export default router
