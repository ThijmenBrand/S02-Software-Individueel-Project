import ProjectModel from "@/models/project/ProjectsModel";
import { AxiosResponse } from "axios";
import API from "../api";
import LocalStorageHandler from "../localStorageHelper/LocalStorageHelper";

export const calenderFunctions = {
  getAllTasksByProject(): Promise<AxiosResponse<any, any>> {
    const CurrentProject: ProjectModel =
      LocalStorageHandler.getItem("currentProject");
    return API.get(`Tasks/${CurrentProject.projectId}`);
  },
};
