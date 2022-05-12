<template>
  <div class="top-bar-options">
    <div>
      <ElRadio v-model="calenderView" label="day" size="large" border
        >Day</ElRadio
      >
      <ElRadio v-model="calenderView" label="week" size="large" border
        >Week</ElRadio
      >
    </div>
    <ElButton @click="goToday()">Today</ElButton>
  </div>

  <loaderVue v-if="!hasLoaded" />
  <div id="visualization" @click="onSelect()"></div>
</template>

<script lang="ts">
import { DataItemCollectionType, Timeline } from "vis-timeline/standalone";
import { computed, onMounted, onUpdated, ref } from "vue";
import { ElButton, ElRadio } from "element-plus";
import loaderVue from "@/components/loader/loader.vue";

import TaskModel from "@/models/tasks/Taskmodel";
export default {
  name: "calender",
  components: { ElRadio, ElButton, loaderVue },
  props: {
    tasks: {
      type: Array as () => Array<TaskModel>,
      required: true,
    },
  },
  emits: ["open-modal"],
  setup(props: any, { emit }: any) {
    const hasLoaded = ref<boolean>(false);
    const calenderView = ref<string>("day");
    let timeline: Timeline;

    const table: any = {
      day: {
        scale: "hour",
        step: 1,
        zoomMax: 85000000,
        zoomMin: 85000000,
      },
      week: {
        scale: "day",
        step: 1,
        zoomMax: 700000000,
        zoomMin: 700000000,
      },
    };
    const options = computed(() => {
      return {
        orientation: "top",
        itemsAlwaysDraggable: false,
        zoomMax: table[calenderView.value].zoomMax,
        zoomMin: table[calenderView.value].zoomMin,
        timeAxis: { scale: table[calenderView.value].scale, step: 1 },
        horizontalScroll: true,
        minHeight: "500px",
        autoResize: true,
        start: new Date(),
        end: new Date(),
        onInitialDrawComplete: () => {
          hasLoaded.value = true;
        },
      };
    });
    const items = computed((): DataItemCollectionType => {
      const allTasks: TaskModel[] = props.tasks;
      const returnArray: DataItemCollectionType = [];

      allTasks.forEach((task) => {
        returnArray.push({
          id: task.taskId,
          content: task.taskTag + " - " + task.taskName,
          start: task.taskStartTime,
          end: task.taskEndTime,
          selectable: true,
          className: task.taskTag + "-task",
        });
      });

      return returnArray;
    });

    const goToday = () => {
      timeline.moveTo(new Date());
    };

    const onSelect = () => {
      timeline.on("select", (e) => {
        if (e.items.length > 0) emit("open-modal", e.items[0]);
      });
    };

    onMounted(() => {
      timeline = new Timeline(
        document.getElementById("visualization") as HTMLElement,
        items.value,
        options.value
      );
    });
    onUpdated(() => {
      timeline.destroy();
      timeline = new Timeline(
        document.getElementById("visualization") as HTMLElement,
        items.value,
        options.value
      );
    });

    return { items, calenderView, goToday, hasLoaded, onSelect };
  },
};
</script>

<style>
.has-not-loaded {
  visibility: hidden;
}
.top-bar-options {
  display: flex;
  justify-content: space-between;
  margin: 20px;
}
.el-radio.is-bordered.el-radio--large,
.el-button.el-button--default {
  height: 30px;
  position: relative;
}

.vis-item.red-item {
  color: black;
  background-color: red;
  border-color: darkred;
}
.vis-timeline {
  border: none;
}
.vis-panel.vis-background.vis-vertical {
  left: 0;
}
.vis-panel.vis-left {
  display: none;
}
.vis-item {
  background-color: #d6e6ff;
  border-color: #1371fe;
  color: #0155d3;
  border-left-width: 3px;
  border-left-style: solid;
  font-weight: 500;
  opacity: 0.8;
  font-size: 13px;
  height: 55px;
}
.vis-labelset .vis-label .vis-inner {
  min-width: 200px;
}
.vis-panel.vis-center,
.vis-panel.vis-top {
  border: none;
}
.vis-panel {
  box-sizing: none;
}
.vis-foreground .vis-group {
  border: none;
}
.vis-item.taskItem {
  background-color: orange;
  height: 40px;
  border-radius: 15px;
  border: none;
}
.vis-active {
  box-shadow: none;
}
.vis-h0 .vis-h01 .vis-h15 .vis-h16 {
  color: blue !important;
  height: 100px;
  text-align: center;
}
</style>
