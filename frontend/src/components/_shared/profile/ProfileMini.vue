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
import UserModel from '@/models/user'
export default {
  props: {
    profile: {type: Object, required: false, default: { data: {} }}
  },
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
    isAnnonymous () {
      return this.profile.annonymous
    },
    profileData () {
      return new UserModel(this.profile.data)
    },
    fullName () {
      if (this.profile.annonymous) {
        return 'Welcome Guest'
      }

      return 'Welcome ' + this.profileData.fullName()
    },
    photoUri () {
      if (this.profile.annonymous || this.photoError || !this.profileData.hasPhoto()) {
        return '/static/user-default.png'
      }
      return ['/api/photo', this.profileData.photoId()].join('/')
    }
  }
}
</script>