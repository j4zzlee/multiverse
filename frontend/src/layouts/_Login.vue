<template>
  <router-view></router-view>
</template>

<script>
import { mapState } from 'vuex'
export default {
  name: 'LoginLayout',
  data () {
    return {
    }
  },
  computed: mapState({
    profile: state => state.profile || {},
    notes: state => state.notes || {}
  }),
  methods: {
    addBodyClass () {
      if (this.$route.fullPath.indexOf('auth/login') !== -1) {
        $('body').addClass('login-page')
        $('body').removeClass('register-page')
      } else {
        $('body').addClass('register-page')
        $('body').removeClass('login-page')
      }
    }
  },
  beforeMount () {
    this.addBodyClass()
  },
  mounted () {
    $.fn.layout && $.fn.layout.call($('#app'))
  },
  updated () {
    this.addBodyClass()
    $.fn.layout && $.fn.layout.call($('#app'))
  },
  metaInfo: {
    title: 'Exams Anywhere!!!',
    link: [
      { rel: 'favicon shortcut icon', href: '/static/logo.png' },
      { rel: 'stylesheet', href: 'https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic' },
      { rel: 'stylesheet', href: 'https://fonts.googleapis.com/icon?family=Material+Icons' },
      { rel: 'stylesheet', href: 'https://cdnjs.cloudflare.com/ajax/libs/animate.css/3.5.2/animate.min.css' }
    ]
  }
//   components: { HomeHeader: HomeHeader }
}
</script>