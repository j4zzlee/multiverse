import uuid from 'uuid'
import _ from 'lodash'
export default {
  namespaced: true,
  state: {
    initialized: false,
    annonymous: true,
    uniqueId: null,
    data: {}, // store full user info
    token: {} // only store the token & claims
  },
  mutations: {
    inited (state, {profile}) {
      Object.assign(state, profile)
    }
  },
  actions: {
    /*
    * @params: store: {commit, dispatch, state, rootState}
    * @functionParams: {*}
    */
    init: ({commit, state}, {router, localStorage}) => {
      var profile = localStorage.get('profile')
      if (!profile) {
        profile = {
          ...state,
          annonymous: true,
          uniqueId: uuid.v4(),
          initialized: true
        }
      } else {
        profile = {
          ...profile,
          initialized: true
        }
      }

      if (!_.isEmpty(profile.token)) {
        // TODO: verify if token is not expired
      }
      localStorage.set('profile', profile)
      commit('profile/inited', {profile}, {root: true})
    }
  }
}
