import { createApp } from "vue";
import App from "./App.vue";
import Router from "./router/router";
import Store from "./store/store";
const Styles = require("./styles/main.css");

createApp(App).use(Router).use(Styles).use(Store).mount("#app");
