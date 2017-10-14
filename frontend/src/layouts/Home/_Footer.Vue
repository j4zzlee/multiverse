<template>
<!-- Main Footer -->
<footer class="main-footer">
    <!-- To the right -->
    <!-- <div class="pull-right hidden-xs">
    Anything you want
    </div> -->
    <!-- Default to the left -->
    <strong>
      Copyright &copy; 2016 <router-link :to="{ name: 'Home' /*, params: { userId: 123 }*/}" class="btn btn-link">BCTeam</router-link>.
    </strong> All rights reserved.
</footer>
</template>

<script>
export default {
  name: 'Footer_',
  data () {
    return {
    }
  }
}
</script>