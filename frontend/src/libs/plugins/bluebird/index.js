import Promise from 'bluebird'

const Plugin = {
  install (Vue, options) {
    // We call Vue.mixin() here to inject functionality into all components.
    Promise.config({
      longStackTraces: true,
      warnings: true // note, run node with --trace-warnings to see full stack traces for warnings
    })
    Vue.prototype.$promise = Promise
  }
}

export default Plugin
