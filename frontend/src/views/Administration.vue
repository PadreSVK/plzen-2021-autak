<template>
  <v-container>
    <CarAdministration
      :tableModel="carAdministratorsDataTableModel"
      @pagination-changed-event="loadData"
    />
    <CreateAdministrator @create-event="addAdministrator" />
    <BaseModalDialog title="Moj haha dialog" width="50%">
      <template #showbutton="{ on }">
        <v-btn v-on="on"> Open Dialog from template</v-btn>
      </template>

      <template #footer="{ close }">
        <v-btn @click="close">Cancel</v-btn>
        <v-spacer />
        <v-btn @click="save(close)">Save</v-btn>
      </template>
    </BaseModalDialog>
  </v-container>
</template>

<script>
import { CreateAdministrator, BaseModalDialog } from "@/components";
import { CarAdministration } from "@/components/Tables";
import { mapState } from "vuex";

export default {
  name: "Administration",
  components: {
    CreateAdministrator,
    CarAdministration,
    BaseModalDialog,
  },
  computed: { ...mapState(["carAdministratorsDataTableModel"]) },

  data() {
    return {
      headers: [
        { text: "Spravce", value: "name" },
        { text: "Poznamka", value: "note" },
      ],
      filter: {
        value: "filterValue",
      },
    };
  },
  methods: {
    async validate() {
      const isValid = await this.$refs.validator.validate();
      if (isValid) {
        console.log("Is Valid");
      } else {
        console.log("Is Invalid");
      }
    },
    addAdministrator({ administrator }) {
      this.filter;
      this.$store.dispatch("addCarAdministrator", {
        administrator,
        filter: this.filter,
      });
    },
    loadData({ pagination }) {
      this.$router.push({ query: { ...pagination } });
      this.$store.dispatch("loadCarAdministratorData", {
        pagination: pagination,
      });
    },
    save(close) {
      console.log("save item");
      close();
    },
  },
};
</script>

<style>
</style>