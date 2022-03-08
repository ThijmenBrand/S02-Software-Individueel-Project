<template>
  <div class="task-card">
    <div>
      <ElInput
        v-model="taskName"
        @keyup.enter="addTask"
        placeholder="New task name"
      />
    </div>
  </div>
</template>

<script lang="ts">
import { ElInput } from "element-plus";
import { ref } from "vue";
import { useStore } from "vuex";
import { IBaseTaskShape } from "@/models/tasks/Taskmodel";
export default {
  name: "TaskCard",
  components: { ElInput },
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