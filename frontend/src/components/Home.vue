<template>
<div class="content-wrapper">
  <fab
    :position="position"
    :bg-color="bgColor"
    :actions="fabActions"
    :icon-size="iconSize"
    @QuickNote="quickNote"
    @TakeNote="takeNote"
  ></fab>
  <!-- Main content -->
  <section class="content container-fluid">
    <div class="home">
      <div class="row">
        <div class="col-md-offset-4 col-md-4">
          <router-link :to="{ name: 'Games' /*, params: { userId: 123 }*/}" class="btn btn-lg btn-block btn-primary">Take a game</router-link>
        </div>
      </div>
    </div>
  </section>
</div>
</template>

<script>
import fab from 'vue-fab'
export default {
  name: 'Home',
  data () {
    return {
      bgColor: '#778899',
      position: 'bottom-right',
      iconSize: 'medium',
      fabActions: [
        {
          name: 'QuickNote',
          icon: 'mode_edit',
          tooltip: 'Take quick note'
        },
        {
          name: 'TakeNote',
          icon: 'playlist_add',
          tooltip: 'Take advanced note'
        }
      ]
      // profile: this.$store.state.profile
    }
  },
  methods: {
    quickNote () {
      this.$router.push({name: 'QuickNote'})  /* , params: { userId: 123 } */
    },
    takeNote () {
      console.log('take note')
    }
  },
  components: { fab }
}
</script>