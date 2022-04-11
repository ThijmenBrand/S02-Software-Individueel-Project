import axios, { AxiosInstance } from "axios";
import authHeader from "./login/authHeader";

const API: AxiosInstance = axios.create({
  baseURL: "http://localhost:8080/api/",
  headers: {
    Authorization: `Bearer ${authHeader()}`,
    "Content-type": "application/json",
  },
});

export default API;
