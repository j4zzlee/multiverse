import Logger from 'logplease'

const Plugin = {
  install (Vue, options) {
    Vue.prototype.$Logger = Logger
  }
}

export default Plugin
