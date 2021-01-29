<template>
  <v-dialog
    v-model="showModal"
    :width="width"
    scrollable
    :persistent="persistent"
  >
    <template #activator="{ on }">
      <slot name="showbutton" v-bind:on="on" />
    </template>

    <v-card v-if="showModal">
      <v-card-title>
        <h3>{{ title }}</h3>
      </v-card-title>
      <v-card-text>
        <slot name="body" />
      </v-card-text>
      <v-card-actions>
        <slot name="footer" :close="close" />
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script>
export default {
  name: "BaseModalDialog",
  //   props: ["title", "width"],
  props: {
    title: {
      type: String,
      required: true,
    },
    persistent: {
      type: Boolean,
      default: true,
    },
    width: {
      type: String,
      default: "30%",
    },
  },
  data: () => ({
    showModal: false,
  }),
  watch:{
      showModal(newValue){
          if(newValue){
              this.$emit("load-modal-state-event")
          }
      }
  },
  methods: {
    close() {
      this.showModal = false;
    },
  },
};
</script>

<style>
</style>