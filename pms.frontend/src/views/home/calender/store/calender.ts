import TaskModel from "@/models/tasks/Taskmodel";
import { calenderFunctions } from "@/services/calender/calenderFunctions";
import axios from "axios";

interface CalenderState {
  allTasks: TaskModel[];
}

const calender = {
  namespaced: true,
  state(): CalenderState {
    return {
      allTasks: [],
    };
  },
  getters: {
    getAllTasks: (state: CalenderState): TaskModel[] => {
      return state.allTasks;
    },
  },
  actions: {
    getAllTasks: async (context: any) => {
      context.rootState.loading = true;
      await calenderFunctions.getAllTasksByProject().then((res) => {
        if (res.status >= 200 && res.status <= 299)
          context.commit("setAllTasks", res.data);
      });
    },
  },
  mutations: {
    setAllTasks: (state: CalenderState, tasks: TaskModel[]) => {
      console.log(tasks);
      state.allTasks = tasks;
    },
    clearCalender: (state: CalenderState) => {
      state.allTasks = [];
    },
  },
};

export default calender;
