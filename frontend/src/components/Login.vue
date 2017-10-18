<template>
<div class="login-box" :class="{ 'form-loading': loading, 'form-error': hasError }">
    <div class="login-logo">
      <router-link :to="{name:'Home'}"><b>Super</b>Exams</router-link>
    </div>
    <!-- /.login-logo -->
    <div class="login-box-body">
      <p class="login-box-msg">Sign in to start your session</p>

      <form v-on:submit.prevent="onSubmit">
        <div class="form-group has-feedback">
          <input v-model="email" type="email" class="form-control" placeholder="Email" autofocus required>
          <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
        </div>
        <div class="form-group has-feedback">
          <input v-model="password" type="password" class="form-control" placeholder="Password" required>
          <span class="glyphicon glyphicon-lock form-control-feedback"></span>
        </div>
        <div class="row">
          <div class="col-xs-8">
            <div class="checkbox icheck">
              <label>
                <input v-model="remember_me" type="checkbox"> Remember Me
              </label>
            </div>
          </div>
          <!-- /.col -->
          <div class="col-xs-4">
            <button type="submit" class="btn btn-primary btn-block btn-flat">Sign In</button>
          </div>
          <!-- /.col -->
        </div>
      </form>

      <div class="social-auth-links text-center">
        <p>- OR -</p>
        <a href="#" class="btn btn-block btn-social btn-facebook btn-flat">
          <i class="fa fa-facebook"></i>
          Sign in using Facebook
        </a>
        <a href="#" class="btn btn-block btn-social btn-google btn-flat"><i class="fa fa-google-plus"></i> Sign in using
          Google+</a>
      </div>
      <!-- /.social-auth-links -->

      <a href="#">I forgot my password</a><br>
      <router-link :to="{name:'Register'}">I don't have an account.</router-link>

    </div>
    <!-- /.login-box-body -->
    <div class="loading" v-if="loading">Loading&#8230;</div>
  </div>
  <!-- /.login-box -->
</template>

<script>
export default {
  name: 'Login',
  data () {
    return {
      email: 'hoanggia.lh@gmail.com',
      password: 'P@ssword123',
      remember_me: false,
      hasError: false,
      loading: false,
      logger_: this.$Logger.create('Login')
    }
  },
  methods: {
    async onSubmit () {
      this.loading = true
      try {
        await this.$store.dispatch(
          'profile/login',
          {
            $vue: this,
            email: this.email,
            password: this.password,
            remember_me: this.remember_me
          },
          {
            root: true
          })
      } catch (ex) {
        console.log(ex, ex.responseText)
      } finally {
        this.loading = false
      }
    }
  }
}
</script>