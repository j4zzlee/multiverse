export default {
  isNullOrWhiteSpace (str) {
    if (typeof str === 'undefined' || str == null) {
      return true
    }
    return str.replace(/\s/g, '').length < 1
  }
}
