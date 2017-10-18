import Store from 'store'
import TokenModel from '@/models/token'
const Auth = {
  loggedIn: function () {
    var profile = Store.get('profile') || {}
    var token = new TokenModel(profile.tokenInfo)
    return !token.isExpired()
  }
}
export default Auth
