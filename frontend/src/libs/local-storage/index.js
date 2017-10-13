import Store from 'store'

const Plugin = {
  install (Vue, options) {
    // We call Vue.mixin() here to inject functionality into all components.
    Vue.prototype.$localStorage = Store
  }
}

export default Plugin
