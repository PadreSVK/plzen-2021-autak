<template>
  <div>
    <h1>Administration</h1>
    <v-data-table
      dense
      :items="carAdministrators"
      :headers="headers"
      class="elevation-1"
    ></v-data-table>

    <CreateAdministrator @create-event="addAdministrator" />
  </div>
</template>

<script>
import { CreateAdministrator } from "@/components";

export default {
  name: "Administration",
  components: {
    CreateAdministrator,
  },
  data() {
    return {
      carAdministrators: [
        { name: "Albert", note: "programator" },
        { name: "Fero", note: "manager" },
        { name: "Jozo", note: "správca" },
        { name: "Kevin", note: "manager" },
        { name: "Patrik", note: "programator" },
      ],
      headers: [
        { text: "Spravce", value: "name" },
        { text: "Poznamka", value: "note" },
      ],
      testValue: "aaa55",
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
    addAdministrator({administrator}) {
        this.carAdministrators.push(administrator)
    },
  },
};
</script>

<style>
</style>