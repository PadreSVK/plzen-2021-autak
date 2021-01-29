<template>
  <span>
    {{ value | humanizeDate }}
  </span>
</template>

<script>
export default {
  name: "TableDate",
  props: ["value"],
};
</script>

<style>
</style>