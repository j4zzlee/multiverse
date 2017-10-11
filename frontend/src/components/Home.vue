<template>
  <div class="home">
    <HomeHeader :title="msg"></HomeHeader>
    <div class="row">
      <div class="col-md-offset-4 col-md-4">
        <div class="col-md-6">
          <router-link :to="{ name: 'Games' /*, params: { userId: 123 }*/}" class="btn btn-lg btn-block btn-primary">Take a game</router-link>
        </div>
        <div class="col-md-6">
          <router-link  :to="{ name: 'QuickNote' /*, params: { userId: 123 }*/}" class="btn btn-lg btn-block btn-warning">Quick note</router-link>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import HomeHeader from '@/partials/Home/HomeHeader'
export default {
  name: 'Home',
  data () {
    return {
      msg: 'Welcome to Super Exams'
    }
  },
  components: { HomeHeader: HomeHeader }
}
</script>