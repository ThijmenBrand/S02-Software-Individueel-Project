<template>
  <sidebar-menu
    :menu="menu"
    :theme="theme"
    :width="width"
    :hideToggle="hideToggle"
  />
</template>

<script>
import { SidebarMenu } from "vue-sidebar-menu";
export default {
  components: {
    SidebarMenu,
  },
  data() {
    return {
      menu: [
        {
          title: "Assets",
          icon: {
            element: "img",
            attributes: {
              src: "https://img.icons8.com/ios-glyphs/30/ffffff/project.png",
            },
          },
          child: [
            {
              href: { name: "Files", params: { id: this.$route.params.id } },
              title: "Files",
              icon: {
                element: "img",
                attributes: {
                  src: "https://img.icons8.com/small/16/000000/opened-folder--v1.png",
                },
              },
            },
            {
              href: { name: "Links", params: { id: this.$route.params.id } },
              title: "Links",
              icon: {
                element: "img",
                attributes: {
                  src: "https://img.icons8.com/ios-glyphs/20/000000/link--v1.png",
                },
              },
            },
          ],
        },
        {
          href: { name: "Sprints", params: { id: this.$route.params.id } },
          title: "Sprints",
          icon: {
            element: "img",
            attributes: {
              src: "https://img.icons8.com/ios-filled/50/ffffff/sprint-iteration.png",
            },
          },
        },
        {
          href: { name: "Board", params: { id: this.$route.params.id } },
          title: "Board",
          icon: {
            element: "img",
            attributes: {
              src: "https://img.icons8.com/ios-filled/50/ffffff/trello.png",
            },
          },
        },
        {
          href: { name: "TimeTracking", params: { id: this.$route.params.id } },
          title: "Time",
          icon: {
            element: "img",
            attributes: {
              src: "https://img.icons8.com/ios-filled/50/ffffff/important-time.png",
            },
          },
        },
        {
          href: { name: "Settings", params: { id: this.$route.params.id } },
          title: "Settings",
          icon: {
            element: "img",
            attributes: {
              src: "https://img.icons8.com/ios-glyphs/30/ffffff/settings--v1.png",
            },
          },
        },
      ],
      width: "150px",
      theme: "white-theme",
      hideToggle: true,
    };
  },
};
</script>

<style scoped>
.v-sidebar-menu {
  margin-top: 80px;
  border-right: 0.5px solid #d4d4d4;
}
</style>