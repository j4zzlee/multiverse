<template>
<!-- Sidebar user panel (optional) -->
<div class="user-panel">
    <div class="pull-left image">
    <img src="/static/user2-160x160.jpg" class="img-circle" alt="User Image">
    </div>
    <div class="pull-left info">
    <p>{{this.fullName}}</p>
    <!-- Status -->
    <!-- <a href="#"><i class="fa fa-circle text-success"></i> Online</a> -->
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
    }
  },
  computed: {
    fullName: () => {
      if (this.isAnnonymous || (strUtils.isNullOrWhiteSpace(this.firstName) && strUtils.isNullOrWhiteSpace(this.lastName))) {
        return 'Guest'
      }
      // return `${this.firstName} ${this.lastName}`
      return [this.firstName, this.lastName].filter(w => !strUtils.isNullOrWhiteSpace(w)).join(' ')
    }
  }
}
</script>