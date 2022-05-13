<template>
  <div class="row">
    <div class="column left">
      <div class="login-form">
        <img src="@/assets/Logo.svg" />
        <h1>Login</h1>
        <p>Enter your credentials to gain access to your account</p>
        <p v-if="loginFailed" style="color: red">
          Email or password incorrect!
        </p>
        <ElForm :model="loginInput">
          <ElFormItem>
            <p>Email</p>
            <ElInput v-model="loginInput.email" name="email" />
          </ElFormItem>
          <ElFormItem>
            <p>Password</p>
            <ElInput
              type="password"
              v-model="loginInput.password"
              name="password"
            />
          </ElFormItem>
          <ElFormItem>
            <ElButton type="primary" @click="submitLogin()" id="login"
              >Login</ElButton
            >
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

<script lang="ts">
import { ElForm, ElFormItem, ElInput, ElButton } from "element-plus";
import { reactive, ref } from "vue";
import { useStore } from "vuex";
import { useRouter } from "vue-router";
export default {
  name: "LoginPage",
  components: { ElForm, ElFormItem, ElInput, ElButton },
  setup() {
    const store = useStore();
    const router = useRouter();

    const loginFailed = ref<boolean>(false);

    const loginInput = reactive({
      email: "",
      password: "",
    });

    const submitLogin = () => {
      store.dispatch("login/logUserIn", loginInput).then((succeeded) => {
        loginFailed.value = !succeeded;
      });
    };

    return { loginInput, submitLogin, loginFailed };
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

.login-form {
  padding: 20%;
}
</style>
