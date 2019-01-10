<template>
  <div>
    <glitchImage/>
    <div>
      <div class="container-fluid mt-3">
        <div class="row">
          <div class="col-6 mx-auto">
            <b-button-group>
              <button class="btn" @click="clickBookingMenu()">Booking</button>
              <b-button @click="clickTableMenu()">Tables</b-button>
              <b-button v-if="displayLogOut" @click="logOut()">Log out</b-button>
            </b-button-group>
            <router-view></router-view>
          </div>
        </div>
      </div>
    </div>
    <div class="col-8 mx-auto">
      <token-timer/>
      <Footer/>
    </div>
  </div>
</template>

<script>
import glitchImage from "../admin/glitchImage";
import Footer from "../admin/Footer";
import { getAll, book, getByDate, getByEmail, cancel } from "@/api/BookingAPI";
import { getTables } from "@/api/TableAPI";
import { formatTime } from "@/api/TimeFormatter";
import TableMenu from "../admin/TableMenu";
import BookingMenu from "../admin/BookingMenu";
import LogIn from "../admin/LogIn";
import TokenTimer from "../admin/TokenTimer";

export default {
  components: {
    LogIn,
    glitchImage,
    Footer,
    TokenTimer
  },
  name: "Admin",
  data() {
    return {
      displayBookingnMenu: true,
      displayTableMenu: false,
      displayLogIn: true,
      displayLogOut: true
    };
  },
  methods: {
    clickTableMenu() {
      this.displayTableMenu = true;
      this.displayBookingnMenu = false;

      this.$router.push({ path: "/admin/tablemenu" });
    },
    clickBookingMenu() {
      this.displayBookingnMenu = true;
      this.displayTableMenu = false;

      this.$router.push({ path: "/admin/bookingmenu" });
    },
    logOut() {
      localStorage.token = "";
      localStorage.loggedIn = false;
      this.displayLogOut = false;
      this.displaylogIn = true;
      this.$router.push({ path: "/login" });
    },
    notLoggedIn() {
      console.log("notloggedin: " + localStorage.loggedIn);
      console.log(localStorage.loggedIn);
      if (localStorage.loggedIn == "false") {
        console.log("notloggedin in if");

        this.$router.push({ path: "/login" });
      }
    }
  },
  created() {
    this.notLoggedIn();
  }
};
</script>

<style >
@import url("https://fonts.googleapis.com/css?family=Staatliches");

h1 {
  /* font-family: 'Times New Roman';
  font-size: 2em; */
}

.bg {
  color: pink;
  height: 100%;
  min-height: 100%;
}

.btn {
  border-color: #ffe6ff;
  border-width: 2px;
  color: #ffe6ff;
  background: none;
  font-family: "Staatliches", cursive;
}

.btn:hover {
  border-color: #99ffff;
  border-width: 2px;
  color: none;
  background: #99ffff;
}

.btn:active {
  border-color: #99ffff;
  border-width: 2px;
  color: #99ffff;
  background: none;
}

.btn:focus {
  border-color: #99ffff;
  border-width: 4px;
  color: #99ffff;
  background: none;
  box-shadow: #99ffff;
}

.btn.active {
  border-color: #99ffff;
  border-width: 4px;
  color: #99ffff;
  background: none;
  box-shadow: #99ffff;
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

.logo {
  max-width: 100px;
  height: auto;
}
</style>
