<template>
  <div class="top-header">
    <div class="view-selector">
      <p>Board</p>
    </div>
    <div class="sprint-selector">
      <el-select v-model="selectedSprint" class="m-2">
        <el-option
          v-for="item in sprints"
          :value="item.sprintId"
          :key="item.sprintId"
          :label="'sprint ' + item.sprintId"
          :selectedSprint="item.sprintId"
        >
        </el-option>
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

import { computed, onMounted, ref, watch } from "vue";
import { useStore } from "vuex";

import TaskContainerModel from "@/models/tasks/TaskContainerModel";
import TaskContainer from "./components/TaskContainer.vue";
import SprintModel from "@/models/sprint/SprintModel";

export default {
  name: "sprints",
  components: {
    ElOption,
    ElSelect,
    TaskContainer,
  },
  setup() {
    const store = useStore();

    const sprint = computed({
      get() {
        return store.getters["sprints/getCurrentSprint"];
      },
      set(newVal) {
        store.commit("sprints/setCurrentSprint", newVal);
        store.dispatch("sprints/getTasks");
      },
    });

    const selectedSprint = ref(sprint);

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
    };
  },
};
</script>

<style scoped>
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