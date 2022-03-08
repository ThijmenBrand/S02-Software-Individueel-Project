import Axios from "axios";
import SprintModel from "@/models/sprint/SprintModel";
import TaskContainerModel from "@/models/tasks/TaskContainerModel";
import TaskModel, { IBaseTaskShape } from "@/models/tasks/Taskmodel";

interface sprintState {
  currentSprint: number;
  allSprints: SprintModel[];
  sprintView: string;
  taskContainersList: TaskContainerModel[];
  taskItemsList: TaskModel[];
}

const sprints = {
  namespaced: true,
  state(): sprintState {
    return {
      currentSprint: 0,
      allSprints: [],
      sprintView: "board",
      taskContainersList: [
        {
          containerId: 1,
          containerName: "todo",
        },
        {
          containerId: 2,
          containerName: "doing",
        },
        {
          containerId: 3,
          containerName: "done",
        },
      ],
      taskItemsList: [],
    };
  },
  getters: {
    getContainers: (state: sprintState): TaskContainerModel[] => {
      return state.taskContainersList;
    },
    getTasks: (state: sprintState): TaskModel[] => {
      return state.taskItemsList;
    },
  },
  actions: {
    getTasks: async ({ commit }: any): Promise<void> => {
      const CurrentProjectId: number = localStorage["currentProjectId"];
      const { data } = await Axios.get(
        `http://localhost:8080/api/Tasks/${CurrentProjectId}`
      );
      commit("getAllTasks", data);
    },
    addTask: async ({ commit }: any, task: IBaseTaskShape): Promise<void> => {
      const CurrentProjectId: number = localStorage["currentProjectId"];
      const { data, status } = await Axios.post(
        "http://localhost:8080/api/Tasks",
        {
          taskName: task.taskName,
          taskDescription: "",
          taskTag: task.taskTag,
          projectId: CurrentProjectId,
        }
      );

      if (status >= 200 && status <= 299) {
        commit("getAllTasks", data);
      } else {
        console.log("Something went wrong");
      }
    },
    updateTasks: async (
      { commit }: any,
      opts: { taskId: number; targetContainer: string }
    ) => {
      const config = { headers: { "Content-Type": "application/json" } };
      const { status } = await Axios.put(
        `http://localhost:8080/api/Tasks/${opts.taskId}`,
        opts.targetContainer,
        config
      );
      if (status >= 200 && status <= 299) {
        commit("updateTasks", opts);
      } else {
        console.log("Something went wrong");
      }
    },
  },
  mutations: {
    updateTasks: (
      state: sprintState,
      opts: { taskId: number; targetContainer: string }
    ) => {
      const task = state.taskItemsList.find((a) => a.taskId === opts.taskId);
      task != undefined ? (task.taskTag = opts.targetContainer) : "";
    },
    getAllTasks: (state: sprintState, tasks: TaskModel[]) => {
      state.taskItemsList = tasks;
    },
  },
};

export default sprints;
