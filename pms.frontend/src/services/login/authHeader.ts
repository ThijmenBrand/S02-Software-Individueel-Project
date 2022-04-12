import User from "@/models/user/user";

export default function authHeader(): string {
  const user: User = JSON.parse(localStorage.getItem("user") || "{}");

  if (user && user.token) {
    return user.token;
  } else {
    return "";
  }
}
