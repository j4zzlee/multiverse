import strUtils from '@/libs/common/str'
export default class ExceptionHandler {
  _res;
  _jMessage;
  constructor (res) {
    this._res = res || {}
    if (!strUtils.isNullOrWhiteSpace(res.responseText)) {
      this._jMessage = JSON.parse(res.responseText) || {}
    } else {
      this._jMessage = {}
    }
  }
  getExceptionCode () {
    return this._jMessage.Code
  }
  getHttpStatusCode () {
    return parseInt(this._res.status, 10)
  }
  getExceptionMessage () {
    if (!strUtils.isNullOrWhiteSpace(this._jMessage.Message) && !strUtils.isNullOrWhiteSpace(this._jMessage.Code)) {
      // TODO: multilanguage
      return this._jMessage.Message
    }
    var message = 'Unknow error occured.'
    switch (this.getHttpStatusCode()) {
      case 504:
        message = 'Service unavailable'
        break
      case 404:
        message = 'The requested resource is not found'
        break
      case 400:
        message = 'The requested data is not valid'
        break
      case 503:
        message = 'Service unavailable'
        break
    }
    return message
  }
}