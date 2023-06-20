import MainPageVue from '@/components/Landing/MainPage.vue';
import MainPageRegistered from '@/components/Landing/MainPageRegistered.vue';
import { createRouter, createWebHistory } from 'vue-router';


const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      // component: MainPageVue,
      component: MainPageRegistered,
    },
  ]
})

export default router
