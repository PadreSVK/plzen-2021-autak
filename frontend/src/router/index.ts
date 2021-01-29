import Vue from 'vue'
import VueRouter from 'vue-router'
import { Home, About, Administration, GenericView } from '@/views'

Vue.use(VueRouter)

const routes = [
    {
        path: '/',
        name: 'Home',
        component: Home
    },
    {
        path: '/about',
        name: 'About',
        component: About
    },
    {
        path: '/administration',
        name: 'Administration',
        component: Administration
    },
    {
        path: '/generictable',
        name: 'GenericView',
        component: GenericView
    }
]

const router = new VueRouter({
    mode: 'history',
    base: process.env.BASE_URL,
    routes
})

export default router