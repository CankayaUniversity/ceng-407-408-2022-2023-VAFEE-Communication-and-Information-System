import { createRouter, createWebHistory } from 'vue-router';
import Landing from './Pages/Landing.vue';
import Profile from './Pages/Profile.vue';

const router = createRouter({
  routes: [
    {
      path: '/landing',
      name: 'home',
      component: Landing,
    },
    {
      path: '/profile',
      name: 'profile',
      component: Profile,
    },
  ],
  history: createWebHistory(),
});

export default router;
