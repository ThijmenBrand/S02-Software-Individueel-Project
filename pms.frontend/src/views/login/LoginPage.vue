<template>
  <div class="row">
    <div class="column">
      <div class="login-header">
        <img src="@/assets/Logo.svg" />
        <h1>Login</h1>
        <p>Enter your credentials to gain access to your account</p>
      </div>
      <div class="login-form">
        <ElForm :model="loginInput">
          <ElFormItem>
            <p>Email</p>
            <ElInput v-model="loginInput.email" />
          </ElFormItem>
          <ElFormItem>
            <p>Password</p>
            <ElInput type="password" v-model="loginInput.password" />
          </ElFormItem>
          <ElFormItem>
            <ElButton type="primary" @click="submitLogin()">Login</ElButton>
          </ElFormItem>
        </ElForm>
      </div>
    </div>
    <div class="column right">
      <h1>
        Project<br />
        Management<br />
        system
      </h1>
    </div>
  </div>
</template>

<script>
import { ElForm, ElFormItem, ElInput, ElButton } from "element-plus";
import { reactive } from "vue";
import { useStore } from "vuex";
import { useRouter } from "vue-router";
export default {
  name: "LoginPage",
  components: { ElForm, ElFormItem, ElInput, ElButton },
  setup() {
    const store = useStore();
    const router = useRouter();

    const loginInput = reactive({
      email: "",
      password: "",
    });

    const submitLogin = () => {
      let login = store.dispatch("login/logUserIn", loginInput);
      login ? router.push("/home") : console.log("creds incorrect");
    };

    return { loginInput, submitLogin };
  },
};
</script>

<style lang="scss" scoped>
.row {
  display: flex;
  font-family: "Segoe UI";
}

.column {
  flex: 50%;
}
.right {
  background-image: url("../..//assets/login-background.jpg");
  height: 100vh;
  color: white;
  font-weight: bold;
  font-size: 3vw;
  display: flex;
  align-items: center;
  justify-content: center;
  h1 {
    text-align: left;
  }
}
</style>