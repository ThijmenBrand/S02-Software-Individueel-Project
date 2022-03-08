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
  //todo, needs large rethinking and refactoring
  components: {
    Timeline,
  },
  computed: {
    tasks() {
      let items = [];
      store.getters.tasks.forEach((task) => {
        items.push({ ...task.item, className: "taskItem" });
      });
      return items;
    },
    groups() {
      let groups = [];
      store.getters.tasks.forEach((task) => {
        groups.push(task.group);
      });
      return groups;
    },
    planningView() {
      return "hour";
    },
  },
  beforeMount() {
    store.dispatch("fetchTasks", this.$route.params.id);
  },
};
</script>
