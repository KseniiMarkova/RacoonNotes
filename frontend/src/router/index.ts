import MainPageVue from '@/components/Landing/MainPage.vue';
import NoteItemVue from '@/components/Notes/NoteItem.vue';
import MainDailyPageVue from '@/components/DailyPages/MainDailyPage.vue';
import MainMonthlyPageVue from '@/components/MonthlyPages/MainMonthlyPage.vue';
import MainWeeklyPageVue from '@/components/WeeklyPages/MainWeeklyPage.vue';
import ListOfNotesVue from '@/components/Notes/ListOfNotes.vue';
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
      path: '/month',
      name: 'month',
      component: MainMonthlyPageVue,
    },
    {
      path: '/week',
      name: 'week',
      component: MainWeeklyPageVue,
    },
    {
      path: '/day',
      name: 'day',
      component: MainDailyPageVue,
    },
    {
      path: '/notes',
      name: 'notes',
      component: NoteItemVue,
    },
    {
      path: '/list',
      name: 'list',
      component: ListOfNotesVue,
    },
  ]
})

export default router
