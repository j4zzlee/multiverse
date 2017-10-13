<template>
<div class="content-wrapper">
  <section class="content-header">
    <h1>
      {{msg}}
      <small>Optional description</small>
    </h1>
    <ol class="breadcrumb">
      <li><a href="#"><i class="fa fa-dashboard"></i> Level</a></li>
      <li class="active">Here</li>
    </ol>
  </section>

  <!-- Main content -->
  <section class="content container-fluid">
    <div class="home">
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
  </section>
</div>
</template>

<script>
export default {
  name: 'Home',
  data () {
    return {
      msg: 'Welcome to Super Exams'
      // profile: this.$store.state.profile
    }
  }
  // components: { HomeHeader: HomeHeader }
}
</script>