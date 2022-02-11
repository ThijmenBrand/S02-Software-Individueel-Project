<template><router-view /></template>

<script lang="ts">
import { Options, Vue } from "vue-class-component";

@Options({
  name: "app",
})
export default class Home extends Vue {}
</script>
