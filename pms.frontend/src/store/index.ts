import { createStore } from "vuex";
import Axios from "axios";
import ProjectModel from "@/models/project/ProjectsModel";
import SelectProject from "@/views/selectProject/store/selectProject";
import Sprints from "@/views/home/sprints/store/sprints";
import TaskModel from "@/models/tasks/Taskmodel";
import Login from "@/views/login/store/login";
import Calender from "@/views/home/calender/store/calender";

export default createStore({
  state: {
    loading: false,
  },
  getters: {},

  actions: {},

  mutations: {},
  modules: {
    selectProject: SelectProject,
    sprints: Sprints,
    calender: Calender,
    login: Login,
  },
});
