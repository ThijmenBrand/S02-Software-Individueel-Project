<template>
  <h1>Board</h1>
  <p>{{ currentProject }}</p>
</template>

<script>
import { useStore } from "vuex";
export default {
  setup() {
    const store = useStore();

    const currentProject = store.state.currentProject.projectName;

    return { currentProject };
  },
};
</script>

<style>
</style>