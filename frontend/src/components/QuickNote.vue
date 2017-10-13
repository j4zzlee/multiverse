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
    <div class="quick-note">
      <div class="text-center">
          UNDER CONSTRUCTOR
      </div>
      <div class="row">
        <div class="col-md-offset-4 col-md-4">
          <div class="col-md-12">
              <router-link :to="{ name: 'Home' /*, params: { userId: 123 }*/}" class="btn btn-lg btn-block btn-primary">
                  Back
              </router-link>
          </div>
        </div>
      </div>
    </div>
  </section>
</div>
  
</template>

<script>
export default {
  name: 'QuickNote',
  data () {
    return {
      msg: 'Quick Note'
    }
  } // ,
//   components: { HomeHeader: HomeHeader }
}
</script>