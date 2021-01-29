<template>
  <v-data-table
    :items="items"
    :headers="headers"
    :server-items-length="totalItems"
    :options.sync="pagination"
    @click:row="rowSelected"
  >
    <template
      v-for="header in headers"
      v-slot:[createItemSlotName(header)]="{ value }"
    >
      <component :key="header.value" :is="header.type" v-bind="{ value }" />
    </template>
  </v-data-table>
</template>

<script>
import { TableText, TableDate } from "@/components";

export default {
  name: "Table",
  components: {
    TableDate,
    TableText,
  },
  props: {
    tableModel: {
      type: Object,
      required: true,
      validator: (value) =>
        Object.prototype.hasOwnProperty.call(value, "items") &&
        Object.prototype.hasOwnProperty.call(value, "headers"),
    },
  },
  data: () => ({
    pagination: undefined,
  }),
  methods: {
    createItemSlotName({ value }) {
      return `item.${value}`;
    },
    rowSelected(value) {
      this.$emit("item-selected-event", { item: value });
    },
  },
  watch: {
    pagination(newValue) {
      this.$emit("load-data-event", { pagination: newValue });
    },
  },
  computed: {
    items() {
      return this.tableModel?.items;
    },
    headers() {
      return this.tableModel?.headers;
    },
    totalItems() {
      return this.tableModel?.totalItems;
    },
  },
};
</script>

<style>
</style>