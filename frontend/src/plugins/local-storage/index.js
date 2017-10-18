import Store from 'store'

const Plugin = {
  install (Vue, options) {
    Vue.prototype.$localStorage = Store
  }
}

export default Plugin
