import Vue from 'vue'
import Router from 'vue-router'
import VueMeta from 'vue-meta'

Vue.use(VueMeta)
Vue.use(Router)

const Home = () => import('@/components/Home')
const _HomeLayout = () => import('@/layouts/_Home')
const QuickNote = () => import('@/components/QuickNote')
const Games = () => import('@/components/Games')
const _Login = () => import('@/layouts/_Login')
const Login = () => import('@/components/Login')
const Register = () => import('@/components/Register')

const router = new Router({
  routes: [
    {
      path: '/',
      component: _HomeLayout,
      children: [
        {
          // UserProfile will be rendered inside User's <router-view>
          // when /user/:id/profile is matched
          path: '',
          name: 'Home',
          component: Home
        },
        {
          // UserPosts will be rendered inside User's <router-view>
          // when /user/:id/posts is matched
          path: 'quick-note',
          name: 'QuickNote',
          component: QuickNote
        }
      ]
    },
    {
      path: '/games',
      name: 'Games',
      component: Games
    },
    {
      path: '/auth',
      name: 'Auth',
      component: _Login,
      children: [
        {
          // UserProfile will be rendered inside User's <router-view>
          // when /user/:id/profile is matched
          path: 'login',
          name: 'Login',
          component: Login
        },
        {
          // UserPosts will be rendered inside User's <router-view>
          // when /user/:id/posts is matched
          path: 'register',
          name: 'Register',
          component: Register
        }
      ]
    }
  ]
})

// router.afterEach((to, from, next) => {
//   $.fn.layout.call($('#app'))
// })

export default router
