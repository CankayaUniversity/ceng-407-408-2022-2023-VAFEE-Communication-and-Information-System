import { createRouter, createWebHistory } from 'vue-router';
import Landing from './Pages/Landing.vue';

const router = createRouter({
  routes: [
    {
      path: '/landing',
      name: 'home',
      component: Landing,
    },
  ],
  history: createWebHistory(),
});

export default router;
