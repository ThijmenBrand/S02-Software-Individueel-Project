import { createStore } from "vuex";
import Axios from "axios";
import ProjectModel from "@/models/project/ProjectsModel";
import SelectProject from "@/views/selectProject/store/selectProject";
import Sprints from "@/views/home/sprints/store/sprints";
import TaskModel from "@/models/tasks/Taskmodel";

export default createStore({
  state: {
    loadig: false,
    taskList: Array<TaskModel>(),
    currentProject: <ProjectModel>{},
    loggedUser: "1",
    error: 0,
  },
  getters: {
    tasks: (state) => {
      return state.taskList;
    },
  },

  actions: {
    //Project actions

    //tasks actions
    fetchTasks: async ({ commit }) => {
      const CurrentProjectId: number = localStorage["currentProjectId"];
      const { data } = await Axios.get(
        `http://localhost:8080/api/Tasks/${CurrentProjectId}`
      );

      commit("getTasksByProject", data);
      return true;
    },
  },

  mutations: {
    //Task mutations
    getTasksByProject: (state, tasks: TaskModel[]) => {
      state.taskList = tasks;
    },
  },
  modules: {
    selectProject: SelectProject,
    sprints: Sprints,
  },
});
