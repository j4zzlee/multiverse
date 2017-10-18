import uuid from 'uuid'
import TokenModel from '@/models/token'
import * as APIConst from '@/consts/API'
export default {
  namespaced: true,
  state: {
    initialized: false,
    annonymous: true,
    uniqueId: null,
    userInfo: {}, // store full user info
    tokenInfo: {} // only store the token & claims
  },
  mutations: {
    inited (state, {userInfo, tokenInfo, annonymous}) {
      state.annonymous = annonymous
      state.initialized = true
      state.userInfo = userInfo
      state.tokenInfo = tokenInfo
    }
  },
  actions: {
    logout ({commit, state}, {$vue}) {
      var $localStorage = $vue.$localStorage
      $localStorage.set('profile', null)
      commit('profile/inited', {userInfo: {}, tokenInfo: {}, annonymous: true}, {root: true})
    },
    async login ({commit, state}, {$vue, email, password, remember_me}) {
      var d = new FormData()
      d.append('username', email)
      d.append('password', password)
      d.append('remember_me', remember_me)
      var result = await $.post({
        url: APIConst.TOKEN_API,
        type: 'POST',
        cache: false,
        contentType: false,
        processData: false,
        data: d
      })
      return result
    },
    /*
    * @params: store: {commit, dispatch, state, rootState}
    * @functionParams: {*}
    */
    init ({commit, state}, {$vue}) {
      var $localStorage = $vue.$localStorage
      var profile = $localStorage.get('profile')
      if (!profile) {
        profile = {
          ...state,
          annonymous: true,
          uniqueId: uuid.v4()
        }
        $localStorage.set('profile', profile)
      } else {
        var token = new TokenModel(profile.tokenInfo)
        if (!token.isExpired()) {
          // TODO: verify if token expired
          profile.annonymous = false
        } else {
          profile.userInfo = {}
          profile.tokenInfo = {}
          profile.annonymous = true
          profile.uniqueId = uuid.v4()
        }
      }
      commit('profile/inited', profile, {root: true})
      return profile
    }
  }
}
