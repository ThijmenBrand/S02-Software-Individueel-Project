<template>
  <div class="content">
    <p v-if="projects.length == 0">There is nothing to show</p>
    <div v-else>
      <ElTable
        :data="projects"
        :default-sort="{ prop: 'projectName', order: 'descending' }"
        max-height="380"
        style="width: 100%"
        @current-change="HandleRoute"
      >
        <el-table-column
          prop="projectName"
          label="projectName"
          sortable
          width="300"
        />
        <el-table-column prop="projectOwnerId" label="Owner" />
        <el-table-column label="Date" width="150">
          <template #default="scope">
            <p>{{ formatDate(scope.row.projectDate) }}</p>
          </template>
        </el-table-column>
      </ElTable>
    </div>
    <base-button class="btn" @click="addProject">
      <p>Add new project</p>
    </base-button>
  </div>
</template>

<script lang="ts">
import { ElMessageBox, ElTable, ElTableColumn, ElMessage } from "element-plus";

import BaseButton from "@/components/buttons/BaseButton.vue";
import ProjectModel from "@/models/project/ProjectsModel";

import { useStore } from "vuex";
import { useRouter } from "vue-router";

export default {
  components: { ElTable, ElTableColumn, BaseButton },
  props: {
    projects: { type: Array as () => Array<ProjectModel>, required: true },
  },
  setup() {
    const store = useStore();
    const router = useRouter();

    const HandleRoute = (val: ProjectModel): void => {
      store
        .dispatch("selectProject/selectCurrentProject", val.projectId)
        .then(() => {
          router.push(`/home/${val.projectName}/dashboard`);
        });
    };

    const formatDate = (date: string): string => {
      return date.split("T")[0].split("-").reverse().join("-");
    };

    const addProject = () => {
      ElMessageBox.prompt("Give your new project a name", "New project", {
        confirmButtonText: "Create",
        cancelButtonText: "Cancel",
        inputPlaceholder: "Your new project",
        inputPattern: /^(?!\s*$).+/,
        inputErrorMessage: "Please enter a valid project name",
      }).then(({ value }) => {
        store.dispatch("selectProject/addNewProject", {
          projectName: value,
        });
        ElMessage({
          type: "success",
          message: "Your new project has been created!",
        });
      });
    };

    return { formatDate, addProject, HandleRoute };
  },
};
</script>

<style scoped lang="scss">
@import "../../../styles/variables/colors.scss";

.content {
  width: fit-content;
  margin: auto;
}
.tableName {
  font-size: 37px;
}
thead {
  float: left;
}

.btn {
  background-color: $pms-blue;
  width: 100%;
  margin-top: 20px;
}

.btn:hover {
  background-color: $pms-blue-hover;
}
.btn:active {
  background-color: $pms-blue-hover;
}
</style>
