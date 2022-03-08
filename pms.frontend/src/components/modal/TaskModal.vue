<template>
  <div class="modal-backdrop">
    <div class="modal">
      <header class="modal-header">
        <div><input v-model="task.taskName" /></div>
        <button type="button" class="btn-close" @click="close">X</button>
      </header>

      <section class="modal-body">
        <slot name="body"> This is the default body </slot>
      </section>

      <footer class="modal-footer">
        <button type="button" class="btn-default" @click="close">Save</button>
      </footer>
    </div>
  </div>
</template>


<script lang="ts">
import TaskModel from "@/models/tasks/Taskmodel";

import { computed, ref } from "vue";
import { useStore } from "vuex";
export default {
  name: "Modal",
  emits: ["close"],
  props: {
    taskId: {
      type: Number,
      required: true,
    },
  },
  setup(props: any, { emit }: any) {
    const store = useStore();

    const task = computed((): TaskModel => {
      const allTasks: TaskModel[] = store.getters["sprints/getTasks"];
      const applyingTask: TaskModel | undefined = allTasks.find(
        (t) => t.taskId == props.taskId
      );

      return applyingTask != undefined
        ? applyingTask
        : new TaskModel({
            taskId: 0,
            taskName: "",
            taskDescription: "",
            taskStart: new Date(),
            taskEnd: new Date(),
            taskTag: "",
          });
    });
    const close = () => {
      emit("close", task);
    };

    return { close, task };
  },
};
</script>

<style lang="scss">
@import "@/styles/variables/colors.scss";

.modal-backdrop {
  position: fixed;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  background-color: rgba(0, 0, 0, 0.3);
  display: flex;
  justify-content: center;
  align-items: center;
}

.modal {
  background: #ffffff;
  height: 50%;
  width: 60%;
  overflow-x: auto;
  display: flex;
  flex-direction: column;
  position: relative;
  border-radius: 10px;
}

.modal-header,
.modal-footer {
  padding: 15px;
  display: flex;
}

.modal-header {
  position: relative;
  color: $pms-gray;
  justify-content: space-between;
}

.modal-footer {
  position: absolute;
  bottom: 0;
  width: 94%;
  justify-content: right;
}

.modal-body {
  position: relative;
  padding: 20px 10px;
}

.btn-close {
  position: absolute;
  top: 0;
  right: 0;
  border: none;
  font-size: 20px;
  padding: 10px;
  cursor: pointer;
  font-weight: bold;
  color: $pms-blue;
  background: transparent;
}

.btn-default {
  cursor: pointer;
  color: white;
  background: $pms-blue;
  border: none;
  border-radius: 4px;
  padding: 10px;
  float: right;
}
</style>
