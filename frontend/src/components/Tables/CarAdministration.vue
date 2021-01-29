<template>
  <div>
    <h2>{{ $t("components.Tables.CarAdministration.Title") }}</h2>
    <v-data-table
      dense
      :items="items"
      :headers="headers"
      :server-items-length="totalItems"
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
      <template #item.buttons="{ item }">
        <!-- <component :is="item.componentType" v-bind="item"/> -->
        <EditAdministratorModalDialog
          :admistratorModel="item"
          @save-event="save"
        >
          <template #showbutton="{ on }">
            <v-btn icon color="success" x-small v-on="on">
              <v-icon>mdi-pencil</v-icon>
            </v-btn>
          </template>
        </EditAdministratorModalDialog>
      </template>
    </v-data-table>
  </div>
</template>

<script>
import { EditAdministratorModalDialog } from "@/components";

export default {
  name: "CarAdministration",
  components: {
    EditAdministratorModalDialog,
  },
  props: ["tableModel"],
  data: () => ({
    headers: [
      { text: "Spravce", value: "name" },
      { text: "Poznamka", value: "note" },
      { value: "buttons" },
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
  computed: {
    items() {
      return this.tableModel?.items;
    },
    totalItems() {
      return this.tableModel?.totalItems;
    },
  },

  watch: {
    pagination: {
      handler(newVal) {
        console.log(newVal);
        this.$emit("pagination-changed-event", { pagination: newVal });
      },
      deep: true,
    },
  },
  methods: {
    stopEvent() {},
    updateFilter(e) {
      console.log(e);
    },
    save({ administrator }) {
      console.log(administrator);
    },
  },
};
</script>

<style>
.namestyle {
  color: red;
}
</style>