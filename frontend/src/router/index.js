import Vue from 'vue'
import Router from 'vue-router'
import Home from '@/components/Home'
import QuickNote from '@/components/QuickNote'
import Games from '@/components/Games'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Home',
      component: Home
    },
    {
      path: '/games',
      name: 'Games',
      component: Games
    },
    {
      path: '/quick-note',
      name: 'QuickNote',
      component: QuickNote
    }
  ]
})
