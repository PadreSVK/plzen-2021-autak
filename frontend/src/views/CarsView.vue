<template>
  <v-container>
    <h2>Car edit</h2>
    <Form v-if="selectedCar" :formModel="selectedCar" />

    <v-divider />
    <h2>Cars</h2>

    <Table
      :tableModel="datamodel"
      @load-data-event="loadData"
      @item-selected-event="editCar"
    />
  </v-container>
</template>

<script>
import { Table, Form } from "@/components";
import { GET } from "@/services/apiService";

export default {
  name: "CarsView",
  components: {
    Form,
    Table,
  },

  data: () => ({
    datamodel: {
      items: [],
      headers: [],
    },
    selectedCar: undefined,
  }),
  methods: {
    async loadData({ pagination }) {
      this.datamodel = await GET("CarAdministration/cars", {
        params: pagination,
      });
    },
    editCar({ item }) {
      console.log(item);
      this.selectedCar = {
        item,
        elementsMetadata: this.datamodel.elementsMetadata,
      };
    },
  },
};
</script>

<style>
</style>