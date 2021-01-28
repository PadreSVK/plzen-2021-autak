<template>
  <v-container>
    <component
      v-for="genericComponent in genericComponents"
      :key="genericComponent.tableType"
      :is="genericComponent.tableType"
      v-bind="genericComponent"
    />
  </v-container>
</template>

<script>
import { mapState } from "vuex";
import { CarAdministration, UserAdministration } from "@/components/Tables";

export default {
  name: "GenericView2",
  components: {
    CarAdministration,
    UserAdministration,
  },
  computed: {
    ...mapState(["genericComponents"]),
  },
};
</script>

<style>
</style>