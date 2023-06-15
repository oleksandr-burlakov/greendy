import { createRouter, createWebHistory } from 'vue-router'
import { useAuthorizationStore } from '../stores/authorization'

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
      component: () => import('../views/HomeView.vue')
    },
    {
      path: '/login',
      name: 'login',
      component: () => import('../views/LoginView.vue')
    },
    {
      path: '/registration',
      name: 'registration',
      component: () => import('../views/authentication/RegistrationView.vue')
    },
    {
      path: '/tasks',
      name: 'tasks',
      children: [
        {
          path: '',
          name: 'general',
          component: () => import('../views/tasks/GeneralTaskView.vue')
        }
      ]
    }
  ]
})

router.beforeEach((to, from, next) => {
  const authorization = useAuthorizationStore()
  let isAuthenticated = authorization.token != null
  if (to.name !== 'login' && to.name !== 'registration' && !isAuthenticated) {
    next('/login')
  } else if ((to.name === 'login' || to.name === 'registration') && isAuthenticated) {
    next('/home')
  } else {
    next()
  }
})

export default router
