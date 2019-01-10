<template>
  <div>
    <div class="container-fluid mt-3">
      <div class="row">
        <div class="col-4 mx-auto">
          <glitch-image/>
          <br>
          <br>
          <div class="form">
            <div class="form-group row">
              <div class="mx-auto">
                <label class="label-thing mx-auto" for="username">★Username:</label>
                <input
                  v-validate="'alpha|required'"
                  v-model="userInfo.username"
                  data-vv-as="field"
                  name="username"
                  placeholder="Username"
                  type="text"
                  class="input-thing"
                  :class="{'alert-danger': errors.has('username')}"
                >
              </div>
            </div>
            <div class="form-group row">
              <div class="mx-auto">
                <label class="label-thing" for="password">Password:</label>
                <input
                  v-validate="'required'"
                  v-model="userInfo.password"
                  data-vv-as="field"
                  name="password"
                  placeholder="Password"
                  type="password"
                  class="input-thing"
                  :class="{'alert-danger': errors.has('password')}"
                >
              </div>
            </div>
            <div class="row">
              <b-button class="btn mx-auto login" @click="validateInput()">Log In</b-button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { getToken } from "@/api/Authentication.js";
import { decode } from "@/Helper/JWT.js";
import glitchImage from "../admin/glitchImage";

export default {
  components: {
    glitchImage
  },
  name: "LogIn",
  data() {
    return {
      logInFailure: false,
      userInfo: { username: "", password: "" }
    };
  },
  methods: {
    logIn() {
      getToken(this.userInfo)
        .then(response => {
          console.log(response);
          localStorage.token = response.token;

          localStorage.loggedIn = true;
          console.log(localStorage.loggedIn);
          this.$router.push({ path: "/admin" });
        })
        .catch(error => {
          console.log("ERRRRRRORROROROR or failed login");
          console.log(error);
        });
    },
    validateInput() {
      let self = this;
      self.$validator.validate().then(result => {
        if (result) {
          self.logIn();
        }
      });
    }
  }
};
</script>

<style>
@import url("https://fonts.googleapis.com/css?family=Arizonia");

.label-thing {
  font-size: 1.2em;
}

.input-thing {
  color: #ffe6ff;
  border: none;
  background: none;
  border-bottom: #ffe6ff;
  border-bottom-color: #ffe6ff;
  border-bottom-width: 3px;
  border-bottom: 4px solid #ffe6ff;
  outline: none;
}

html,
body {
  background: linear-gradient(
    to bottom right,
    #f056ff 0%,
    #2989d8 50%,
    #00fffa 100%
  );
  color: pink;
  background-attachment: fixed;
  height: 100%;
}
</style>
