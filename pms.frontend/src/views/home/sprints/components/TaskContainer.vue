<template>
  <ElDialog v-model="modalIsOpen" :title="openTask.taskName" width="30%">
    <span>{{ openTask.taskId }}</span>
  </ElDialog>
  <ElCard
    class="task-container"
    :class="containerClassName"
    style="background-color: transparent"
  >
    <template #header>
      <div>
        <span>{{ containerName }}</span>
        <ElButton type="text" class="add-item-button"
          ><ElIcon :size="20" @click="addItem(containerName)"><plus /></ElIcon
        ></ElButton>
      </div>
    </template>
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
  </ElCard>
</template>

<script lang="ts">
import { ElCard, ElButton, ElIcon, ElDialog } from "element-plus";
import { VueDraggableNext } from "vue-draggable-next";

import TaskCard from "./TaskCard.vue";
import AddTaskCard from "./AddTaskCard.vue";
import TaskModel from "@/models/tasks/Taskmodel";

import { Plus } from "@element-plus/icons-vue";

import { useStore } from "vuex";
import { computed, onMounted, ref } from "vue";

export default {
  name: "TaskContainer",
  components: {
    ElCard,
    ElButton,
    ElIcon,
    Plus,
    TaskCard,
    ElDialog,
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

    const openTask = ref<TaskModel>(
      new TaskModel({
        taskId: 0,
        taskName: "",
        taskDescription: "",
        taskStart: new Date(),
        taskEnd: new Date(),
        taskTag: "",
      })
    );

    const containerClassName = computed((): string => {
      return props.containerName;
    });

    onMounted((): void => {
      store.dispatch("sprints/getTasks");
    });

    const tasks = computed((): TaskModel[] => {
      const ApplyingTasks: TaskModel[] = [];
      const storeRes: TaskModel[] = store.getters["sprints/getTasks"];

      storeRes.forEach((task) => {
        task.taskTag == props.containerName ? ApplyingTasks.push(task) : "";
      });

      return ApplyingTasks;
    });

    const update = (val: any): void => {
      const from = val.clone.attributes.attr.value;
      const to = val.to.getAttribute("attr");

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

    const openTaskModal = (task: TaskModel): void => {
      modalIsOpen.value
        ? (modalIsOpen.value = false)
        : (modalIsOpen.value = true);

      openTask.value = task;
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
    };
  },
};
</script>

<style scoped>
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