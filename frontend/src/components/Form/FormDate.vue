<template>
  <v-dialog
    ref="dialog"
    v-model="modal"
    :return-value.sync="value"
    persistent
    width="290px"
  >
    <template v-slot:activator="{ on, attrs }">
      <v-text-field
        v-model="value"
        label="Picker in dialog"
        prepend-icon="mdi-calendar"
        readonly
        v-bind="attrs"
        v-on="on"
      ></v-text-field>
    </template>
    <v-date-picker v-model="value" scrollable>
      <v-spacer></v-spacer>
      <v-btn text color="primary" @click="modal = false"> Cancel </v-btn>
      <!-- <v-btn text color="primary" @click="$refs.dialog.save(date)"> OK </v-btn> -->
      <v-btn text color="primary"> OK </v-btn>
    </v-date-picker>
  </v-dialog>
</template>

<script>
export default {
  name: "TableText",
  props: ["value", "elementMetadata"],
  data: () => ({
    date: new Date().toISOString().substr(0, 10),
    modal: false,
  }),
};
</script>

<style>
</style>