import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import * as cookies from "tiny-cookie";
import "element-plus/dist/index.css";

createApp(App).use(store).use(router).mount("#app");
