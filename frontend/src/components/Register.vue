<template>
<div class="register-box" :class="{ 'form-loading': loading, 'form-error': hasError }">
  <div class="register-logo">
    <router-link :to="{name:'Home'}"><b>Super</b>Exams</router-link>
  </div>

  <div class="register-box-body">
    <p class="login-box-msg">Register a new account</p>
    <div class="alert alert-danger alert-dismissible" v-if="hasError">
      <button type="button" class="close" data-dismiss="alert" aria-hidden="true" @click.stop.prevent="hideError">×</button>
      <h4><i class="icon fa fa-ban"></i> Register failed!</h4>
      {{errorMessage}}
    </div>
    <form  v-on:submit.prevent="onSubmit">
      <div class="form-group has-feedback" :class="{ 'has-error': veeErrors.has('fullName') && submitted }">
        <input type="text" v-model="fullName" name="fullName" class="form-control" placeholder="Full name"
          v-validate="{ min: 6, max: 255 }">
        <span class="glyphicon glyphicon-user form-control-feedback"></span>
        <small v-show="veeErrors.has('fullName') && submitted" class="help text-danger">{{ veeErrors.first('fullName') }}</small>
      </div>
      <div class="form-group has-feedback" :class="{ 'has-error': veeErrors.has('email') && submitted }">
        <input type="email" v-model="email" name="email" class="form-control" placeholder="Email"
          v-validate="{ required: true, email: true, min: 6, max: 255 }">
        <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
        <small v-show="veeErrors.has('email') && submitted" class="help text-danger">{{ veeErrors.first('email') }}</small>
      </div>
      <div class="form-group has-feedback" :class="{ 'has-error': veeErrors.has('password') && submitted }">
        <input type="password" v-model="password" name="password" class="form-control" placeholder="Password"
          v-validate="{ required: true, min: 6, max: 255 }">
        <span class="glyphicon glyphicon-lock form-control-feedback"></span>
        <small v-show="veeErrors.has('password') && submitted" class="help text-danger">{{ veeErrors.first('password') }}</small>
      </div>
      <div class="form-group has-feedback" :class="{ 'has-error': veeErrors.has('confirmPassword') && submitted }">
        <input type="password" v-model="confirmPassword" name="confirmPassword" class="form-control" placeholder="Retype password"
          v-validate="{ required: true, min: 6, max: 255, confirmed: 'password' }">
        <span class="glyphicon glyphicon-log-in form-control-feedback"></span>
        <small v-show="veeErrors.has('confirmPassword') && submitted" class="help text-danger">{{ veeErrors.first('confirmPassword') }}</small>
      </div>
      <div class="row">
        <div class="col-xs-8">
          <div class="checkbox icheck" :class="{ 'has-error': veeErrors.has('agreementChecked') && submitted }">
            <label>
              <input type="checkbox" name="agreementChecked" v-validate="'required'" v-model="agreementChecked"> I agree to the <a href="#">terms</a>
            </label>
          </div>
        </div>
        <!-- /.col -->
        <div class="col-xs-4">
          <button type="submit" class="btn btn-primary btn-block btn-flat">Register</button>
        </div>
        <!-- /.col -->
      </div>
    </form>

    <div class="social-auth-links text-center">
      <p>- OR -</p>
      <a href="#" class="btn btn-block btn-social btn-facebook btn-flat"><i class="fa fa-facebook"></i> Sign up using
        Facebook</a>
      <a href="#" class="btn btn-block btn-social btn-google btn-flat"><i class="fa fa-google-plus"></i> Sign up using
        Google+</a>
    </div>
    <router-link :to="{name:'Login'}">I already have an account.</router-link>
  </div>
  <!-- /.form-box -->
   <div class="loading" v-if="loading">Loading&#8230;</div>
</div>
<!-- /.register-box -->
</template>

<script>
export default {
  name: 'Register',
  data () {
    return {
      fullName: 'Le Huu Hoang Gia',
      email: 'hoanggia.lh@gmail.com',
      password: 'P@ssword123',
      confirmPassword: 'P@ssword123',
      remember_me: false,
      hasError: false,
      loading: false,
      errorMessage: '',
      agreementChecked: null, // must be null instead of false
      submitted: false,
      logger_: this.$Logger.create('Register')
    }
  },
  methods: {
    hideError () {
      this.hasError = false
    },
    async onSubmit () {
      this.submitted = true
      await this.$validator.validateAll()
      if (this.veeErrors.any()) {
        return
      }
      this.logger_.info('begin register')
    }
  }
}
</script>