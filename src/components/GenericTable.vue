<template>
  <div>
    <h1>{{ localizedTitle }}</h1>
    <v-data-table
      dense
      :items="genericTable.items"
      :headers="headers"
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
    },
    headers(){
        return this.genericTable.headers.map( h => ({
            value: h.value,
            text: this.$t(`components.Tables.UserAdministration.${h.textkey}`)
        })) ;
    }
  },
};
</script>

<style>
</style>