import { createApp } from 'vue';
import Routing from './pages/Routing.vue';
import router from './router';

createApp(Routing).use(router).mount('#app');