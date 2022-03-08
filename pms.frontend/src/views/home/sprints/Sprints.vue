<template>
  <div class="top-header">
    <div class="view-selector">
      <p @click="BoardView" :class="view == 'board' ? 'active-tab' : ''">
        Board
      </p>
      <p @click="ListView" :class="view != 'board' ? 'active-tab' : ''">List</p>
    </div>
    <div class="sprint-selector">
      <el-select v-model="currentSprint" class="m-2">
        <el-option
          v-for="item in options"
          :value="item.value"
          :key="item.value"
          :label="item.label"
          :currentSprint="item.value"
        >
        </el-option>
      </el-select>
    </div>
  </div>
  <div :class="view == 'board' ? 'board-view' : 'list-view'">
    <TaskContainer
      v-for="(container, index) in containers"
      :key="index"
      :containerName="container.containerName"
    />
  </div>
</template>

<script lang="ts">
import { ElSelect, ElOption } from "element-plus";

import { computed, ref } from "vue";
import { useStore } from "vuex";

import TaskContainerModel from "@/models/tasks/TaskContainerModel";
import TaskContainer from "./components/TaskContainer.vue";

export default {
  name: "sprints",
  components: {
    ElOption,
    ElSelect,
    TaskContainer,
  },
  setup() {
    const store = useStore();

    const view = ref("board");

    const containers = computed((): TaskContainerModel => {
      const container = store.getters["sprints/getContainers"];

      return container;
    });

    //ToDo: Sprints ophalen uit backend en weergeven.
    const options = [
      {
        value: "Sprint 1",
        label: "Sprint 1",
      },
      {
        value: "Sprint 2",
        label: "Sprint 2",
      },
      {
        value: "Sprint 3",
        label: "Sprint 3",
      },
    ];

    const currentSprint = ref(options[0].label);

    //ToDO: Sprint data in bord weergaven geven en in cookie en store opslaan
    const BoardView = () => {
      view.value = "board";
      localStorage.getItem("sprint-view") != undefined
        ? (localStorage["sprint-view"] = "board")
        : localStorage.setItem("sprint-view", "board");
    };

    //ToDO: Sprint data in lijst weergaven weergeven en in cookie en store opslaan
    const ListView = () => {
      view.value = "list";
      localStorage.getItem("sprint-view") != undefined
        ? (localStorage["sprint-view"] = "list")
        : localStorage.setItem("sprint-view", "list");
    };

    return { options, currentSprint, BoardView, ListView, containers, view };
  },
};
</script>

<style scoped>
.view-selector p {
  display: inline-block;
  color: gray;
  cursor: pointer;
}

.view-selector p:hover {
  text-decoration: underline;
}

.sprint-selector,
.view-selector {
  display: inline-block;
}

.view-selector {
  width: 100px;
  display: flex;
  justify-content: space-between;
}

.top-header {
  margin-left: auto;
  margin-right: auto;
  display: flex;
  width: 95%;
  justify-content: space-between;
  align-items: center;
}

.list-view {
  display: flex;
  flex-direction: column;
  width: 99%;
}

.board-view {
  display: flex;
  align-items: flex-start;
}

.active-tab {
  color: black;
  text-decoration: underline;
}
</style>