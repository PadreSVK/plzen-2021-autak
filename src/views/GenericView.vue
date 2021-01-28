<template>
  <div>
    <GenericTable :genericTable="genericTable1" />
    <GenericTable :genericTable="genericTable2" />
  </div>
</template>

<script>
import { mapState } from "vuex";
import { GenericTable } from "@/components";

export default {
  name: "GenericView",
  components: {
    GenericTable,
  },
  computed: { ...mapState(["genericTable1", "genericTable2"]) },
};
</script>

<style>
</style>