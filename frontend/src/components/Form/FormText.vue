<template>
  <v-text-field-validateable
    :rules="metadata.validationRules"
    :label="metadata.label"
    v-model="innerValue"
  />
</template>

<script>
export default {
  name: "TableText",
  props: ["value", "metadata"],
  watch: {
    value: {
      handler(newValue) {
        this.innerValue = newValue;
      },
      immediate: true,
    },
  },
  data: () => ({
    innerValue: undefined,
  }),
};
</script>

<style>
</style>