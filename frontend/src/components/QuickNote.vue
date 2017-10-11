<template>
  <div class="quick-note">
    <div class="text-center">
        UNDER CONSTRUCTOR
    </div>
    <div class="row">
      <div class="col-md-offset-4 col-md-4">
        <div class="row">
          <div class="col-md-12">
            <router-link :to="{ name: 'Home' /*, params: { userId: 123 }*/}" class="btn btn-lg btn-block btn-primary">
                Back
            </router-link>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'QuickNote',
  data () {
    return {
    }
  } // ,
//   components: { HomeHeader: HomeHeader }
}
</script>