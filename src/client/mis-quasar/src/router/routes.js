
const routes = [
  {
    path: '/',
    icon: 'home',
    text: 'Home',
    component: () => import('layouts/MyLayout.vue'),
    children: [
      { path: '', name: 'Home', component: () => import('pages/Index.vue') }
    ]
  },
  {
    path: '/members',
    icon: 'people',
    text: 'Members',
    component: () => import('layouts/MyLayout.vue'),
    children: [
      { path: '', name: 'Members', component: () => import('pages/members/List.vue') },
      { path: 'create', component: () => import('pages/members/Create.vue') }
    ]
  },
  {
    path: '/login',
    name: 'Login',
    icon: 'login',
    component: () => import('pages/Login.vue')
  }
]

// Always leave this as last one
if (process.env.MODE !== 'ssr') {
  routes.push({
    path: '*',
    component: () => import('pages/Error404.vue')
  })
}

export default routes
