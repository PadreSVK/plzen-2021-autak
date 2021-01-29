<template>
  <div>
    <h1>{{ $t("components.Tables.UserAdministration.Title") }}</h1>
    <v-data-table
      dense
      :items="items"
      :headers="headers"
      class="elevation-1"
    ></v-data-table>
  </div>
</template>

<script>
export default {
  name: "UserAdministration",
  props: ["items"],
  data: () => ({
    headers: [
      { text: this.$t("components.Tables.UserAdministration.Name"), value: "name" },
      { text: "Poznamka", value: "note" },
    ],
  }),
};
</script>

<style>
</style>