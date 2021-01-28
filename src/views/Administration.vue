<template>
  <v-container>
    <CarAdministration :items="carAdministrators" />
    <CreateAdministrator @create-event="addAdministrator" />
  </v-container>
</template>

<script>
import { CreateAdministrator } from "@/components";
import { CarAdministration } from "@/components/Tables";
import { mapState } from "vuex";

export default {
  name: "Administration",
  components: {
    CreateAdministrator,
    CarAdministration,
  },
  computed: { ...mapState(["carAdministrators"]) },

  data() {
    return {
      headers: [
        { text: "Spravce", value: "name" },
        { text: "Poznamka", value: "note" },
      ],
      filter: {
        value: "filterValue",
      },
    };
  },
  methods: {
    async validate() {
      const isValid = await this.$refs.validator.validate();
      if (isValid) {
        console.log("Is Valid");
      } else {
        console.log("Is Invalid");
      }
    },
    addAdministrator({ administrator }) {
      this.filter;
      this.$store.dispatch("addCarAdministrator", {
        administrator,
        filter: this.filter,
      });
    },
  },
};
</script>

<style>
</style>