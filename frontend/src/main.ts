import { createApp, provide, h } from 'vue'
import { DefaultApolloClient } from '@vue/apollo-composable'
import { createPinia } from 'pinia'

import App from './App.vue'
import router from './router'
import PrimeVue from 'primevue/config';
import FocusTrap from 'primevue/focustrap';
import { apolloClient } from './ApolloGQL/apollo'

import './assets/main.css'

const app = createApp({
    setup () {
      provide(DefaultApolloClient, apolloClient)
    },
  
    render: () => h(App),
  })

app.use(createPinia())
app.use(router)
app.use(PrimeVue);
app.directive('focustrap', FocusTrap);
app.mount('#app')
