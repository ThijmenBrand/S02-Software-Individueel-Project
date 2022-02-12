<template>
  <top-header />
  <router-view />
</template>

<script>
import TopHeader from "@/components/TopHeader.vue";

export default {
  components: { TopHeader },
};
</script>
