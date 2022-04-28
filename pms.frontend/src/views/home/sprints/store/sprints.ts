import ProjectModel from "@/models/project/ProjectsModel";
import SprintModel, { IBaseSprintShape } from "@/models/sprint/SprintModel";
import TaskContainerModel from "@/models/tasks/TaskContainerModel";
import TaskModel, { IBaseTaskShape } from "@/models/tasks/Taskmodel";
import LocalStorageHandler from "@/services/localStorageHelper/LocalStorageHelper";
import { sprintService } from "@/services/sprints/sprintFunctions";

interface sprintState {
  currentSprintNumber: number;
  currentSprint: SprintModel;
  allSprints: SprintModel[];
  sprintView: string;
  taskContainersList: TaskContainerModel[];
  taskItemsList: TaskModel[];
  taskDetails: TaskModel;
}

const sprints = {
  namespaced: true,
  state(): sprintState {
    return {
      currentSprintNumber: 0,
      currentSprint: {
        sprintId: 1,
        sprintName: "",
        sprintStart: new Date(),
        sprintEnd: new Date(),
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
      taskDetails: new TaskModel({
        taskId: 0,
        taskDescription: "",
        taskName: "",
        taskEndTime: new Date(),
        taskStartTime: new Date(),
        taskTag: "",
      }),
    };
  },
  getters: {
    getTaskDetails: (state: sprintState): TaskModel => {
      return state.taskDetails;
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
    getSprintDetails: (state: sprintState): SprintModel => {
      return state.currentSprint;
    },
  },
  actions: {
    getSprints: async ({ commit }: any) => {
      const { data } = await sprintService.getAllSprints();
      commit("getAllSprints", data);
    },
    addSprint: async ({ commit }: any, Data: IBaseSprintShape) => {
      const { data } = await sprintService.addSprint({
        sprintName: Data.sprintName,
        sprintEnd: Data.sprintEnd,
        sprintStart: Data.sprintStart,
      });
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
      const CurrentProject: ProjectModel =
        LocalStorageHandler.getItem("currentProject");
      const CurrentSprintId: number =
        LocalStorageHandler.getItem("currentSprintId");

      const { data, status } = await sprintService.addTask({
        taskName: task.taskName,
        taskDescription: "",
        taskTag: task.taskTag,
        projectId: CurrentProject.projectId,
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
      context.rootState.loading = true;
      const { data, status } = await sprintService.getCurrentSprint();

      if (status >= 200 && status <= 299) {
        context.rootState.loading = false;
        context.commit("setInitalSprint", data);
      } else {
        console.log("Something went wrong");
      }
    },
    getCurrentSprintDetails: async (context: any, sprintId: number) => {
      context.rootState.loading = true;
      const { data, status } = await sprintService.getCurrentSprintDetails(
        sprintId
      );
      if (status >= 200 && status <= 299) {
        context.rootState.loading = false;
        context.commit("setCurrentSprint", data[0]);
      } else {
        console.log("Something went wrong");
      }
    },
    updateSprint: async (context: any, sprint: SprintModel) => {
      const { status } = await sprintService.updateSprint(sprint);
    },
    getTaskDetails: async (context: any, taskId: number) => {
      if (taskId != 0) {
        const { data } = await sprintService.getTaskDetails(taskId);
        context.commit("setTaskDetails", data);
      }
    },
  },
  mutations: {
    setTaskDetails: async (state: sprintState, task: TaskModel) => {
      state.taskDetails = task;
    },
    setInitalSprint: async (state: sprintState, sprint: SprintModel) => {
      state.currentSprint = sprint;
      state.currentSprintNumber = sprint.sprintId;
      LocalStorageHandler.setItem("currentSprintId", sprint.sprintId);
    },
    setCurrentSprint: (state: sprintState, sprint: SprintModel) => {
      state.currentSprint = sprint;
      LocalStorageHandler.setItem("currentSprintId", sprint.sprintId);
    },
    setCurrentSprintNumber: (state: sprintState, sprintId: number) => {
      state.currentSprintNumber = sprintId;
      LocalStorageHandler.setItem("currentSprintId", sprintId);
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
    emptySprints: (state: sprintState) => {
      (state.currentSprintNumber = 0),
        (state.currentSprint = {
          sprintId: 1,
          sprintName: "",
          sprintStart: new Date(),
          sprintEnd: new Date(),
        }),
        (state.allSprints = []),
        (state.sprintView = "board"),
        (state.taskContainersList = [
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
        ]),
        (state.taskItemsList = []);
    },
    emptyTaskDetails: (state: sprintState) => {
      state.taskDetails = new TaskModel({
        taskId: 0,
        taskName: "",
        taskDescription: "",
        taskStartTime: new Date(),
        taskEndTime: new Date(),
        taskTag: "",
      });
    },
  },
};

export default sprints;
