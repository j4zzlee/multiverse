// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from './App'
import router from './router'
import store from './store'
import localStorage from '@/libs/plugins/local-storage'
import axios from '@/libs/plugins/axios'
import bluebird from '@/libs/plugins/bluebird'
import('../node_modules/jquery/dist/jquery.min.js')
import('../node_modules/jquery/dist/jquery.slim.min.js')
import('../node_modules/bootstrap-sass/assets/javascripts/bootstrap.min.js')
import('./styles/js/site.js')
import('./styles/_main.scss')

Vue.config.productionTip = false
Vue.use(localStorage)
Vue.use(axios)
Vue.use(bluebird)
/* eslint-disable no-new */
new Vue({
  el: '#app',
  store,
  router,
  template: '<App/>',
  components: { App }
})
