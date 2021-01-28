<template>
  <div>
    <h1>Administration</h1>
    <v-data-table
      dense
      :items="carAdministrators"
      :headers="headers"
      class="elevation-1"
    ></v-data-table>
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
      headers:[
          { text: 'Spravce', value: 'name' },
          { text: 'Poznamka', value: 'note' }
      ]
    };
  },
};
</script>

<style>
</style>