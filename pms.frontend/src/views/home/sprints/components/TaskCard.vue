<template>
  <div class="task-card" :attr="taskId" @click="openTask">
    <div class="task-content">
      <div class="header">
        <p class="task-number">{{ task.taskId }}</p>
        <h3 class="task-title">{{ task.taskName }}</h3>
      </div>
      <div class="task-state-field">
        State:
        <div :class="task.taskTag + '-task'" class="state-elipse"></div>
        {{ task.taskTag }}
      </div>
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

<style scoped lang="scss">
.header {
  display: flex;
  justify-content: space-around;
  align-items: center;
}
.task-content {
  padding: 2px 5px 2px 5px;

  .task-number,
  .task-title {
    display: inline-block;
  }

  .task-title {
    margin-left: 20px;
  }
}
.task-card {
  width: 100%;
  border-radius: 10px;
  background-color: rgb(233, 233, 233);
  margin-bottom: 10px;
  cursor: pointer;
}
.el-card__body {
  display: none;
}
p {
  word-wrap: break-word;
}
</style>