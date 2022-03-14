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
    getSprints: (state: sprintState): SprintModel[] => {
      return state.allSprints;
    },
    getCurrentSprint: (state: sprintState): number => {
      return state.currentSprint;
    },
  },
  actions: {
    getSprints: async ({ commit }: any) => {
      const CurrentProjectId: number = localStorage["currentProjectId"];
      const url = `http://localhost:8080/api/Sprints/${CurrentProjectId}`;
      const { data } = await Axios.get(url);

      commit("getAllSprints", data);
      commit("setInitalSprint", data);
    },
    getTasks: async (
      { commit }: any,
      currentSprintId: number
    ): Promise<void> => {
      const CurrentProjectId: number = localStorage["currentProjectId"];
      let CurrentSprintId: number;

      if (localStorage["currentProjectId"] != undefined) {
        CurrentSprintId = localStorage["currentProjectId"];
      } else {
        CurrentSprintId = currentSprintId;
      }
      const { data } = await Axios.get(
        `http://localhost:8080/api/Tasks/Sprint/${CurrentSprintId}/${CurrentProjectId}`
      );
      commit("getAllTasks", data);
    },
    addTask: async ({ commit }: any, task: IBaseTaskShape): Promise<void> => {
      const CurrentProjectId: number = localStorage["currentProjectId"];
      const CurrentSprintId: number = localStorage["currentSprintId"];
      const { data, status } = await Axios.post(
        "http://localhost:8080/api/Tasks",
        {
          taskName: task.taskName,
          taskDescription: "",
          taskTag: task.taskTag,
          projectId: CurrentProjectId,
          sprintId: CurrentSprintId,
        }
      );

      if (status >= 200 && status <= 299) {
        commit("getAllTasks", data);
      } else {
        console.log("Something went wrong");
      }
    },
    saveTask: async ({ commit }: any, opts: TaskModel) => {
      const { data, status } = await Axios.put(
        `http://localhost:8080/api/Tasks/${opts.taskId}`,
        {}
      );
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
    setInitalSprint: async (state: sprintState, sprints: SprintModel[]) => {
      const TodayDate = new Date().getDate();

      sprints.forEach((sprint) => {
        const sprintStartDate = new Date(sprint.sprintStart).getDate();
        let sprintEndDate: number | Date = new Date(sprint.sprintStart);
        sprintEndDate = sprintEndDate.setDate(
          sprintEndDate.getDate() + sprint.sprintDuration
        );
        if (TodayDate >= sprintStartDate && TodayDate <= sprintEndDate) {
          state.currentSprint = sprint.sprintId;
          localStorage.setItem(
            "currentSprintId",
            JSON.stringify(sprint.sprintId)
          );
          console.log(localStorage["currentSprintId"]);
        }
      });
    },
    setCurrentSprint: (state: sprintState, sprint: number) => {
      state.currentSprint = sprint;
      localStorage["currentSprintId"] = JSON.stringify(sprint);
    },
    getAllSprints: (state: sprintState, sprints: SprintModel[]) => {
      state.allSprints = sprints;
    },
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
