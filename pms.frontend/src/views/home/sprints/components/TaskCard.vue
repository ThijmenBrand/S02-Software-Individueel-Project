<template>
  <ElCard class="task-card" :attr="taskId" @click="openTask">
    <div>
      <h3>{{ task.taskName }}</h3>
      <p>{{ task.taskDescription }}</p>
    </div>
  </ElCard>
</template>

<script lang="ts">
import { ElCard } from "element-plus";
import TaskModel from "@/models/tasks/Taskmodel";
import { computed } from "vue";
export default {
  name: "TaskCard",
  components: { ElCard },
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

    const openTask = () => {
      console.log("opening task");
      emit("open-modal", props.task);
    };

    return { taskId, openTask };
  },
};
</script>

<style scoped>
.task-card {
  width: 250px;
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