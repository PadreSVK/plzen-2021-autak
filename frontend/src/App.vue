<template>
  <v-app>
    <v-app-bar app color="primary" dark>
      <div class="d-flex align-center">
        <v-img
          alt="VIS Logo"
          class="shrink mr-2"
          contain
          :src="require('./assets/vis.png')"
          transition="scale-transition"
          width="80"
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
      <v-img
        :alt="getCurrentLocalization('localizations.en')"
        class="shrink mr-2"
        contain
        :src="require('./assets/us-flag.svg')"
        transition="scale-transition"
        width="40"
        @click="changeLocalization('en')"
      />
      <v-img
        :alt="getCurrentLocalization('localizations.cs')"
        class="shrink mr-2"
        contain
        :src="require('./assets/cs-flag.svg')"
        transition="scale-transition"
        width="40"
        @click="changeLocalization('cs')"
      />
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
      { title: "Generic View", routeName: "GenericView" },
      { title: "Generic View 2", routeName: "GenericView2" },
      { title: "CarsView", routeName: "CarsView" },
    ],
  }),
  methods: {
    changeLocalization(lang: string) {
      localize(lang);
      this.$i18n.locale = lang;
    },
    getCurrentLocalization(key: string) {
      return this.$t(`views.App.${key}`);
    },
  },
});
</script>
