<template>
  <div>
    <p>Sprint planning</p>
    <div id="visualization"></div>
  </div>
</template>

<script>
import { Timeline } from "vis-timeline/standalone";

export default {
  props: {
    PlanningView: {
      type: String,
      required: true,
      default: () => {
        "day";
      },
    },
    items: {
      type: Array,
      required: true,
      default: () => [
        {
          id: 1,
          group: 1,
          start: new Date(),
          end: new Date(),
        },
      ],
    },
    groups: {
      type: Array,
      required: true,
      default: () => [
        {
          id: 1,
          content: "New Task",
        },
      ],
    },
  },
  setup(props) {
    return {
      options: {
        orientation: "top",
        itemsAlwaysDraggable: false,
        timeAxis: { scale: props.PlanningView, step: 1 },
        zoomable: false,
        zoomMax: 850000000,
        zoomMin: 85000000,
        horizontalScroll: true,
        zoomKey: "ctrlKey",
        hiddenDates: {
          start: "2022-02-16 00:00:00",
          end: "2022-02-16 06:00:00",
          repeat: "daily",
        },
        start: "2022-02-16",
        end: "2022-02-16",
      },
    };
  },
  mounted() {
    console.log(this.groups);
    console.log(this.items);
    let timeline = new Timeline(document.getElementById("visualization"));
    timeline.setOptions(this.options);
    timeline.setGroups(this.groups);
    timeline.setItems(this.items);
  },
};
</script>

<style>
.vis-time-axis .vis-grid.vis-odd {
  background: #f5f5f5;
}
.vis-time-axis .vis-grid.vis-saturday,
.vis-time-axis .vis-grid.vis-sunday {
  background: gray;
}
.vis-time-axis .vis-text.vis-saturday,
.vis-time-axis .vis-text.vis-sunday {
  color: white;
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
.vis-active {
  box-shadow: none;
}
.vis-h0 .vis-h01 .vis-h15 .vis-h16 {
  color: blue !important;
  height: 100px;
  text-align: center;
}
</style>