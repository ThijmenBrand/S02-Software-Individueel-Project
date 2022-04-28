<template>
  <TaskModalVue
    v-if="modalIsOpen"
    @close="openTaskModal"
    :taskId="openTask"
    @save="saveTask"
  />
  <PlanningHorizontal :tasks="allTasksInPrint" @open-modal="openTaskModal" />
</template>

<script lang="ts">
import { computed, onMounted, ref, watch } from "vue";
import { useStore } from "vuex";
import TaskModel from "@/models/tasks/Taskmodel";
import PlanningHorizontal from "./components/PlanningHorizontal.vue";
import TaskModalVue from "@/components/modal/TaskModal.vue";
export default {
  name: "Calender",
  components: { PlanningHorizontal, TaskModalVue },
  setup() {
    const store = useStore();
    const modalIsOpen = ref<boolean>(false);
    const allTasksInPrint = computed(
      (): TaskModel[] => store.getters["calender/getAllTasks"]
    );
    const openTask = ref<number>(0);

    const openTaskModal = (taskId: number): void => {
      modalIsOpen.value
        ? (modalIsOpen.value = false)
        : (modalIsOpen.value = true);

      openTask.value = taskId;
    };

    const saveTask = (task: TaskModel): void => {
      store.dispatch("sprints/saveTask", task);
      modalIsOpen.value = false;
    };

    onMounted(() => {
      store.commit("calender/clearCalender");
      store.dispatch("calender/getAllTasks");
    });

    return { allTasksInPrint, openTaskModal, openTask, modalIsOpen, saveTask };
  },
};
</script>
