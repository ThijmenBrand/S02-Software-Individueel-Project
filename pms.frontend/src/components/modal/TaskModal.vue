<template>
  <div class="modal-backdrop">
    <div class="modal">
      <loaderVue v-if="task.taskId == 0" />
      <div v-else>
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
            <h4>Description</h4>
            <textarea
              v-model="task.taskDescription"
              class="task-description"
              id="task-description"
            />
          </div>
          <div class="schedule">
            <h4>Task options</h4>
            <div>
              <p>Schedule</p>
              <el-date-picker
                v-model="date"
                type="datetimerange"
                range-separator="To"
                start-placeholder="Start date"
                end-placeholder="End date"
              />
            </div>
            <hr />
            <div>
              <p>Process state</p>
              <select v-model="task.taskTag" class="select-state">
                <option
                  v-for="container in containers"
                  :key="container.containerId"
                  :value="container.containerName"
                >
                  {{ container.containerName }}
                </option>
              </select>
            </div>
            <hr />
            <div>
              <p>Importance</p>
              <select v-model="task.taskImportance" class="select-state">
                <option
                  v-for="option in importanceOptions"
                  :key="option"
                  :value="option"
                >
                  {{ option }}
                </option>
              </select>
            </div>
            <hr />
            <div>
              <p>Workload</p>
              <select v-model="task.taskWorkLoad" class="select-state">
                <option
                  v-for="option in effortOptions"
                  :key="option"
                  :value="option"
                >
                  {{ option }}
                </option>
              </select>
            </div>
          </div>
        </section>
      </div>
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
import formatDate from "@/services/dateFormatter";
import { computed, onMounted, ref } from "vue";
import { useStore } from "vuex";
import loaderVue from "../loader/loader.vue";

export default {
  name: "Modal",
  components: {
    Close,
    TopRight,
    MoreFilled,
    Checked,
    Delete,
    ElDatePicker,
    loaderVue,
  },
  emits: ["close", "save"],
  props: {
    taskId: {
      type: Number,
      required: true,
      default: () => 1,
    },
  },
  setup(props: any, { emit }: any) {
    const store = useStore();

    const optionsOpen = ref(false);
    const importanceOptions = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
    const effortOptions = [1, 2, 3, 5, 8, 13, 21, 34, 55];

    const containers = computed(() => store.getters["sprints/getContainers"]);

    const openOptions = () => {
      optionsOpen.value
        ? (optionsOpen.value = false)
        : (optionsOpen.value = true);
    };

    const deleteTask = () => {
      store.dispatch("sprints/deleteTask", props.taskId);
      close();
    };
    const task = computed((): TaskModel => {
      return store.getters["sprints/getTaskDetails"];
    });
    const date = computed({
      get() {
        return [task.value.taskStartTime, task.value.taskEndTime];
      },
      set(val: Array<Date>) {
        task.value.taskStartTime = val[0];
        task.value.taskEndTime = val[1];
      },
    });
    const close = () => {
      emit("close", task);
    };
    const save = () => {
      emit("save", task.value);
    };

    onMounted(() => {
      if (task.value.taskId != props.taskId && props.taskId != 0) {
        store.commit("sprints/emptyTaskDetails");
        store.dispatch("sprints/getTaskDetails", props.taskId);
      }
    });

    return {
      date,
      close,
      save,
      task,
      formatDate,
      deleteTask,
      optionsOpen,
      openOptions,
      containers,
      importanceOptions,
      effortOptions,
    };
  },
};
</script>

<style scoped lang="scss" src="@/styles/pms/taskModal.scss" />
