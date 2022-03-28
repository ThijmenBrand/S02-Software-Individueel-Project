<template>
  <div class="top-header">
    <SprintModal v-if="sprintModal" @close="addSprint" />
    <UpdateSprintModal
      @close="openUpdateSprintModal"
      v-if="updateSprintModal"
    />
    <div class="view-selector">
      <p>Board</p>
    </div>
    <div class="sprint-selector">
      <Setting class="icon" @click="openUpdateSprintModal()" />
      <el-select v-model="selectedSprint" class="m-2">
        <el-option
          v-for="item in sprints"
          :value="item.sprintId"
          :key="item.sprintId"
          :label="'sprint ' + item.sprintId"
          :selectedSprint="item.sprintId"
        >
        </el-option>
        <p @click="addSprint()" class="new-sprint">Add sprint +</p>
      </el-select>
    </div>
  </div>
  <div class="board-view">
    <TaskContainer
      v-for="(container, index) in containers"
      :key="index"
      :containerName="container.containerName"
    />
  </div>
</template>

<script lang="ts">
import { ElSelect, ElOption } from "element-plus";
import { Setting } from "@element-plus/icons-vue";

import { computed, onMounted, ref, watch } from "vue";
import { useStore } from "vuex";

import TaskContainerModel from "@/models/tasks/TaskContainerModel";
import TaskContainer from "./components/TaskContainer.vue";
import SprintModel from "@/models/sprint/SprintModel";
import SprintModal from "@/components/modal/SprintModal.vue";
import UpdateSprintModal from "@/components/modal/UpdateSprintModal.vue";

export default {
  name: "sprints",
  components: {
    ElOption,
    ElSelect,
    TaskContainer,
    SprintModal,
    UpdateSprintModal,
    Setting,
  },
  setup() {
    const store = useStore();

    const sprint = computed({
      get(): SprintModel {
        return store.getters["sprints/getCurrentSprint"];
      },
      set(newVal): void {
        store.commit("sprints/setCurrentSprint", newVal);
        store.dispatch("sprints/getTasks");
      },
    });

    const selectedSprint = ref(sprint);
    const sprintModal = ref<boolean>(false);
    const updateSprintModal = ref<boolean>(false);

    const openUpdateSprintModal = (): void => {
      !updateSprintModal.value
        ? (updateSprintModal.value = true)
        : (updateSprintModal.value = false);
    };

    const addSprint = (): void => {
      !sprintModal.value
        ? (sprintModal.value = true)
        : (sprintModal.value = false);
    };

    onMounted(() => {
      store.dispatch("sprints/getCurrentSprint");
      store.dispatch("sprints/getSprints");
    });

    const sprints = computed((): SprintModel[] => {
      return store.getters["sprints/getSprints"];
    });

    const containers = computed((): TaskContainerModel => {
      return store.getters["sprints/getContainers"];
    });

    return {
      selectedSprint,
      containers,
      sprints,
      addSprint,
      sprintModal,
      updateSprintModal,
      openUpdateSprintModal,
    };
  },
};
</script>

<style scoped lang="scss">
.icon {
  height: 20px;
  width: 20px;
  cursor: pointer;
}
.new-sprint {
  cursor: pointer;
  color: gray;
  font-size: 15px;
  padding-left: 20px;
  font-weight: 200;
}
.view-selector p {
  display: inline-block;
  color: gray;
}

.sprint-selector,
.view-selector {
  display: inline-block;
}

.top-header {
  margin-left: auto;
  margin-right: auto;
  display: flex;
  width: 95%;
  justify-content: space-between;
  align-items: center;
}

.board-view {
  display: flex;
  align-items: flex-start;
}
</style>