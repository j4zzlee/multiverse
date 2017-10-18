import axios from 'axios'

const Plugin = {
  install (Vue, options) {
    // We call Vue.mixin() here to inject functionality into all components.
    Vue.prototype.$http = axios
  }
}

export default Plugin
