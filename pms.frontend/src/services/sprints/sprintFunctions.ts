import SprintModel, { IBaseSprintShape } from "@/models/sprint/SprintModel";
import TaskModel from "@/models/tasks/Taskmodel";
import API from "@/services/api";
import { AxiosResponse } from "axios";

export const sprintService = {
  getAllSprints(): Promise<AxiosResponse<any, any>> {
    const CurrentProjectId: number = localStorage["currentProjectId"];
    return API.get(`Sprints/${CurrentProjectId}`);
  },
  getTasks(): Promise<AxiosResponse<any, any>> {
    const CurrentProjectId: number = localStorage["currentProjectId"];
    const CurrentSprintId: number = localStorage["currentSprintId"];
    return API.get(`Tasks/Sprint/${CurrentSprintId}/${CurrentProjectId}`);
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
    const CurrentProjectId: number = localStorage["currentProjectId"];
    return API.get(`Sprints/currentSprint/${CurrentProjectId}`);
  },
  deleteTask(taskId: number): Promise<AxiosResponse<any, any>> {
    const CurrentProjectId: number = localStorage["currentProjectId"];
    const CurrentSprintId: number = localStorage["currentSprintId"];
    return API.delete(`Tasks/${taskId}/${CurrentSprintId}/${CurrentProjectId}`);
  },
  addSprint(opts: IBaseSprintShape): Promise<AxiosResponse<any, any>> {
    const CurrentProjectId: number = localStorage["currentProjectId"];
    return API.post("Sprints", {
      sprintName: opts.sprintName,
      sprintEnd: opts.sprintEnd,
      sprintStart: opts.sprintStart,
      projectId: CurrentProjectId,
    });
  },
  getCurrentSprintDetails(sprintId: number): Promise<AxiosResponse<any, any>> {
    return API.get(`Sprints/currentSprint/Details/${sprintId}`);
  },
  updateSprint(sprint: SprintModel): Promise<AxiosResponse<any, any>> {
    return API.put(`Sprints/update`, sprint);
  },
};
