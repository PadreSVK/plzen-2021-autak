<template>
  <ValidationProvider
    :rules="rules"
    :name="$attrs.label"
    v-slot="{ errors }"
    :disabled="$attrs.disabled"
  >
    <v-text-field
      v-model="innerValue"
      v-bind="$attrs"
      v-on="$listeners"
      :error-messages="errors"
    />
  </ValidationProvider>
</template>

<script>
export default {
  name: "VTextFieldValidateable",
  props: {
    value: {
      type: null,
    },
    rules: {
      type: [Object, String],
      default: "",
    },
    serverErrors:{
        type: null,
    }
  },
  data: () => ({
    innerValue: "",
  }),
  watch: {
    value: {
      handler(newValue) {
        this.innerValue = newValue;
      },
      immediate: true,
    },
  },
};
</script>

<style>
</style>