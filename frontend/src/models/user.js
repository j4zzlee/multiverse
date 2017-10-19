import strUtils from '@/libs/common/str'
export default class UserModel {
  _data;
  constructor (d) {
    this._data = d || {}
  }
  firstName () {
    return this._data.firstName
  }
  lastName () {
    return this._data.lastName
  }
  phoneNumber () {
    return this._data.phoneNumber
  }
  email () {
    return this._data.email
  }
  userName () {
    return this._data.userName
  }
  photoId () {
    return this._data.photoId
  }
  hasPhoto () {
    return !strUtils.isNullOrWhiteSpace(this.photoId())
  }
  fullName () {
    return [this.firstName(), this.lastName()]
      .filter(w => !strUtils.isNullOrWhiteSpace(w))
      .join(' ')
  }
}
