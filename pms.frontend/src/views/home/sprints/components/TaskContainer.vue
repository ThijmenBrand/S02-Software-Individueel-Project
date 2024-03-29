<template>
  <Modal
    v-if="modalIsOpen"
    @close="openTaskModal"
    :taskId="openTask"
    @save="saveTask"
  />
  <div
    class="task-container"
    :class="containerClassName"
    style="background-color: transparent"
  >
    <div class="container-header">
      <h3>{{ containerName }}</h3>
      <ElButton type="text" class="add-item-button"
        ><ElIcon :size="20" @click="addItem(containerName)"><plus /></ElIcon
      ></ElButton>
    </div>
    <hr :class="containerName + '-task'" />
    <div class="container-body">
      <AddTaskCard
        :containerName="containerName"
        :class="activeAdd ? 'show-add' : 'show-not'"
      />
      <draggable
        @end="update"
        :options="{ group: containerName }"
        :group="{ name: containerName, put: true, pull: true }"
        ghost-class="ghost"
        :attr="containerName"
      >
        <TaskCard
          v-for="(task, index) in tasks"
          :key="index"
          :task="task"
          @open-modal="openTaskModal"
        />
      </draggable>
    </div>
  </div>
</template>

<script lang="ts">
import { ElButton, ElIcon } from "element-plus";
import { VueDraggableNext } from "vue-draggable-next";

import TaskCard from "./TaskCard.vue";
import AddTaskCard from "./AddTaskCard.vue";
import TaskModel from "@/models/tasks/Taskmodel";
import Modal from "@/components/modal/TaskModal.vue";

import { Plus } from "@element-plus/icons-vue";

import { useStore } from "vuex";
import { computed, ref } from "vue";

export default {
  name: "TaskContainer",
  components: {
    ElButton,
    ElIcon,
    Plus,
    Modal,
    TaskCard,
    AddTaskCard,
    draggable: VueDraggableNext,
  },
  props: {
    containerName: {
      type: String,
      required: true,
    },
  },
  setup(props: any) {
    const store = useStore();

    const activeAdd = ref<boolean>(false);

    const modalIsOpen = ref<boolean>(false);

    const openTask = ref<number>(0);

    const containerClassName = computed((): string => {
      return props.containerName;
    });

    const tasks = computed((): TaskModel[] => {
      return store.getters["sprints/getApplyingTasks"](props.containerName);
    });

    const update = (val: any): void => {
      const from = val.clone.attributes.attr.value;
      const to = val.to.getAttribute("attr");

      store.commit("sprints/updateTasks", {
        taskId: from,
        targetContainer: to,
      });
      store.dispatch("sprints/updateTasks", {
        taskId: from,
        targetContainer: to,
      });
    };

    const addItem = (containerName: string): void => {
      if (containerName == containerClassName.value) {
        activeAdd.value ? (activeAdd.value = false) : (activeAdd.value = true);
      }
    };

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

    return {
      tasks,
      update,
      containerClassName,
      addItem,
      activeAdd,
      openTaskModal,
      modalIsOpen,
      openTask,
      saveTask,
    };
  },
};
</script>

<style scoped lang="scss">
hr {
  width: 100%;
  border: none;
  height: 2px;
  border-radius: 2px;
}
.container-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  h3 {
    display: inline-block;
  }
}
.container-body {
  min-height: 300px;
}
.task-container {
  box-shadow: none;
  min-height: 100px;
  width: 300px;
  display: inline-block;
  display: flex;
  flex-direction: column;
  justify-content: center;
  margin: 30px;
}

.el-card.is-always-shadow {
  box-shadow: none;
}

.el-card {
  border: none;
}

.add-item-button {
  float: right;
}
.show-add {
  display: block;
}
.show-not {
  display: none;
}
</style>
