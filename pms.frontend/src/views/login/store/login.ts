import { creds } from "@/models/user/user";
import router from "@/router";
import { userService } from "@/services/login/userService";

const selectProject = {
  namespaced: true,
  state() {
    return {
      user: "",
    };
  },
  getters: {},
  actions: {
    logUserIn: async (context: any, creds: creds): Promise<boolean> => {
      const { data, status } = await userService.login(
        creds.email,
        creds.password
      );

      if (status === 401) {
        // auto logout if 401 response returned from api
        userService.logout();
        location.reload();
        return false;
      }

      if (data.token) {
        localStorage.setItem("user", JSON.stringify(data));
        router.push("/home");
        return true;
      }

      return false;
    },
    logOut: async (context: any) => {
      userService.logout();
    },
  },
  mutations: {},
};

export default selectProject;
