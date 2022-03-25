<template>
  <div class="modal-backdrop">
    <div class="modal">
      <header class="modal-header">
        <Close class="icon close-btn" @click="close" />
      </header>
      <section class="modal-body">
        <h3><Eleme />New sprint</h3>
        <p>sprint time range</p>
        <ElDatePicker
          v-model="sprintRange"
          type="daterange"
          range-separator="To"
          start-placeholder="Start date"
          end-placeholder="End date"
        />
      </section>
      <footer class="modal-footer">
        <button class="btn create-btn" @click="create">Create</button>
        <button class="btn cancel-btn" @click="close">Cancel</button>
      </footer>
    </div>
  </div>
</template>


<script lang="ts">
import { Close, Eleme } from "@element-plus/icons-vue";
import { ElDatePicker } from "element-plus";
import { computed, ref } from "vue";
import { useStore } from "vuex";
export default {
  name: "SprintModal",
  components: { Close, ElDatePicker, Eleme },
  emits: ["close"],
  setup(props: any, { emit }: any) {
    const store = useStore();

    const close = () => {
      emit("close");
    };

    const sprintDateRange = ref([new Date(), new Date()]);

    const sprintRange = computed({
      get() {
        return sprintDateRange.value;
      },
      set(val: any) {
        sprintDateRange.value = val;
      },
    });

    const create = () => {
      store.dispatch("sprints/addSprint", {
        sprintStart: sprintDateRange.value[0],
        sprintEnd: sprintDateRange.value[1],
      });
    };

    return { close, sprintRange, create };
  },
};
</script>

<style scoped lang="scss" src="@/styles/pms/sprintModal.scss" />
