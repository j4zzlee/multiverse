import StrUtils from '@/libs/common/str'
import Vue from 'vue'

const Plugin = {
  install (Vue, options) {
    Vue.prototype.$strUtils = StrUtils
  }
}

Vue.use(Plugin)
export default Plugin
