import Vue from 'vue'
import Vuex from 'vuex'
import profile from './profile'
import notes from './notes'

Vue.use(Vuex)

export default new Vuex.Store({
  modules: {
    profile: profile,
    notes: notes
  }
})
