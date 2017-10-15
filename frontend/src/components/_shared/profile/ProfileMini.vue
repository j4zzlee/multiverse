<template>
<!-- Sidebar user panel (optional) -->
<div class="user-panel">
    <div class="pull-left image">
    <img :src="photoUri" class="img-circle" alt="User Image" @error="onPhotoError">
    </div>
    <div class="pull-left info">
    <p>{{this.fullName}}</p>
    <!-- Status -->
    <router-link :to="{name:'Login'}" v-if="isAnnonymous"><i class="fa fa-circle text-danger"></i> Sign In</router-link>
    <a href="#" v-else><i class="fa fa-circle text-success"></i> Registered</a>
    </div>
</div>
</template>

<script>
import strUtils from '@/libs/common/str'
export default {
  props: ['firstName', 'lastName', 'status', 'isAnnonymous', 'photo', 'email', 'userName'],
  name: 'ProfileMini',
  data () {
    return {
      photoError: false
    }
  },
  methods: {
    onPhotoError () {
      this.photoError = true
    }
  },
  computed: {
    fullName () {
      if (this.isAnnonymous || (strUtils.isNullOrWhiteSpace(this.firstName) && strUtils.isNullOrWhiteSpace(this.lastName))) {
        return 'Guest'
      }
      // return `${this.firstName} ${this.lastName}`
      return [this.firstName, this.lastName].filter(w => !strUtils.isNullOrWhiteSpace(w)).join(' ')
    },
    photoUri () {
      if (this.isAnnonymous || this.photoError || strUtils.isNullOrWhiteSpace(this.photo)) {
        return '/static/user-default.png'
      }
    }
  }
}
</script>