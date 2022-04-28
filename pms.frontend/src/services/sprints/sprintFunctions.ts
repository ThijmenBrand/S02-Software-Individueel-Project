import ProjectModel from "@/models/project/ProjectsModel";
import SprintModel, { IBaseSprintShape } from "@/models/sprint/SprintModel";
import TaskModel from "@/models/tasks/Taskmodel";
import API from "@/services/api";
import { AxiosResponse } from "axios";
import LocalStorageHandler from "../localStorageHelper/LocalStorageHelper";

export const sprintService = {
  getAllSprints(): Promise<AxiosResponse<any, any>> {
    const CurrentProject: ProjectModel =
      LocalStorageHandler.getItem("currentProject");
    return API.get(`Sprints/${CurrentProject.projectId}`);
  },
  getTasks(): Promise<AxiosResponse<any, any>> {
    const CurrentProject: ProjectModel =
      LocalStorageHandler.getItem("currentProject");
    const CurrentSprintId: number =
      LocalStorageHandler.getItem("currentSprintId");
    return API.get(
      `Tasks/Sprint/${CurrentSprintId}/${CurrentProject.projectId}`
    );
  },
  addTask(Task: any): Promise<AxiosResponse<any, any>> {
    return API.post("Tasks", Task);
  },
  saveTask(Task: TaskModel): Promise<AxiosResponse<any, any>> {
    return API.put("Tasks/update", Task);
  },
  updateTaskStatus(Opts: {
    taskId: number;
    targetContainer: string;
  }): Promise<AxiosResponse<any, any>> {
    return API.put(`Tasks/${Opts.taskId}`, Opts.targetContainer);
  },
  getCurrentSprint(): Promise<AxiosResponse<any, any>> {
    const CurrentProject: ProjectModel =
      LocalStorageHandler.getItem("currentProject");
    return API.get(`Sprints/currentSprint/${CurrentProject.projectId}`);
  },
  deleteTask(taskId: number): Promise<AxiosResponse<any, any>> {
    const CurrentProject: ProjectModel =
      LocalStorageHandler.getItem("currentProject");
    const CurrentSprintId: number =
      LocalStorageHandler.getItem("currentSprintId");
    return API.delete(
      `Tasks/${taskId}/${CurrentSprintId}/${CurrentProject.projectId}`
    );
  },
  addSprint(opts: IBaseSprintShape): Promise<AxiosResponse<any, any>> {
    const CurrentProject: ProjectModel =
      LocalStorageHandler.getItem("currentProject");
    return API.post("Sprints", {
      sprintName: opts.sprintName,
      sprintEnd: opts.sprintEnd,
      sprintStart: opts.sprintStart,
      projectId: CurrentProject.projectId,
    });
  },
  getCurrentSprintDetails(sprintId: number): Promise<AxiosResponse<any, any>> {
    return API.get(`Sprints/currentSprint/Details/${sprintId}`);
  },
  updateSprint(sprint: SprintModel): Promise<AxiosResponse<any, any>> {
    return API.put(`Sprints/update`, sprint);
  },
  getTaskDetails(taskid: number): Promise<AxiosResponse<any, any>> {
    return API.get(`Tasks/details/${taskid}`);
  },
};
