import Promise from 'bluebird'
import Vue from 'vue'

const Plugin = {
  install (Vue, options) {
    // We call Vue.mixin() here to inject functionality into all components.
    var isDevelopment = process.env.NODE_ENV === 'development'
    Promise.config({
      longStackTraces: isDevelopment,
      warnings: isDevelopment // note, run node with --trace-warnings to see full stack traces for warnings
    })
    Vue.prototype.$promise = Promise
  }
}

Vue.use(Plugin)
export default Plugin
