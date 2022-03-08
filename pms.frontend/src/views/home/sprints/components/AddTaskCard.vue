<template>
  <ElCard class="task-card">
    <div>
      <ElInput
        v-model="taskName"
        @keyup.enter="addTask"
        placeholder="New task name"
      />
    </div>
  </ElCard>
</template>

<script lang="ts">
import { ElCard, ElInput } from "element-plus";
import { ref } from "vue";
import { useStore } from "vuex";
import { IBaseTaskShape } from "@/models/tasks/Taskmodel";
export default {
  name: "TaskCard",
  components: { ElCard, ElInput },
  props: {
    containerName: {
      type: String,
      required: true,
    },
  },
  setup(props: any) {
    const store = useStore();
    const taskName = ref("");

    const addTask = () => {
      const taskDetails: IBaseTaskShape = {
        taskName: taskName.value,
        taskTag: props.containerName,
      };
      if (taskName.value != "") {
        store.dispatch("sprints/addTask", taskDetails);
      }
      taskName.value = "";
    };

    return { taskName, addTask };
  },
};
</script>

<style scoped>
.task-card {
  width: 250px;
  background-color: rgb(233, 233, 233);
  margin-bottom: 10px;
  max-height: 170px;
}
.el-card__body {
  display: none;
}
p {
  word-wrap: break-word;
}
</style>