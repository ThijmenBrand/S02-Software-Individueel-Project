<template>
  <el-button type="primary">
    <slot> Button </slot>
  </el-button>
</template>

<script>
import { ElButton } from 'element-plus';
export default {
  components: { ElButton }
};
</script>

<style>
</style>