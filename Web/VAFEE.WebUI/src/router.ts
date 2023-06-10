import { createRouter, createWebHistory } from 'vue-router';

const router = createRouter({
    routes: [
        // Home
        {
            path: '/',
            name: 'Home',
            component: () => import('./views/home/Index.vue'),
        },
        {
            path: '/about',
            name: 'About',
            component: () => import('./views/home/About.vue'),
        },
        {
            path: '/schedule',
            name: 'Schedule',
            component: () => import('./views/home/Schedule.vue'),
        },
        {
            path: '/chat',
            name: 'Chat',
            component: () => import('./views/home/Chat.vue'),
            children: [
                { name: 'ChatMessage', path: ':chatid', component: () => import('./views/home/ChatMessage.vue') },
            ]
        },
        {
            path: '/enroll',
            name: 'Enroll',
            component: () => import('./views/courses/Enroll.vue'),
        },
        // Account
        {
            path: '/profile',
            name: 'Profile',
            component: () => import('./views/account/Profile.vue'),
            children: [
                { name: 'Overview', path: '', component: () => import('./views/account/Overview.vue') },
            ]
        },
        {
            path: '/login',
            name: 'Login',
            component: () => import('./views/account/SignIn.vue'),
        },
        {
            path: '/register',
            name: 'Register',
            component: () => import('./views/account/SignUp.vue'),
        },


        // Course
        {
            path: '/courses',
            name: 'Courses',
            component: () => import('./views/courses/Index.vue'),
        },
        {
            path: '/newMeeting',
            name: 'NewMeeting',
            component: () => import('./views/home/NewMeeting.vue'),

        },
        {
            path: '/Meeting',
            name: 'Meeting',
            component: () => import('./views/home/Meeting.vue'),

        }
    ],
    history: createWebHistory(),
    linkActiveClass: 'router-link-active',
});

export default router;
