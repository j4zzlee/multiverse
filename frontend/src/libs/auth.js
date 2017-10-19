import Store from 'store'
import TokenModel from '@/models/token'
const Auth = {
  loggedIn () {
    var profile = Store.get('profile') || {}
    var token = new TokenModel(profile.tokenInfo)
    return !token.isExpired()
  },
  clear () {
    Store.set('profile', {annonymous: true, userInfo: {}, tokenInfo: {}, initialized: false})
  }
}
export default Auth
