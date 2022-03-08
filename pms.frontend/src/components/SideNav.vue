<template>
  <div class="side-nav-menu">
    <router-link to="/">
      <div class="logo-header-container">
        <img class="logo" src="@/assets/Logo.svg" />
        <h2 class="title">PMS</h2>
      </div>
    </router-link>
    <div class="menu-items-container">
      <hr />
      <div class="menu-links-container">
        <router-link
          :to="{ name: 'Dashboard', params: { id: this.$route.params.id } }"
        >
          <div class="menu-nav-item">
            <el-icon><house /></el-icon>
            <p class="item-title">Home</p>
          </div>
        </router-link>
        <router-link
          :to="{ name: 'Files', params: { id: this.$route.params.id } }"
        >
          <div class="menu-nav-item">
            <el-icon><collection /></el-icon>
            <p class="item-title">Assets</p>
          </div>
        </router-link>
        <router-link
          :to="{ name: 'Sprints', params: { id: this.$route.params.id } }"
        >
          <div class="menu-nav-item">
            <el-icon><eleme /></el-icon>
            <p class="item-title">Sprints</p>
          </div>
        </router-link>
        <router-link
          :to="{ name: 'Calender', params: { id: this.$route.params.id } }"
        >
          <div class="menu-nav-item">
            <el-icon><calendar /></el-icon>
            <p class="item-title">Calender</p>
          </div>
        </router-link>
        <router-link
          :to="{ name: 'TimeTracking', params: { id: this.$route.params.id } }"
        >
          <div class="menu-nav-item">
            <el-icon><clock /></el-icon>
            <p class="item-title">Time</p>
          </div>
        </router-link>
        <router-link
          :to="{ name: 'Settings', params: { id: this.$route.params.id } }"
        >
          <div class="menu-nav-item">
            <el-icon><setting /></el-icon>
            <p class="item-title">Settings</p>
          </div>
        </router-link>
      </div>
      <div class="user-container">
        <router-link
          :to="{ name: 'Account', params: { id: this.$route.params.id } }"
        >
          <img class="profile-picture" src="@/assets/pf.jpg" />
        </router-link>
      </div>
    </div>
  </div>
</template>

<script>
import {
  House,
  Collection,
  Eleme,
  Calendar,
  Clock,
  Setting,
} from "@element-plus/icons-vue";
import ElIcon from "element-plus/lib/components/icon";

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
};
</script>

<style scoped>
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
  width: 150px;
  height: 100%;
  float: left;
  position: fixed;
  z-index: 1;
  top: 0;
  bottom: 0;
  background-color: #f0f0f0;
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

.user-container {
  position: absolute;
  bottom: 10px;
  width: 150px;
  display: flex;
  justify-content: center;
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