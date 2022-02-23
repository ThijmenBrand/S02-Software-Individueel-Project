<template>
  <div class="top-header">
    <div class="view-selector">
      <p @click="BoardView">Board</p>
      <p @click="ListView">List</p>
    </div>
    <div class="sprint-selector">
      <el-select v-model="value" class="m-2">
        <el-option
          v-for="item in options"
          :key="item.value"
          :label="item.label"
          :value="item.value"
        >
        </el-option>
      </el-select>
    </div>
  </div>
</template>

<script lang="ts">
import { ElSelect, ElOption } from "element-plus";

import { ref } from "vue";

export default {
  components: {
    ElOption,
    ElSelect,
  },
  setup() {
    //ToDo: Sprints ophalen uit backend en weergeven.
    //ToDo: Sprint onclick, data ophalen uit backend en weergeven
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

    //ToDO: Sprint data in bord weergaven geven en in cookie en store opslaan
    const BoardView = () => {
      alert("board!");
    };

    //ToDO: Sprint data in lijst weergaven weergeven en in cookie en store opslaan
    const ListView = () => {
      alert("List!");
    };

    const value = ref(options[0].label);

    return { options, value, BoardView, ListView };
  },
};
</script>

<style>
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
</style>