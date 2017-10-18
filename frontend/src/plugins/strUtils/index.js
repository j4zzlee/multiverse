import StrUtils from '@/libs/common/str'

const Plugin = {
  install (Vue, options) {
    Vue.prototype.$strUtils = StrUtils
  }
}

export default Plugin
