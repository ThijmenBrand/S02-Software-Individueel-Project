<template>
  <div class="modal-backdrop">
    <div class="modal">
      <header class="modal-header">
        <Close class="icon close-btn" @click="close" />
      </header>
      <section class="modal-body">
        <h3><Eleme /><ElInput v-model="sprint.sprintName" /></h3>
        <p>sprint time range</p>
        <ElDatePicker
          v-model="date"
          type="daterange"
          range-separator="To"
          start-placeholder="Start date"
          end-placeholder="End date"
        />
      </section>
      <footer class="modal-footer">
        <button class="btn create-btn" @click="update">Save</button>
        <button class="btn cancel-btn" @click="close">Cancel</button>
      </footer>
    </div>
  </div>
</template>


<script lang="ts">
import { Close, Eleme } from "@element-plus/icons-vue";
import { ElDatePicker, ElInput } from "element-plus";
import { computed, ref } from "vue";
import { useStore } from "vuex";
import SprintModel from "@/models/sprint/SprintModel";
export default {
  name: "UpdateSprintModal",
  components: { Close, ElDatePicker, Eleme, ElInput },
  emits: ["close"],
  setup(props: any, { emit }: any) {
    const store = useStore();

    const close = () => {
      emit("close");
    };

    const sprint = computed((): SprintModel => {
      const details: SprintModel = store.getters["sprints/getSprintDetails"];
      return store.getters["sprints/getSprintDetails"];
    });
    const date = computed({
      get() {
        return [sprint.value.sprintStart, sprint.value.sprintEnd];
      },
      set(val: Array<Date>) {
        sprint.value.sprintStart = val[0];
        sprint.value.sprintEnd = val[1];
      },
    });

    const update = () => {
      store.dispatch("sprints/updateSprint", sprint.value);
      emit("close");
    };

    return { close, update, sprint, date };
  },
};
</script>

<style scoped lang="scss" src="@/styles/pms/sprintModal.scss" />
