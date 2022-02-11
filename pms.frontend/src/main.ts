import { createApp } from "vue";
import App from "./Base.vue";
import Router from "./router/router";

createApp(App).use(Router).mount("#app");
