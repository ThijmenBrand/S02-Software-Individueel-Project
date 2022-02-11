import { createRouter, createWebHistory } from "vue-router";
import Contact from "@/views/Home/contact.vue";
import About from "@/views/Home/About.vue";
import Home from "@/views/Home.vue";


const routes = [
  {
    path: "/",
    name: "Home",
    component: Home,
  },
  {
    path: "/about",
    name: "About",
    component: About,
  },
  {
    path: "/contact",
    name: "Contact",
    component: Contact,
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
