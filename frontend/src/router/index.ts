import MainPageVue from '@/components/Landing/MainPage.vue';
import NoteItemVue from '@/components/Notes/NoteItem.vue';
import { createRouter, createWebHistory} from 'vue-router';


const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: MainPageVue,
    },
    {
      path: '/notes',
      name: 'notes',
      component: NoteItemVue,
    },
  ]
})

export default router
