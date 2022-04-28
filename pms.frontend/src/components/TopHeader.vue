<template>
  <div class="top-header">
    <div class="project-info">
      <h4>{{ currentRoute }}</h4>
      <span class="project-details"
        ><p>{{ projectInfo.projectName }}</p>
        <span class="DOT"></span>
        <p>{{ userInfo.userName }}</p></span
      >
    </div>
    <div class="user-info">
      <ElAvatar>{{ userInfo.userName.substr(0, 2) }}</ElAvatar>
      <h4>{{ userInfo.userName }}</h4>
      <ElDropdown>
        <span>
          <ArrowDown />
        </span>
        <template #dropdown>
          <el-dropdown-menu class="dropdown-menu">
            <el-dropdown-item>My profile</el-dropdown-item>
            <el-dropdown-item>Settings</el-dropdown-item>
            <el-dropdown-item divided style="color: red" @click="logout()"
              >Logout</el-dropdown-item
            >
          </el-dropdown-menu>
        </template>
      </ElDropdown>
    </div>
  </div>
</template>

<script lang="ts">
import { computed } from "@vue/runtime-core";
import { useStore } from "vuex";
import { useRouter } from "vue-router";
import ProjectModel from "@/models/project/ProjectsModel";
import UserShape from "@/models/user/user";
import { ArrowDown, UserFilled } from "@element-plus/icons-vue";
import {
  ElAvatar,
  ElDropdown,
  ElDropdownItem,
  ElDropdownMenu,
} from "element-plus";
import LocalStorageHandler from "@/services/localStorageHelper/LocalStorageHelper";
export default {
  components: {
    ArrowDown,
    ElAvatar,
    ElDropdown,
    ElDropdownItem,
    ElDropdownMenu,
  },
  setup() {
    const store = useStore();
    const router = useRouter();

    const currentRoute = computed(() => router.currentRoute.value.name);

    const projectInfo = computed(
      (): ProjectModel => store.getters["selectProject/getCurrentProject"]
    );

    const userInfo = computed(
      (): UserShape => LocalStorageHandler.getItem("user")
    );

    const logout = () => store.dispatch("login/logOut");
    return { projectInfo, currentRoute, userInfo, logout };
  },
};
</script>

<style scoped lang="scss">
.top-header {
  background-color: rgb(243, 243, 243);
  margin-left: 150px;
  display: flex;
  justify-content: space-between;
  padding: 0px 20px 0px 20px;
  color: rgb(100, 100, 100);
  .project-info {
    margin-top: 10px;
    h4 {
      margin: 0;
      font-weight: lighter;
      font-size: 25px;
    }
    .project-details {
      display: flex;
      align-items: center;
      justify-content: space-between;
      width: 120%;
      p {
        margin: 0;
      }
      .DOT {
        height: 10px;
        width: 10px;
        border-radius: 50%;
        background-color: blue;
      }
    }
  }
  .user-info {
    display: flex;
    align-items: center;
    justify-content: space-between;
    width: 170px;
    .dropdown-menu {
      padding: 200px;
    }
    h4 {
      font-size: 20px;
      font-weight: 500;
    }
    img {
      height: 50px;
      width: 50px;
      border-radius: 50%;
    }
    .icon {
      height: 20px;
      width: 20px;
    }
  }
}
</style>
