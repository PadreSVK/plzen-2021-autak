<template>
  <div>
    <h2>{{ $t("components.Tables.CarAdministration.Title") }}</h2>
    <v-data-table
      dense
      :items="items"
      :headers="headers"
      class="elevation-1"
      :options.sync="pagination"
    >
      <template v-for="h in headers" v-slot:[`header.name`]="{ header }">
        <v-text-field
          :key="`${h.text}+${h.value}.text`"
          @click.stop="stopEvent"
          :label="header.text"
          v-model="pagination.filterName"
        >
        </v-text-field>
      </template>

      <template #item.name="{ item }">
        <p class="namestyle">{{ item.name }}</p>
      </template>
    </v-data-table>
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
    pagination: undefined,
  }),

  mounted() {
    const pageQuery = this.$route.query.page;
    const itemsPerPageQuery = this.$route.query.itemsPerPage;

    if (pageQuery) {
      this.pagination.page = Number(pageQuery);
    }
    if (itemsPerPageQuery) {
      this.pagination.itemsPerPage = Number(itemsPerPageQuery);
    }
  },

  watch: {
    pagination: {
      handler(newVal) {
        this.$router.push({ query: { ...newVal } });
        this.$store.dispatch("loadCarAdmninistratorData", {
          pagination: newVal,
        });
      },
      deep: true,
    },
  },
  methods: {
    stopEvent() {},
    updateFilter(e) {
      console.log();

      console.log(e);
    },
  },
};
</script>

<style>
.namestyle {
  color: red;
}
</style>