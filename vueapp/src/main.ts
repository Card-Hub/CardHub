// import './assets/main.css'
//
// import { createApp } from 'vue'
// import App from './App.vue'
// // import join from './pages/join.vue'
// // import Gameboard from './pages/Gameboard.vue'
// import Home from './pages/Home.vue'
//
// createApp(Home).mount('#app')

import { createApp } from 'vue';
import App from './App.vue';
import router from './router';

createApp(App).use(router).mount('#app');