import Vue from 'vue'
import Router from 'vue-router'
import VueMeta from 'vue-meta'
import Home from '@/components/Home'
import _HomeLayout from '@/layouts/_Home'
import QuickNote from '@/components/QuickNote'
import Games from '@/components/Games'

Vue.use(VueMeta)
Vue.use(Router)

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
    }
  ]
})

// router.afterEach((to, from, next) => {
//   $.fn.layout.call($('#app'))
// })

export default router
