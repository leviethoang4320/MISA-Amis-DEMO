import Vue from "vue";
import VueRouter from "vue-router";
import MissonAllowance from "@/views/misson-allowance/MissonAllowance.vue"


Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    redirect: '/misson-allowance',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: MissonAllowance
  },
  
  {
    path: '/misson-allowance',
    name: 'misson-allowance',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: MissonAllowance
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
