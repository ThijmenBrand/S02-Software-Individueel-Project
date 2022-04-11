import Axios from "axios";
import ProjectModel from "@/models/project/ProjectsModel";
import API from "@/services/api";

interface selectProjectState {
  projectList: ProjectModel[];
}

const selectProject = {
  namespaced: true,
  state(): selectProjectState {
    return {
      projectList: [],
    };
  },
  getters: {
    projectList: (state: selectProjectState): ProjectModel[] => {
      return state.projectList;
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
    selectCurrentProject: async ({ commit }: any, project: any) => {
      commit("currentProject", project.projectId);
    },
  },
  mutations: {
    fetchProjects: (state: any, projects: ProjectModel[]) =>
      (state.projectList = projects),
    currentProject: (state: any, projectId: number) => {
      const project: ProjectModel = state.projectList.find(
        (element: ProjectModel) => element.projectId == projectId
      )!;
      state.currentProject = project;
      localStorage["currentProjectId"] = project.projectId.toString();
    },
  },
};

export default selectProject;
