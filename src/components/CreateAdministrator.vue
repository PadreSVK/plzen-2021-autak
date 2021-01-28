<template>
  <div>
    <ValidationObserver ref="validator">
      <v-text-field-validateable
        rules="alpha|min:3"
        :label="$t('components.CreateAdministrator.name')"
        v-model="administrator.name"
      />
      <v-text-field
        :label="$t('components.CreateAdministrator.note')"
        v-model="administrator.note"
      />
    </ValidationObserver>
    <v-btn @click="create">
      {{ $t("components.CreateAdministrator.saveButton") }}
    </v-btn>
  </div>
</template>

<script>
export default {
  name: "CreateAdministrator",
  data: () => ({
    administrator: {
      note: undefined,
      name: undefined,
    },
  }),
  methods: {
    async create() {
      const isValid = await this.$refs.validator.validate();
      if (isValid) {
        this.$emit("create-event", { administrator: this.administrator });
      }
    },
  },
};
</script>

<style>
</style>