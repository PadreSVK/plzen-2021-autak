<template>
  <v-app>
    <v-app-bar app color="primary" dark>
      <div class="d-flex align-center">
        <v-img
          alt="Vuetify Logo"
          class="shrink mr-2"
          contain
          src="https://cdn.vuetifyjs.com/images/logos/vuetify-logo-dark.png"
          transition="scale-transition"
          width="40"
        />

        <v-img
          alt="Vuetify Name"
          class="shrink mt-1 hidden-sm-and-down"
          contain
          min-width="100"
          src="https://cdn.vuetifyjs.com/images/logos/vuetify-name-dark.png"
          width="100"
        />

        <v-btn
          v-for="view in views"
          :key="view.title"
          :to="{ name: view.routeName }"
        >
          {{ view.title }}
        </v-btn>
      </div>

      <v-spacer></v-spacer>
      <v-btn @click="changeLocalization('en')">Change to US</v-btn>
      <v-btn @click="changeLocalization('cs')">Zmen do Cestiny</v-btn>
    </v-app-bar>

    <v-main>
      <router-view />
    </v-main>
  </v-app>
</template>

<script lang="ts">
import Vue from "vue";
import { localize } from "vee-validate";

export default Vue.extend({
  name: "App",
  data: () => ({
    views: [
      { title: "About", routeName: "About" },
      { title: "Home", routeName: "Home" },
      { title: "Administration", routeName: "Administration" },
    ],
  }),
  methods: {
    changeLocalization(lang: string) {
      localize(lang);
    },
  },
});
</script>
