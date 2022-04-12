import UserShape, { creds, User } from "@/models/user/user";
import router from "@/router";
import { userService } from "@/services/login/userService";

interface loginState {
  user: UserShape;
}

const selectProject = {
  namespaced: true,
  state(): loginState {
    return {
      user: new User({ token: "", userEmail: "", userId: 0, userName: "" }),
    };
  },
  getters: {
    getUser: (state: loginState) => {
      return state.user;
    },
  },
  actions: {
    logUserIn: async ({ commit }: any, creds: creds): Promise<boolean> => {
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
        commit("SET_USER", data);
        router.push("/home");
        return true;
      }

      return false;
    },
    logOut: async (context: any) => {
      userService.logout();
      location.reload();
    },
  },
  mutations: {
    SET_USER(state: loginState, user: UserShape) {
      localStorage.setItem("user", JSON.stringify(user));
      state.user = user;
    },
  },
};

export default selectProject;
