<template>
  <BaseModalDialog
    title="Editace administratora aut"
    width="50%"
    @load-modal-state-event="loadState"
  >
    <template #showbutton="{ on }">
      <slot name="showbutton" v-bind:on="on" />
    </template>

    <template #body>
      <ValidationObserver ref="validator">
        <v-text-field-validateable
          rules="alpha|min:3"
          :label="$t('components.CreateAdministrator.name')"
          v-model="model.name"
        />
        <v-text-field
          :label="$t('components.CreateAdministrator.note')"
          v-model="model.note"
        />
      </ValidationObserver>
    </template>

    <template #footer="{ close }">
      <v-btn @click="close">Zrušit</v-btn>
      <v-spacer />
      <v-btn @click="save(close)">Uložit</v-btn>
    </template>
  </BaseModalDialog>
</template>

<script>
import { deepClone } from "@/utils";
import { BaseModalDialog } from "@/components";

export default {
  name: "EditAdministratorModalDialog",
  components: {
    BaseModalDialog,
  },
  props: {
    admistratorModel: {
      type: Object,
    },
  },

  data: () => ({
    model: {
      name: "",
      note: "",
    },
  }),
  methods: {
    async save(close) {
      const isValid = await this.$refs.validator.validate();
      if (isValid) {
        this.$emit("save-event", { administrator: this.model });
        this.model = {
          note: undefined,
          name: undefined,
        };
        close();
      }
    },
    loadState() {
      this.model = deepClone(this.admistratorModel);
    },
  },
};
</script>

<style>
</style>