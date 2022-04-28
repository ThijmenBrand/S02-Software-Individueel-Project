import User from "@/models/user/user";
import LocalStorageHandler from "../localStorageHelper/LocalStorageHelper";

export default function authHeader(): string {
  const user: User = LocalStorageHandler.getItem("user");

  if (user && user.token) {
    return user.token;
  } else {
    return "";
  }
}
