import { createRouter, createWebHashHistory, RouteRecordRaw } from "vue-router";
import SelectProject from "@/views/selectProject/SelectProject.vue";
import Home from "@/views/home/BaseHome.vue";
import Assets from "@/views/home/assets/Assets.vue";
import Files from "@/views/home/assets/files/Files.vue";
import Links from "@/views/home/assets/links/Links.vue";
import Sprints from "@/views/home/sprints/Sprints.vue";
import Board from "@/views/home/board/Board.vue";
import TimeTracking from "@/views/home/timeTracking/TimeTracking.vue";
import Settings from "@/views/home/settings/Settings.vue";
import Dashboard from "@/views/home/home/Home.vue";
import Account from "@/views/home/account/Account.vue";

const routes: Array<RouteRecordRaw> = [
  {
    path: "/",
    name: "SelectProject",
    component: SelectProject,
  },
  {
    path: "/home/:id",
    name: "Home",
    component: Home,
    children: [
      {
        path: "dashboard",
        name: "Dashboard",
        component: Dashboard,
      },
      {
        path: "assets",
        name: "Assets",
        component: Assets,
        children: [
          {
            path: "files",
            name: "Files",
            component: Files,
          },
          {
            path: "links",
            name: "Links",
            component: Links,
          }
        ]
      },
      {
        path: "sprints",
        name: "Sprints",
        component: Sprints,
      },
      {
        path: "board",
        name: "Board",
        component: Board,
      },
      {
        path: "timetracking",
        name: "TimeTracking",
        component: TimeTracking,
      },
      {
        path: "settings",
        name: "Settings",
        component: Settings,
      },
    ]
  },
  {
    path: "/account",
    name: "Account",
    component: Account,
  } 
];

const router = createRouter({
  history: createWebHashHistory(),
  routes,
});

export default router;
