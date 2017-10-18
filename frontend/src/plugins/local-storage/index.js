import Store from 'store'
import Vue from 'vue'

const Plugin = {
  install (Vue, options) {
    Vue.prototype.$localStorage = Store
  }
}

Vue.use(Plugin)
export default Plugin
