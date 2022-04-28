import UserShape, { creds, User } from "@/models/user/user";
import router from "@/router";
import LocalStorageHandler from "@/services/localStorageHelper/LocalStorageHelper";
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
      await userService
        .login(creds.email, creds.password)
        .then(({ data, status }) => {
          if (data.token) {
            commit("SET_USER", data);
            router.push("/home");
            return true;
          }
        })
        .catch((e) => {
          return false;
        });

      return false;
    },
    logOut: async (context: any) => {
      userService.logout();
      location.reload();
    },
  },
  mutations: {
    SET_USER(state: loginState, user: UserShape) {
      LocalStorageHandler.setItem("user", user);
      state.user = user;
    },
  },
};

export default selectProject;
