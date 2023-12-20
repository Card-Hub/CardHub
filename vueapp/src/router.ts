// Rubi Dionisio Created the routing, here is the code for that
// sources: https://vuejs.org/guide/scaling-up/routing.html

import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router';
// import type { RouteRecordRaw } from 'vue-router';
import Join from './pages/Join.vue';

const routes: Array<RouteRecordRaw> = [
    {
        path: '/join',
        name: 'Join',
        component: Join,
    },
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
    // {
    //     path: '/host',
    //     name: 'Host',
    //     component: () => import('./pages/Host.vue'),
    // },
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;
