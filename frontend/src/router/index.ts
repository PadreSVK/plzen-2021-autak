import Vue from 'vue'
import VueRouter from 'vue-router'
import { Home, About, Administration, GenericView, GenericView2, CarsView } from '@/views'

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
        path: '/genericview',
        name: 'GenericView',
        component: GenericView
    },
    {
        path: '/genericview2',
        name: 'GenericView2',
        component: GenericView2
    },
    {
        path: '/carsView',
        name: 'CarsView',
        component: CarsView
    }
]

const router = new VueRouter({
    mode: 'history',
    base: process.env.BASE_URL,
    routes
})

export default router
