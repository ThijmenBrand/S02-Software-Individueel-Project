import SprintModel from "@/models/sprint/SprintModel";
import TaskContainerModel from "@/models/tasks/TaskContainerModel";
import TaskModel, { IBaseTaskShape } from "@/models/tasks/Taskmodel";
import { sprintService } from "@/services/sprints/sprintFunctions";

interface sprintState {
  loading: boolean;
  currentSprintNumber: number;
  currentSprint: SprintModel;
  allSprints: SprintModel[];
  sprintView: string;
  taskContainersList: TaskContainerModel[];
  taskItemsList: TaskModel[];
}

const sprints = {
  namespaced: true,
  state(): sprintState {
    return {
      loading: false,
      currentSprintNumber: 0,
      currentSprint: {
        sprintDuration: 14,
        sprintId: 1,
        sprintStart: new Date(),
      },
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
    isLoading: (state: sprintState): boolean => {
      return state.loading;
    },
    getContainers: (state: sprintState): TaskContainerModel[] => {
      return state.taskContainersList;
    },
    getAllTasks: (state: sprintState): TaskModel[] => {
      return state.taskItemsList;
    },
    getApplyingTasks:
      (state: sprintState) =>
      (container: string): TaskModel[] | undefined => {
        const applyingTasks: TaskModel[] = [];
        state.taskItemsList.forEach((task) => {
          if (task.taskTag == container) applyingTasks.push(task);
        });
        return applyingTasks;
      },
    getTaskForTaskModal:
      (state: sprintState) =>
      (taskId: number): TaskModel => {
        const task: TaskModel | undefined = state.taskItemsList.find(
          (task) => task.taskId == taskId
        );
        return task != undefined
          ? task
          : new TaskModel({
              taskId: 0,
              taskName: "",
              taskDescription: "",
              taskStartTime: new Date(),
              taskEndTime: new Date(),
              taskTag: "",
            });
      },
    getSprints: (state: sprintState): SprintModel[] => {
      return state.allSprints;
    },
    getCurrentSprint: (state: sprintState): number => {
      return state.currentSprintNumber;
    },
  },
  actions: {
    getSprints: async ({ commit }: any) => {
      const { data } = await sprintService.getAllSprints();
      commit("getAllSprints", data);
    },
    addSprint: async ({ commit }: any, Data: any) => {
      const { data } = await sprintService.addSprint(
        Data.sprintStart,
        Data.sprintEnd
      );
      commit("getAllSprints", data);
    },
    deleteTask: async (context: any, taskId: number) => {
      const { data } = await sprintService.deleteTask(taskId);
      context.commit("getAllTasks", data);
    },
    getTasks: async ({ commit }: any): Promise<void> => {
      const { data } = await sprintService.getTasks();
      commit("getAllTasks", data);
    },
    addTask: async ({ commit }: any, task: IBaseTaskShape): Promise<void> => {
      const CurrentProjectId: number = localStorage["currentProjectId"];
      const CurrentSprintId: number = localStorage["currentSprintId"];

      const { data, status } = await sprintService.addTask({
        taskName: task.taskName,
        taskDescription: "",
        taskTag: task.taskTag,
        projectId: CurrentProjectId,
        sprintId: CurrentSprintId,
      });

      if (status >= 200 && status <= 299) {
        commit("getAllTasks", data);
      } else {
        console.log("Something went wrong");
      }
    },
    saveTask: async ({ commit }: any, opts: TaskModel) => {
      const { status } = await sprintService.saveTask(opts);

      if (status >= 200 && status <= 299) {
        console.log("saved!");
      }
    },
    updateTasks: async (
      { commit }: any,
      opts: { taskId: number; targetContainer: string }
    ) => {
      const { status } = await sprintService.updateTaskStatus(opts);
      if (status >= 200 && status <= 299) {
        commit("updateTasks", opts);
      } else {
        console.log("Something went wrong");
      }
    },
    getCurrentSprint: async (context: any) => {
      context.state.loading = true;
      const { data, status } = await sprintService.getCurrentSprint();

      if (status >= 200 && status <= 299) {
        context.state.loading = false;
        context.commit("setInitalSprint", data);
      } else {
        console.log("Something went wrong");
      }
    },
  },
  mutations: {
    setInitalSprint: async (state: sprintState, sprint: SprintModel) => {
      state.currentSprintNumber = sprint.sprintId;
      localStorage.setItem("currentSprintId", JSON.stringify(sprint.sprintId));
    },
    setCurrentSprint: (state: sprintState, sprint: number) => {
      state.currentSprintNumber = sprint;
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
