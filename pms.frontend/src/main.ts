import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import 'element-plus/dist/index.css';
import VueSidebarMenu from 'vue-sidebar-menu'
import 'vue-sidebar-menu/dist/vue-sidebar-menu.css'

createApp(App).use(store).use(router).mount("#app");
