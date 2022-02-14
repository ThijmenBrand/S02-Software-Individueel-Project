<template>
  <div class="content">
    <tr>
      <th>Project name</th>
      <th>Project owner</th>
      <th>Created on</th>
    </tr>
    <tr v-for="project in projects" :key="project.projectId">
      <td>{{ project.projectName }}</td>
      <td>{{ project.projectDescription }}</td>
      <td>{{ project.projectDate }}</td>
    </tr>
  </div>
</template>

<script lang="ts">
export default {
  props: {
    projects: { type: Array, required: true },
  },
};
</script>

<style scoped>
.content {
  width: 300px;
  margin: auto;
}
</style>
