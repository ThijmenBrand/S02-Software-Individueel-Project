<template>
  <div class="task-card" :attr="taskId" @click="openTask">
    <div class="task-content">
      <h3>{{ task.taskName }}</h3>
      <p>{{ cutDescription(task.taskDescription) }}</p>
    </div>
  </div>
</template>

<script lang="ts">
import TaskModel from "@/models/tasks/Taskmodel";
import { computed } from "vue";
export default {
  name: "TaskCard",
  props: {
    task: {
      type: Object as () => TaskModel,
      required: true,
    },
  },
  emits: ["open-modal"],
  setup(props: any, { emit }: any) {
    const taskId = computed(() => {
      return props.task.taskId;
    });

    const openTask = (): void => {
      emit("open-modal", props.task);
    };

    const cutDescription = (taskDescription: string): string => {
      const maxLength = 100;
      return taskDescription.length <= maxLength
        ? taskDescription
        : taskDescription.substring(0, maxLength) + "...";
    };

    return { taskId, openTask, cutDescription };
  },
};
</script>

<style scoped>
.task-content {
  padding: 2px 5px 2px 5px;
}
.task-card {
  width: 100%;
  border-radius: 10px;
  background-color: rgb(233, 233, 233);
  margin-bottom: 10px;
  max-height: 170px;
  cursor: pointer;
}
.el-card__body {
  display: none;
}
p {
  word-wrap: break-word;
}
</style>