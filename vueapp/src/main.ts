import { createApp } from 'vue';
import Routing from './pages/Routing.vue';

import 'primevue/resources/themes/soho-dark/theme.css'; // theme
import 'primevue/resources/primevue.min.css';
import 'primeicons/primeicons.css';

import Button from 'primevue/button';

import router from './router';

const app = createApp(Routing);
app.component('Button', Button);

app.use(router).mount('#app');