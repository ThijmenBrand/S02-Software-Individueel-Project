<template>
  <div id="app">
    <top-header />
    <div class="main">
      <router-view />
    </div>
  </div>
</template>

<script>
import TopHeader from "@/components/TopHeader.vue";

export default {
  components: { TopHeader },
};
</script>

<style lang="scss" scoped>
@import url("./styles/main.scss");

.main {
  margin-top: 80px;
}
</style>
