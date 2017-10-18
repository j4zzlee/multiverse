import Logger from 'logplease'
import Vue from 'vue'

const Plugin = {
  install (Vue, options) {
    Vue.prototype.$Logger = Logger
  }
}

Vue.use(Plugin)
export default Plugin
