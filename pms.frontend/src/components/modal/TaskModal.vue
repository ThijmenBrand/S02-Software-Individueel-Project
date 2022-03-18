<template>
  <div class="modal-backdrop">
    <div class="modal">
      <header class="modal-header">
        <h4>{{ task.taskId }}</h4>
        <input v-model="task.taskName" class="task-title" />
        <div class="btn-container">
          <button type="button" class="btn" @click="close">
            <TopRight class="icon" />
          </button>
          <button type="button" class="btn" @click="close">
            <Close class="icon" />
          </button>
        </div>
      </header>
      <section class="modal-options">
        <div class="task-state-field">
          State:
          <div :class="task.taskTag + '-task'" class="state-elipse"></div>
          {{ task.taskTag }}
        </div>
        <div class="content-container">
          <button type="button" class="btn-default" @click="save">
            Save<Checked class="icon" />
          </button>
          <MoreFilled class="more-icon icon" @click="openOptions()" />
          <div class="options" v-if="optionsOpen">
            <div class="options-item" @click="deleteTask(task.taskId)">
              <Delete /> Delete
            </div>
          </div>
        </div>
      </section>
      <section class="modal-main-content">
        <div class="description">
          <h5>Description</h5>
          <textarea
            v-model="task.taskDescription"
            placeholder="Add a description"
            class="task-description"
          />
        </div>
        <div class="schedule">
          <h5>Schedule</h5>
          <ElDatePicker
            v-model="scheduleDate"
            type="date"
            placeholder="Pick a day"
          />
        </div>
      </section>
    </div>
  </div>
</template>


<script lang="ts">
import TaskModel from "@/models/tasks/Taskmodel";
import { ElDatePicker } from "element-plus";
import {
  Close,
  TopRight,
  MoreFilled,
  Checked,
  Delete,
} from "@element-plus/icons-vue";
import { computed, ref } from "vue";
import { useStore } from "vuex";
export default {
  name: "Modal",
  components: { Close, TopRight, MoreFilled, Checked, Delete, ElDatePicker },
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

    const optionsOpen = ref(false);

    const openOptions = () => {
      optionsOpen.value
        ? (optionsOpen.value = false)
        : (optionsOpen.value = true);
    };

    const deleteTask = (taskId: number) => {
      console.log("delete task" + taskId);
    };

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
      emit("save", task.value);
    };

    return {
      close,
      save,
      task,
      formatDate,
      deleteTask,
      optionsOpen,
      openOptions,
    };
  },
};
</script>

<style scoped lang="scss">
@import "@/styles/variables/colors.scss";
.icon {
  width: 20px;
  height: 20px;
}

.modal-header {
  padding: 15px;
  display: flex;
  position: relative;
  color: $pms-gray;
  justify-content: space-between;

  h4 {
    font-weight: 400;
  }

  .task-title {
    font-size: 20px;
    font-weight: lighter;
    border: none;
    width: 90%;
  }

  .btn-container {
    display: flex;
    top: 15px;
    right: 10px;
  }
}

.modal-options {
  display: flex;
  justify-content: space-between;
  width: 100%;
  .more-icon {
    padding: 10px;
    margin-right: 10px;
    transform: rotate(90deg);
    cursor: pointer;
  }
  .content-container {
    margin-right: 20px;
  }
  .btn-default {
    cursor: pointer;
    color: white;
    display: flex;
    justify-content: space-around;
    align-items: center;
    background: $pms-blue;
    border: none;
    border-radius: 4px;
    padding: 7px;
    float: right;
  }
  .state-elipse {
    height: 10px;
    width: 10px;
    border-radius: 50%;
    display: inline-block;
  }

  .task-state-field {
    margin-left: 20px;

    display: flex;
    flex-direction: row;
    width: 100px;
    align-content: center;
    justify-content: space-between;
    align-items: center;
  }

  .options {
    display: flex;
    justify-content: space-evenly;
    flex-direction: column;
    z-index: 1000;
    background-color: white;
    width: 100px;
    height: 30px;
    position: absolute;
    border: 1px solid black;
    -webkit-box-shadow: 1px 0px 4px -2px #000000;
    box-shadow: 1px 0px 4px -2px #000000;

    .options-item {
      cursor: pointer;
      display: flex;
      align-items: center;
      justify-content: space-evenly;
    }
  }
}

.modal-main-content {
  h5 {
    font-weight: 400;
  }

  display: flex;
  justify-content: space-between;

  .description {
    width: 50%;
    height: 200px;
    padding: 20px;
    display: inline-block;

    .task-description {
      resize: none;
      width: 100%;
      height: 100%;
      border: none;
    }
  }

  .schedule {
  }
}

.modal-backdrop {
  position: fixed;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  z-index: 100;
  background-color: rgba(0, 0, 0, 0.3);
  display: flex;
  justify-content: center;
  align-items: center;
}

.modal {
  background: #ffffff;
  height: 70%;
  width: 80%;
  overflow-x: auto;
  display: flex;
  flex-direction: column;
  position: relative;
  border-radius: 10px;
}

.modal-footer {
  position: absolute;
  bottom: 0;
}

.modal-body {
  position: relative;
  padding: 20px 10px;
}

.btn {
  border: none;
  font-size: 20px;
  padding: 5px;
  cursor: pointer;
  font-weight: bold;
  color: $pms-blue;
  background: transparent;
}
</style>
