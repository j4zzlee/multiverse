// import strUtils from '@/libs/common/str'
export default class TokenModel {
  _data;
  constructor (d) {
    this._data = d || {}
  }
  accessToken () {
    return this._data.access_token
  }
  expiredAt () {
    return this._data.expired_at || null
  }
  isExpired () {
    if (this.expiredAt() == null) {
      return true
    }
    var expiredAt = parseInt(this.expiredAt(), 10)
    return (expiredAt - new Date().getTime()) > 10000 // 10s
  }
}
