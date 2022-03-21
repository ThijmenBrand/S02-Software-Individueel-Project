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
  getCurrentSprint() {
    const CurrentProjectId: number = localStorage["currentProjectId"];
    return API.get(`Sprints/currentSprint/${CurrentProjectId}`);
  },
};
