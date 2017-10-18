import strUtils from '@/libs/common/str'
export default class UserModel {
  _data;
  constructor (d) {
    this._data = d || {}
  }
  firstName () {
    return this._data.FirstName
  }
  lastName () {
    return this._data.LastName
  }
  phoneNumber () {
    return this._data.PhoneNumber
  }
  email () {
    return this._data.Email
  }
  userName () {
    return this._data.UserName
  }
  photoId () {
    return this._data.PhotoId
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
