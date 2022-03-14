<template>
  <div class="modal-backdrop">
    <div class="modal">
      <button type="button" class="btn-close" @click="close">X</button>
      <div>
        <div class="modal-left-container">
          <header class="modal-header">
            <p class="task-tag" :class="task.taskTag + '-tag'">
              {{ task.taskTag }}
            </p>
            <input v-model="task.taskName" class="task-title" />
          </header>

          <section class="modal-body">
            <textarea
              v-model="task.taskDescription"
              placeholder="Add a description"
              class="task-description"
            />
          </section>
        </div>
        <div class="modal-right-container">
          <div class="modal-right-time">
            <p>Schedule</p>
            <div v-if="task.taskStartTime == '0001-01-01T00:00:00'">
              <p class="modal-right-time-content">No date set yet</p>
            </div>
            <div v-else>
              <p class="modal-right-time-content">
                From: {{ formatDate(task.taskStartTime) }}
              </p>
              <p class="modal-right-time-content">
                To: {{ formatDate(task.taskEndTime) }}
              </p>
            </div>
          </div>
        </div>
      </div>

      <footer class="modal-footer">
        <button type="button" class="btn-default" @click="save">Save</button>
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
  emits: ["close", "save"],
  props: {
    taskId: {
      type: Number,
      required: true,
      default: () => 0,
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
    const formatDate = (date: string): string => {
      if (date == undefined) return "";

      const today = new Date();
      const inputDate = new Date(date);

      if (inputDate.setHours(0, 0, 0, 0) == today.setHours(0, 0, 0, 0))
        return date.split("T")[1];

      const day = date
        .split("T")[0]
        .split("-")
        .reverse()
        .join("-")
        .substring(0, 5);

      const time = date.split("T")[1].substring(0, 5);
      return day + " " + time;
    };
    const close = () => {
      emit("close", task);
    };
    const save = () => {
      emit("save", task);
    };

    return { close, save, task, formatDate };
  },
};
</script>

<style scoped lang="scss">
@import "@/styles/variables/colors.scss";

.modal-left-container {
  float: left;
  width: 70%;
}
.modal-right-time-content {
  font-size: 12px;
}
.modal-right-container {
  float: right;
  width: 30%;
  margin-top: 30px;
}

.task-title {
  font-size: 20px;
  border: none;
  width: 90%;
}

.task-tag {
  border-radius: 50px;
  font-size: 10px;
  padding: 2px 5px 2px 5px;
}

.task-description {
  border: none;
  width: 100%;
  font-size: 14px;
  resize: none;
  height: 100px;
}

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
  width: 50%;
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
