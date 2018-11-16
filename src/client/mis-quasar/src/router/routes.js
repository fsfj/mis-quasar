
const routes = [
  {
    path: '/',
    name: 'Home',
    icon: 'home',
    component: () => import('layouts/MyLayout.vue'),
    children: [
      { path: '', component: () => import('pages/Index.vue') }
    ]
  },
  {
    path: '/members',
    name: 'Members',
    icon: 'people',
    component: () => import('layouts/MyLayout.vue'),
    children: [
      { path: '', component: () => import('pages/members/List.vue') },
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
