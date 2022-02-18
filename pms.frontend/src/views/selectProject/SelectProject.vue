<template>
  <h1 class="pageHeader">My projects</h1>
  <projects-table :projects="projects" />
</template>

<script lang="ts">
import ProjectsTable from "./components/ProjectsTable.vue";
import { useStore } from "vuex";
import { computed, onMounted } from "vue";

export default {
  name: "SelectProject",
  components: { ProjectsTable },
  setup() {
    const store = useStore();
    const projects = computed(() => store.state.projectList);
    onMounted(() => {
      store.dispatch("onFetchProjects");
    });

    return {
      projects,
    };
  },
};
</script>

<style>
.pageHeader {
  text-align: center;
  font-weight: 600;
  font-size: 45px;
  color: #153eaf;
}
</style>
