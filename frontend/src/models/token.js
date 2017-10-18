// import strUtils from '@/libs/common/str'
export default class TokenModel {
  _data;
  constructor (d) {
    this._data = d || {}
  }
  accessToken () {}
  expiredAt () {}
  isExpired () {}
}
