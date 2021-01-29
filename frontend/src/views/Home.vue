<template>
  <div class="home">
    <HelloWorld :msg="testText" />
  </div>
</template>

<script>
import Vue from "vue";
import { HelloWorld } from "@/components"; // @ is an alias to /src

export default Vue.extend({
  name: "Home",
  components: {
    HelloWorld,
  },
  computed: {
    computedProperty() {
      return this.testText + " Ha";
    },
  },
  data() {
    return {
      testText: "Welcome Plzen to Your Vue.js + TypeScript App",
    };
  },
});
</script>
