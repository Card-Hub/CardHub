// router.ts
import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router';
// import type { RouteRecordRaw } from 'vue-router';
import Join from './pages/Join.vue';
// import Home from './pages/Home.vue';
// import Gameboard from './pages/Gameboard.vue';

const routes: Array<RouteRecordRaw> = [
    {
        path: '/join',
        name: 'Join',
        component: Join,
    },
    // Add other routes as needed
    {
        path: '/',
        name: 'Home',
        component: () => import('./pages/Home.vue'),
    },
    {
        path: '/gameboard',
        name: 'Gameboard',
        component: () => import('./pages/Gameboard.vue'),
    },
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;
