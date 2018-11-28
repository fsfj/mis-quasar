import Vue from "vue";
import Router from "vue-router";

Vue.use(Router);

let Layout = () => import("./layouts/MyLayout.vue");

let router = new Router({
  mode: process.env.CORDOVA_PLATFORM ? "hash" : "hash",
  base: process.env.BASE_URL,
  routes: [
    {
      path: "/",
      component: Layout,
      children: [
        {
          path: "",
          name: "home",
          component: () => import("./views/Home.vue")
        }
      ]
    },
    {
      path: "/members",
      component: Layout,
      children: [
        {
          path: "",
          component: () =>
            import(/* webpackChunkName: "about" */ "./views/member/List.vue")
        },
        {
          path: "create",
          component: () => import("./views/member/Create.vue")
        },
        {
          path: ":id/edit",
          component: () => import("./views/member/Edit.vue")
        }
      ]
      // route level code-splitting
      // this generates a separate chunk (about.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
    },
    {
      path: "/login",
      component: () =>
        import(/* webpackChunkName: "about" */ "./views/Login.vue")
    }
  ]
});

router.beforeEach((to, from, next) => {
  // redirect to login page if not logged in and trying to access a restricted page
  const publicPages = ["/login"];
  const authRequired = !publicPages.includes(to.path);
  const loggedIn = localStorage.getItem("_t");

  if (authRequired && !loggedIn) {
    return next("/login");
  }

  next();
});

export default router;
