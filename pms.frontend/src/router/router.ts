import { createRouter, createWebHistory } from "vue-router";
import SelectProject from "@/views/selectProject/SelectProject.vue";

const routes = [
  {
    path: "/",
    name: "SelectProject",
    component: SelectProject,
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
