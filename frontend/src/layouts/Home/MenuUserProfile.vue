<template>
    <!-- User Account Menu -->
    <li class="dropdown user user-menu">
        <!-- Menu Toggle Button -->
        <a href="#" class="dropdown-toggle" data-toggle="dropdown">
            <!-- The user image in the navbar-->
            <img :src="photoUri" class="user-image" alt="User Image" @error="onPhotoError">
            <!-- hidden-xs hides the username on small devices so only the image appears. -->
            <span class="hidden-xs">{{fullName}}</span>
        </a>
        <ul class="dropdown-menu">
            <!-- The user image in the menu -->
            <li class="user-header">
                <img :src="photoUri" class="img-circle" alt="User Image" @error="onPhotoError">

                <p>
                {{fullName}}
                <!-- <small>Member since Nov. 2012</small> -->
                </p>
            </li>
            <!-- Menu Body -->
            <li v-if="!isAnnonymous" class="user-body">
                <div class="row">
                <div class="col-xs-4 text-center">
                <a href="#">Followers</a>
                </div>
                <div class="col-xs-4 text-center">
                <a href="#">Sales</a>
                </div>
                <div class="col-xs-4 text-center">
                <a href="#">Friends</a>
                </div>
                </div>
                <!-- /.row -->
            </li>
            <!-- Menu Footer-->
            <li v-if="!isAnnonymous" class="user-footer">
              <div class="pull-left">
                <a href="#" class="btn btn-default btn-flat">Profile</a>
              </div>
              <div class="pull-right">
                <a href="#" class="btn btn-default btn-flat">Sign out</a>
              </div>
            </li>
            <li v-if="isAnnonymous" class="user-footer">
              <div class="pull-left">
                <router-link :to="{name:'Login'}" v-if="isAnnonymous" class="btn btn-default btn-flat">Sign In</router-link>
              </div>
              <div class="pull-right">
                <a href="#" class="btn btn-default btn-flat">Sign Up</a>
              </div>
            </li>
        </ul>
    </li>
</template>

<script>
import strUtils from '@/libs/common/str'
export default {
  name: 'MenuUserProfile',
  data () {
    return {
    }
  },
  props: {
    profile: {type: Object, required: false, default: { data: {} }}
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
      return (this.profile && this.profile.data) || {}
    },
    fullName () {
      if (this.profile.annonymous || (strUtils.isNullOrWhiteSpace(this.profileData.FirstName) && strUtils.isNullOrWhiteSpace(this.profileData.LastName))) {
        return 'Welcome Guest'
      }
      // return `${this.firstName} ${this.lastName}`
      return [this.profileData.FirstName, this.profileData.LastName].filter(w => !strUtils.isNullOrWhiteSpace(w)).join(' ')
    },
    photoUri () {
      if (this.profile.annonymous || this.photoError || strUtils.isNullOrWhiteSpace(this.profileData.Photo)) {
        return '/static/user-default.png'
      }
      return this.profileData.Photo
    }
  }
}
</script>