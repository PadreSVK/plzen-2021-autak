<template>
  <ValidationObserver ref="validator">
    <v-text-field-validateable
      rules="alpha|min:3"
      :label="Nazev"
      v-model="model.name"
    />
    <v-text-field-validateable
      rules="min:3"
      :label="Spz"
      v-model="model.spz"
    />
    <v-text-field-validateable
      rules="min:3"
      :label="Typ"
      v-model="model.type"
    />
    <v-text-field
      :label="Administrator"
      v-model="model.administrator.name"
    />

    <BaseModalDialog title="Volba noveho administratora" width="70%">
      <template #showbutton="{ on }">
        <v-btn icon color="success" x-small @click="on">
          <v-icon>mdi-pencil</v-icon>
        </v-btn>
      </template>

      <template #body> </template>

      <template #footer="{ close }">
        <v-btn @click="close">Zrušit</v-btn>
        <v-spacer />
        <v-btn @click="save(close)">Vybrat</v-btn>
      </template>
    </BaseModalDialog>
  </ValidationObserver>
</template>

<script>
export default {};
</script>

<style>
</style>