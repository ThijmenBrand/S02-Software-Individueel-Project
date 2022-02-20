import { createStore } from "vuex";
import { ACTION_TYPES } from "@/constants/ActionTypes";
import IProjectModel from "@/models/projects/ProjectsModel";
import Axios from "axios";

export default createStore({
state: {
    projectList: Array<IProjectModel>()
},
getters: {},
    
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
                "projectOwnerId": projectDetails.projectOwnerId,
            }
        );
        commit(ACTION_TYPES.fetchProjects, response.data);
    }
},
    
mutations: {
    [ACTION_TYPES.fetchProjects]: (state, projects) => (state.projectList = projects),
},
});