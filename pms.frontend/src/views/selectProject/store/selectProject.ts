import Axios from "axios";
import ProjectModel from "@/models/project/ProjectsModel";
import API from "@/services/api";
import LocalStorageHandler from "@/services/localStorageHelper/LocalStorageHelper";

interface selectProjectState {
  projectList: ProjectModel[];
  currentProject: ProjectModel;
}

const selectProject = {
  namespaced: true,
  state(): selectProjectState {
    return {
      projectList: [],
      currentProject: new ProjectModel({
        projectId: 0,
        projectName: "",
        projectDescription: "",
        projectOwnerId: 0,
        projectDate: new Date(),
      }),
    };
  },
  getters: {
    projectList: (state: selectProjectState): ProjectModel[] => {
      return state.projectList;
    },
    getCurrentProject: (state: selectProjectState): ProjectModel => {
      console.log(state.currentProject);
      return state.currentProject.projectId != 0
        ? state.currentProject
        : LocalStorageHandler.getItem("currentProject");
    },
  },
  actions: {
    //Project actions
    fetchProjects: async ({ commit }: any) => {
      const { data } = await API.get("Projects");
      commit("fetchProjects", data);
    },
    addNewProject: async ({ commit }: any, projectDetails: any) => {
      const { data } = await API.post("Projects", {
        projectName: projectDetails.projectName,
        projectDescription: "",
      });
      commit("fetchProjects", data);
    },
    selectCurrentProject: async ({ commit }: any, projectId: number) => {
      const { data } = await API.get(`Projects/${projectId}`);
      commit("currentProject", data.result);
    },
  },
  mutations: {
    fetchProjects: (state: any, projects: ProjectModel[]) =>
      (state.projectList = projects),
    currentProject: (state: any, project: ProjectModel) => {
      state.currentProject = project;
      LocalStorageHandler.setItem("currentProject", project);
    },
  },
};

export default selectProject;
