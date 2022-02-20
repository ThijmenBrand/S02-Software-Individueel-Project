import { createStore } from "vuex";
import { ACTION_TYPES } from "./ACTION_TYPES/ActionTypes";
import IProjectModel from "@/models/projects/ProjectsModel";
import ITaskModel from "@/models/tasks/Taskmodel";
import Axios from "axios";

export default createStore({
state: {
    projectList: Array<IProjectModel>(),
    taskList: Array<ITaskModel>(),
    currentProject: <IProjectModel>{},
    loggedUser: "1"
},
getters: {
    tasks: state => {
        return state.taskList;
    }
},
    
actions: {
    onFetchProjects: async ({ commit }) => {
        const response = await Axios.get(
            "http://localhost:8080/api/Projects"
        );
        commit(ACTION_TYPES.fetchProjects, response.data);
    },

    addNewProject: async ({ commit }, projectDetails ) => {
        const response = await Axios.post(
            "http://localhost:8080/api/Projects",
            {
                "projectName": projectDetails.projectName,
                "projectDescription": "",
                "projectOwnerId": "1"
            }
        );
        commit(ACTION_TYPES.fetchProjects, response.data);
    },

    selectCurrentProject: async ({ commit }, project) => {
        commit(ACTION_TYPES.currentProject, project.projectId);
    },

    getTasksByProject: async ({ commit, state }) => {
        
        const CurrentProjectId: number = localStorage['currentProjectId'];
        const response = await Axios.get(
            `http://localhost:8080/api/Tasks/ProjectTask?ProjectId=${CurrentProjectId}`
        );
    
        commit(ACTION_TYPES.getTasksByProject, response.data);
        return true;
    }
},
    
mutations: {
    [ACTION_TYPES.fetchProjects]: (state, projects) => (state.projectList = projects),
    [ACTION_TYPES.currentProject]: (state, projectId: number) => {
        const project = state.projectList.find(element => element.projectId == projectId)!;
        state.currentProject = project;
        localStorage['currentProjectId'] = project.projectId.toString();
    },
    [ACTION_TYPES.getTasksByProject]: (state, tasks) => {
        state.taskList = tasks
    },
},
});

