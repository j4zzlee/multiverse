<template>
<div class="wrapper">
    <!-- Main Header -->
    <header class="main-header">
        <!-- Logo -->
        <a href="/" class="logo">
        <!-- mini logo for sidebar mini 50x50 pixels -->
        <span class="logo-mini"><b>S</b>E</span>
        <!-- logo for regular state and mobile devices -->
        <span class="logo-lg"><b>Super</b>Exams</span>
        </a>

        <!-- Header Navbar -->
        <nav class="navbar navbar-static-top" role="navigation">
            <!-- Sidebar toggle button-->
            <a href="#" class="sidebar-toggle" data-toggle="push-menu" role="button">
                <span class="sr-only">Toggle navigation</span>
            </a>
            <!-- Navbar Right Menu -->
            <div class="navbar-custom-menu">
              <ul class="nav navbar-nav">
                <MenuMessages></MenuMessages>
                <MenuNotifications></MenuNotifications>
                <MenuTasks></MenuTasks>
                <MenuUserProfile></MenuUserProfile>
                <!-- Control Sidebar Toggle Button -->
                <li>
                    <a href="#" data-toggle="control-sidebar"><i class="fa fa-gears"></i></a>
                </li>
              </ul>
            </div>
        </nav>
    </header>

    <LeftSideBar></LeftSideBar>
    <!-- Content Wrapper. Contains page content -->
    <router-view></router-view>
    <!-- /.content-wrapper -->

    <!-- Main Footer -->
    <footer class="main-footer">
        <!-- To the right -->
        <div class="pull-right hidden-xs">
        Anything you want
        </div>
        <!-- Default to the left -->
        <strong>Copyright &copy; 2016 <a href="#">Company</a>.</strong> All rights reserved.
    </footer>

    <ControlSideBar></ControlSideBar>
    <!-- Add the sidebar's background. This div must be placed
    immediately after the control sidebar -->
    <div class="control-sidebar-bg"></div>
    </div>
</template>

<script>
const MenuMessages = () => import('@/layouts/Home/MenuMessages')
const MenuNotifications = () => import('@/layouts/Home/MenuNotifications')
const MenuTasks = () => import('@/layouts/Home/MenuTasks')
const MenuUserProfile = () => import('@/layouts/Home/MenuUserProfile')
const ControlSideBar = () => import('@/layouts/Home/ControlSideBar')
const LeftSideBar = () => import('@/layouts/Home/LeftSideBar')

export default {
  name: 'HomeLayout',
  components: { MenuMessages, MenuNotifications, MenuTasks, MenuUserProfile, LeftSideBar, ControlSideBar },
  data () {
    return {
    //   msg: 'Welcome to Super Exams'
      // profile: this.$store.state.profile
    }
  },
  mounted () {
    $.fn.layout.call($('#app'))
  },
  updated () {
    $.fn.layout.call($('#app'))
  },
  metaInfo: {
    title: 'Exams Anywhere!!!',
    link: [
      { rel: 'favicon shortcut icon', href: '/static/logo.png' },
      { rel: 'stylesheet', href: 'https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic' },
      { rel: 'stylesheet', href: 'https://fonts.googleapis.com/icon?family=Material+Icons' },
      { rel: 'stylesheet', href: 'https://cdnjs.cloudflare.com/ajax/libs/animate.css/3.5.2/animate.min.css' }
    ]
  }
//   components: { HomeHeader: HomeHeader }
}
</script>