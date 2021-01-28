<template>
  <div>
    <h1>Administration</h1>
    <v-data-table
      dense
      :items="carAdministrators"
      :headers="headers"
      class="elevation-1"
    ></v-data-table>

    <ValidationObserver ref="validator">
      <v-text-field-validateable
        rules="mySecretRule"
        label="Meno"
        v-model="testValue"
        @change="changed"
      />
    </ValidationObserver>

    <v-btn @click="validate" >Validate</v-btn>
  </div>
</template>

<script>
export default {
  name: "Administration",
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
      testValue: "aaa",
    };
  },
  methods:{
      async validate(){
          const isValid = await this.$refs.validator.validate();
          if(isValid){
              console.log("Is Valid");
          }
          else{
              console.log("Is Invalid");
          }
      },
      changed(){
          console.log("changed");
      }
  }
};
</script>

<style>
</style>