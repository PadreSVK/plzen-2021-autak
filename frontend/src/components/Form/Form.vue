<template>
  <div>
    <ValidationObserver ref="validator">
      <component
        v-for="(elementMetadata, i) in formModel.elementsMetadata"
        :is="elementMetadata.type"
        v-bind="{
          value: formModel.item[elementMetadata.key],
          metadata: elementMetadata,
        }"
        :key="`${elementMetadata.key}.${i}`"
      >
      </component>
    </ValidationObserver>
    <v-btn color="success" @click="save">Save</v-btn>
  </div>
</template>

<script>
import FormDate from "@/components/Form/FormDate.vue";
import FormText from "@/components/Form/FormText.vue";

export default {
  name: "Form",
  components: {
    FormDate,
    FormText,
  },
  props: {
    formModel: {
      type: Object,
      required: true,
      validator: (value) =>
        Object.prototype.hasOwnProperty.call(value, "item") &&
        Object.prototype.hasOwnProperty.call(value, "elementsMetadata"),
    },
  },
  methods: {
    async save() {
      const isValid = await this.$refs.validator.validate();
      if (isValid) {
        //emit event or vuex
        // this.$emit("save-event", { administrator: this.model });
      }
    },
  },
};
</script>

<style>
</style>