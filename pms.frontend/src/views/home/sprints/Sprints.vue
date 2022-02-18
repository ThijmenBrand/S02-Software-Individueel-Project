<template>
  <h1>Sprints</h1>
  <p v-if="groups.length == 0">Loading you board...</p>
  <Timeline
    v-else
    :items="tasks"
    :groups="groups"
    :PlanningView="planningView"
  />
</template>

<script>
import Timeline from "./components/PlanningHorizontal.vue";
import store from "@/store";

export default {
  components: {
    Timeline,
  },
  computed: {
    tasks() {
      let items = [];
      store.getters.tasks.forEach((task) => {
        let item = {};

        item.id = task.taskId;
        item.group = task.taskId;
        item.start = task.taskStartTime;
        item.end = task.taskEndTime;

        items.push(item);
      });
      return items;
    },
    groups() {
      let groups = [];
      store.getters.tasks.forEach((task) => {
        let group = {};

        group.id = task.taskId;
        group.content = task.taskName;

        groups.push(group);
      });
      console.log(groups);
      return groups;
    },
    planningView() {
      return "hour";
    },
  },
  beforeMount() {
    store.dispatch("getTasksByProject", this.$route.params.id);
  },
};
</script>
