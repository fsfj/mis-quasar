<template>
<div>
  <head>
    <link
      rel="stylesheet"
      href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css"
    >
    <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,400,700" rel="stylesheet">
    <!-- Bulma Version 0.7.1-->
  </head>

  <body>
    <section class="hero is-success is-fullheight">
      <div class="hero-body">
        <div class="container has-text-centered">
          <div class="column is-4 is-offset-4">
            <h3 class="title has-text-grey">MIS</h3>
            <p class="subtitle has-text-grey">Please login to proceed.</p>
            <div class="box">
              <figure class="avatar">
                <img src="https://placehold.it/128x128">
              </figure>
              <div class="field">
                <div class="control">
                  <input
                    class="input is-large"
                    v-validate="'required'"
                    type="text"
                    name="username"
                    placeholder="Your username"
                    v-model="login.username"
                  >
                  <span class="has-text-danger">{{ errors.first('username') }}</span>
                </div>
              </div>

              <div class="field">
                <div class="control">
                  <input
                    class="input is-large"
                    v-validate="'required'"
                    type="password"
                    name="password"
                    placeholder="Your Password"
                    v-model="login.password"
                  >
                  <span class="has-text-danger">{{ errors.first('password')}}</span>
                </div>
              </div>
              <div class="field">
                <label class="checkbox">
                  <input type="checkbox">
                  Remember me
                </label>
              </div>
              <button :class="loginButton" @click="loginUser" :disabled="!isValidationPassed">Login</button>
            </div>
            <p class="has-text-grey">
              <a href="#">Need Help? Please contact us</a>
            </p>
          </div>
        </div>
      </div>
    </section>
  </body>
</div>
</template>
<script>
import Vue from "vue";
import VeeValidate from "vee-validate";

Vue.use(VeeValidate);

export default {
  data() {
    return {
      login: {},
      loginButton: this.isLoggingIn(false)
    };
  },
  computed: {
    isValidationPassed() {
      return this.login.username && this.login.password;
    }
  },
  methods: {
    loginUser() {
      if (this.login) {
        this.loginButton = this.isLoggingIn(true);

        this.$axios
          .post(`api/users/authenticate`, this.login)
          .then(response => {
            if (response.data && !response.data.hasError) {
              localStorage.setItem("_t", response.data);
              window.location.href = "/";
              //this.$router.push("/");
            }else{
                alert(response.data.message);
            }
          })
          .catch(error => {
            alert(error.response.data);
          })
          .then(() => {
            this.loginButton = this.isLoggingIn(false);
          });
      }
    },
    isLoggingIn(val) {
      if (val) {
        return "button is-block is-info is-large is-fullwidth is-loading";
      } else {
        return "button is-block is-info is-large is-fullwidth";
      }
    }
  }
};
</script>

<style>
html,
body {
  font-family: "Open Sans", serif;
  font-size: 14px;
  font-weight: 300;
}
.hero.is-success {
  background: #f2f6fa;
}
.hero .nav,
.hero.is-success .nav {
  -webkit-box-shadow: none;
  box-shadow: none;
}
.box {
  margin-top: 5rem;
}
.avatar {
  margin-top: -70px;
  padding-bottom: 20px;
}
.avatar img {
  padding: 5px;
  background: #fff;
  border-radius: 50%;
  -webkit-box-shadow: 0 2px 3px rgba(10, 10, 10, 0.1),
    0 0 0 1px rgba(10, 10, 10, 0.1);
  box-shadow: 0 2px 3px rgba(10, 10, 10, 0.1), 0 0 0 1px rgba(10, 10, 10, 0.1);
}
input {
  font-weight: 100;
}
p {
  font-weight: 700;
}
p.subtitle {
  padding-top: 1rem;
}
</style>
