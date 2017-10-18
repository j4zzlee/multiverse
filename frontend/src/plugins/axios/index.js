import axios from 'axios'
import Vue from 'vue'

const Plugin = {
  install (Vue, options) {
    // We call Vue.mixin() here to inject functionality into all components.
    Vue.prototype.$http = axios
  }
}

Vue.use(Plugin)
export default Plugin
