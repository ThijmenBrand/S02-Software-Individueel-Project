<template>
  <div class="about">
    <h1>This is an about page</h1>
    <div v-for="item in items" :key="item.id">
      <h3>{{ item.title }}</h3>
      <p>{{ item.body }}</p>
    </div>
  </div>
</template>

<script>
import { getPosts } from "../../services/apiTest";

export default {
  data() {
    let items = [];
    return {
      items,
    };
  },
  mounted() {
    getPosts().then((response) => {
      this.items = response.data;
    });
  },
};
</script>
