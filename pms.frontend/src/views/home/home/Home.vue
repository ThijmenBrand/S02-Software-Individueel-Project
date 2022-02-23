<template>
  <div>
    <div class="welcome-message-container">
      <div class="message-container">
        <h3 class="welcome-message">{{ welcomeMessage }}</h3>
        <p class="project-message">{{ projectMessage }}</p>
      </div>
      <el-input v-model="input" placeholder="Search your project" />
    </div>
  </div>
</template>

<script>
import { ElInput } from "element-plus";
import { ref } from "vue";
export default {
  components: { ElInput },
  setup() {
    const welcomeMessage = "Welcome back Thijmen!";
    const projectMessage = "Lets get to work with testproject!";

    const input = ref("");

    return { welcomeMessage, projectMessage, input };
  },
};
</script>

<style>
.message-container {
  width: 100%;
  display: inline-block;
}
.project-message {
  color: gray;
}
.el-input {
  width: 20%;
  display: inline-block;
}

.welcome-message-container {
  width: 70%;
  display: flex;
  justify-content: center;
  align-content: space-between;
}
</style>