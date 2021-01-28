<template>
  <div>
    <h1>Administration</h1>
    <v-data-table
      dense
      :items="carAdministrators"
      :headers="headers"
      class="elevation-1"
    ></v-data-table>

    <CreateAdministrator @create-event="addAdministrator" />
  </div>
</template>

<script>
import { CreateAdministrator } from "@/components";
import { mapState } from "vuex";

export default {
  name: "Administration",
  components: {
    CreateAdministrator,
  },
  computed: { ...mapState(["carAdministrators"]) },

  data() {
    return {
      headers: [
        { text: "Spravce", value: "name" },
        { text: "Poznamka", value: "note" },
      ],
      filter: {
          value: "filterValue"
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