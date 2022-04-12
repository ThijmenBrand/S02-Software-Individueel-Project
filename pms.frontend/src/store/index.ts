import { createStore } from "vuex";
import Axios from "axios";
import ProjectModel from "@/models/project/ProjectsModel";
import SelectProject from "@/views/selectProject/store/selectProject";
import Sprints from "@/views/home/sprints/store/sprints";
import TaskModel from "@/models/tasks/Taskmodel";
import Login from "@/views/login/store/login";

export default createStore({
  state: {},
  getters: {},

  actions: {},

  mutations: {},
  modules: {
    selectProject: SelectProject,
    sprints: Sprints,
    login: Login,
  },
});
