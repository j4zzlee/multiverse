import Vue from 'vue'
import Router from 'vue-router'
import VueHead from 'vue-head'
import Home from '@/components/Home'
import _HomeLayout from '@/layouts/_Home'
import QuickNote from '@/components/QuickNote'
import Games from '@/components/Games'

Vue.use(VueHead)
Vue.use(Router)

export default new Router({
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
