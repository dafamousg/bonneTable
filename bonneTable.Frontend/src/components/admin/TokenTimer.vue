<template>
  <div>
    <div class="float-left mx-auto">
      <b-img class="img float-left" src="/static/token.jpg"/>
      <div class="bgtp float-left px-1 py-1">
        <h5>Token</h5>
        <div class="exp">
          Expires in:
          <span>{{ timeLeft }}</span>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { decode } from "@/Helper/JWT.js";

export default {
  name: "tokentimer",
  data() {
    return {
      timeLeft: 99
    };
  },
  methods: {
    timer() {
      decode(localStorage.token);
      console.log("timer");

      setInterval(this.doSomething, 1000);
    },
    doSomething() {
      console.log(this.timeLeft)
      this.timeLeft -= 1;
    }
  },
  created() {
    this.timer();
  }
};
</script>

<style scoped>
.bgtp {
  background: black;
  border: 2px solid white;
  border-radius: 5px;
  color: white;
  width: auto;
}

.img {
  border: 2px solid white;
  border-radius: 5px;
  width: 25%;
  height: auto;
}

.exp {
  color: rgb(255, 209, 0);
}
</style>
