<template>
  <div class="side-nav-menu">
    <div class="logo-header-container">
      <img class="logo" src="@/assets/Logo.svg" />
      <h2 class="title">PMS</h2>
    </div>
    <div class="menu-items-container">
      <hr />
      <div class="menu-links-container">
        <router-link
          :to="{ name: 'Dashboard', params: { id: $route.params.id } }"
        >
          <div class="menu-nav-item">
            <el-icon><house /></el-icon>
            <p class="item-title">Home</p>
          </div>
        </router-link>
        <router-link :to="{ name: 'Files', params: { id: $route.params.id } }">
          <div class="menu-nav-item">
            <el-icon><collection /></el-icon>
            <p class="item-title">Assets</p>
          </div>
        </router-link>
        <router-link
          :to="{ name: 'Sprints', params: { id: $route.params.id } }"
        >
          <div class="menu-nav-item">
            <el-icon><eleme /></el-icon>
            <p class="item-title">Sprints</p>
          </div>
        </router-link>
        <router-link
          :to="{ name: 'Calender', params: { id: $route.params.id } }"
        >
          <div class="menu-nav-item">
            <el-icon><calendar /></el-icon>
            <p class="item-title">Calender</p>
          </div>
        </router-link>
        <router-link
          :to="{ name: 'TimeTracking', params: { id: $route.params.id } }"
        >
          <div class="menu-nav-item">
            <el-icon><clock /></el-icon>
            <p class="item-title">Time</p>
          </div>
        </router-link>
        <router-link
          :to="{ name: 'Settings', params: { id: $route.params.id } }"
        >
          <div class="menu-nav-item">
            <el-icon><setting /></el-icon>
            <p class="item-title">Settings</p>
          </div>
        </router-link>
      </div>
      <hr />
      <div class="project-container">
        <h4>Projects</h4>
        <p
          v-for="(project, index) in projects"
          :key="index"
          @click="HandleRoute(project)"
        >
          {{ project.projectName }}
        </p>
        <router-link to="/home">
          <p style="color: blue">all projects</p>
        </router-link>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import {
  House,
  Collection,
  Eleme,
  Calendar,
  Clock,
  Setting,
} from "@element-plus/icons-vue";
import ElIcon from "element-plus/lib/components/icon";
import { useStore } from "vuex";
import { useRouter } from "vue-router";
import { computed, onMounted } from "vue";
import ProjectModel from "@/models/project/ProjectsModel";

export default {
  components: {
    Setting,
    Clock,
    Calendar,
    Eleme,
    Collection,
    House,
    ElIcon,
  },
  setup() {
    const store = useStore();
    const router = useRouter();

    const projects = computed(() => {
      const list: ProjectModel[] = store.getters["selectProject/projectList"];

      list.forEach((project) => {
        project.projectName.length > 20
          ? (project.projectName = project.projectName.substr(0, 20) + "...")
          : "";
      });

      return list.length > 4 ? list.splice(0, 4) : list;
    });

    const HandleRoute = (val: ProjectModel): void => {
      store
        .dispatch("selectProject/selectCurrentProject", val.projectId)
        .then(() => {
          router.push(`/home/${val.projectName}/dashboard`);
        });
    };

    onMounted(() => {
      store.dispatch("selectProject/fetchProjects");
    });

    return { projects, HandleRoute };
  },
};
</script>

<style scoped lang="scss">
.project-container {
  display: flex;
  flex-direction: column;
  align-items: flex-start;
  margin-left: 20px;
  p {
    font-size: 14px;
    cursor: pointer;
    &:hover {
      color: blue;
    }
  }
}
.v-sidebar-menu {
  border-right: 0.5px solid #d4d4d4;
}

.title {
  display: inline-block;
}

.logo {
  display: inline-block;
}

.logo-header-container {
  display: flex;
  align-items: center;
  justify-content: center;
}

el-icon {
  display: inline-block;
}

.item-title {
  display: inline-block;
  margin-left: 20px;
}

.side-nav-menu {
  width: 160px;
  height: 100%;
  float: left;
  position: fixed;
  z-index: 1;
  top: 0;
  bottom: 0;
  background-color: #f0f0f0;
  overflow: auto;
  scrollbar-width: none;
  -ms-overflow-style: none;
  &::-webkit-scrollbar {
    display: none;
  }
}

.router-link-exact-active {
  color: blue;
}

a {
  color: black;
  text-decoration: none;
}

.menu-nav-item {
  display: flex;
  align-items: center;
  justify-content: left;
  margin-left: 20px;
}

.profile-picture {
  background-color: orange;
  border-radius: 50%;
  height: 50px;
  width: 50px;
  display: inline-block;
}

hr {
  width: 120px;
  height: 1px;
  border: none;
  background-color: gray;
}
</style>
