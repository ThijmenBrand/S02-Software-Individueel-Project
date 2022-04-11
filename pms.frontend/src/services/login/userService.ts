import { creds } from "@/models/user/user";
import { AxiosResponse } from "axios";
import API from "../api";
import authHeader from "./authHeader";

export const userService = {
  async login(
    email: string,
    password: string
  ): Promise<AxiosResponse<any, any>> {
    const creds = {
      userEmail: email,
      password: password,
    };

    return API.post("Users/authenticate", creds);
  },
  async logout() {
    localStorage.removeItem("user");
  },
};
