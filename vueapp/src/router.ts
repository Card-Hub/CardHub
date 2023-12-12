// router.ts
import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router';
// import type { RouteRecordRaw } from 'vue-router';
import Join from './pages/Join.vue';

const routes: Array<RouteRecordRaw> = [
    {
        path: '/join',
        name: 'Join',
        component: Join,
    },
    // Add other routes as needed
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;
