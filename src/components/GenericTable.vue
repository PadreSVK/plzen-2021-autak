<template>
  <div>
    <h1>{{ localizedTitle }}</h1>
    <v-data-table
      dense
      :items="genericTable.items"
      :headers="genericTable.headers"
      class="elevation-1"
    ></v-data-table>
  </div>
</template>

<script>

export default {
  name: "GenericTable",
  props: ["genericTable"],
  computed: {
    localizedTitle(){
        return this.$t(`components.GenericTable.type.${this.genericTable.tableType}`)
    }
  },
};
</script>

<style>
</style>