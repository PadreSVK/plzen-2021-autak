<template>
  <div>
    <h2>{{ $t("components.Tables.CarAdministration.Title") }}</h2>
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
  name: "CarAdministration",
  props: ["items"],
  data: () => ({
    headers: [
      { text: "Spravce", value: "name" },
      { text: "Poznamka", value: "note" },
    ],
  }),
};
</script>

<style>
</style>