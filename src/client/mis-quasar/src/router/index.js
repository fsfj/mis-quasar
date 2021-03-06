import Vue from 'vue'
import VueRouter from 'vue-router'

import routes from './routes'

Vue.use(VueRouter)

/*
 * If not building with SSR mode, you can
 * directly export the Router instantiation
 */

export default function (/* { store, ssrContext } */) {
  const Router = new VueRouter({
    scrollBehavior: () => ({ y: 0 }),
    routes,

    // Leave these as is and change from quasar.conf.js instead!
    // quasar.conf.js -> build -> vueRouterMode
    // quasar.conf.js -> build -> publicPath
    mode: process.env.VUE_ROUTER_MODE,
    base: process.env.VUE_ROUTER_BASE
  })

  // Router.beforeEach((to, from, next) => {
  //   // redirect to login page if not logged in and trying to access a restricted page
  //   const publicPages = ['/login'];
  //   const authRequired = !publicPages.includes(to.path);
  //   const loggedIn = localStorage.getItem('user');
  //   if (authRequired && !loggedIn) {
  //     return next('/login');
  //   }
  
  //   next();
  // })
  return Router
}
