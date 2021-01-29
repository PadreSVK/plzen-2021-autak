<template>
  <v-data-table
    dense
    :items="items"
    :headers="headers"
    class="elevation-1"
    @click:row="rowSelected"
  ></v-data-table>
</template>

<script>
export default {
  name: "Table",
  props: ["tableModel"],
  computed: {
    items() {
      return this.tableModel?.items;
    },
    headers() {
      return this.tableModel?.totalItems;
    },
  },
  methods: {
    rowSelected(item) {
      this.$emit("item-selected-event", { item: item });
    },
  },
};
</script>

<style>
</style>