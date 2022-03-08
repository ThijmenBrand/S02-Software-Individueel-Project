<template>
  <tr style="width: 100%">
    <td class="task-item">{{ task.taskName }}</td>
  </tr>
</template>

<script lang="ts">
import TaskModel from "@/models/tasks/Taskmodel";

export default {
  props: {
    task: {
      type: Object as () => TaskModel,
      required: true,
    },
  },
};
</script>

<style scoped>
.task-item {
  background-color: white;
  padding: 10px;
  border-radius: 10px;
}
</style>