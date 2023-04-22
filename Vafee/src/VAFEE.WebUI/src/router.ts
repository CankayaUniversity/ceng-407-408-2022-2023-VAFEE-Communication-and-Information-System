import { createRouter, createWebHistory } from "vue-router";


const router = createRouter({
    routes: [
        { path: "/", component: () => import("./Pages/Home/Index.vue"), name: 'Home' },
    ],
    history: createWebHistory()
})


export default router;