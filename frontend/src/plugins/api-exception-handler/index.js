import Vue from 'vue'
import ApiExceptionHandler from '@/libs/api/exception-handler'

const Plugin = {
  install (Vue, options) {
    Vue.prototype.$apiExceptionHandler = ApiExceptionHandler
  }
}

Vue.use(Plugin)
export default Plugin
