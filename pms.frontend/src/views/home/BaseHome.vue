<template>
  <side-nav />
  <TopHeader />
  <div class="main">
    <router-view />
  </div>
</template>

<script>
import SideNav from "@/components/SideNav.vue";
import TopHeader from "@/components/TopHeader.vue";
export default {
  components: { SideNav, TopHeader },
};
</script>

<style scoped>
.main {
  margin-left: 160px;
}
</style>