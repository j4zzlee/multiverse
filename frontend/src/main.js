// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from './App'
import router from './router'
import store from './store'
import LocalStorage from './libs/local-storage'
import('../node_modules/jquery/dist/jquery.min.js')
import('../node_modules/jquery/dist/jquery.slim.min.js')
import('../node_modules/bootstrap-sass/assets/javascripts/bootstrap.min.js')
import('./styles/js/site.js')
import('./styles/_main.scss')

Vue.config.productionTip = false
Vue.use(LocalStorage)
/* eslint-disable no-new */
new Vue({
  el: '#app',
  store,
  router,
  template: '<App/>',
  components: { App }
})
