<template>
  <side-nav />
  <div class="main">
    <router-view />
  </div>
</template>

<script>
import SideNav from "@/components/SideNav.vue";
export default {
  components: { SideNav },
};
</script>

<style scoped>
.main {
  margin-left: 160px;
}
</style>