<template>
  <v-container>
    <GenericTable :genericTable="genericTable1" />
    <GenericTable :genericTable="genericTable2" />
  </v-container>
</template>

<script>
import { mapState } from "vuex";
import { GenericTable } from "@/components";

export default {
  name: "GenericView",
  components: {
    GenericTable,
  },
  computed: {
    ...mapState(["genericTable1", "genericTable2"]),
  },
};
</script>

<style>
</style>