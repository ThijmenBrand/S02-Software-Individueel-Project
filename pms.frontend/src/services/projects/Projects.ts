import axios from "axios";
import ProjectsModel from "@/models/projects/ProjectsModel";

export async function getAllProjects() {
  try {
    const data = await axios.get<ProjectsModel[]>(
      "http://localhost:8080/api/Projects"
    );
    return data;
  } catch (error) {
    return error;
  }
}
