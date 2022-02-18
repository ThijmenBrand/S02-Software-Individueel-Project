<template>
  <div class="top-header">
    <router-link to="/">
      <img class="logo" src="@/assets/Logo.svg" />
    </router-link>
    <div class="profile-info">
      <div class="profile-picture"></div>
      <p class="profile-name">Anne fleur</p>
      <img class="drop-down" src="@/assets/DropDownBtn.svg" />
    </div>
  </div>
</template>

<script>
export default {};
</script>

<style scoped>
.top-header {
  position: fixed;
  top: 0;
  width: 100%;
  background-color: white;
  border: 0.5px solid #d4d4d4;
  height: 80px;
  display: flex;
  justify-content: space-between;
  align-items: center;
  color: #9da4bd;
}

.logo {
  height: 55px;
  width: 55px;
  margin-left: 10px;
}

.profile-info {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
  width: 170px;
  margin-right: 20px;
}

.profile-picture {
  background-color: blue;
  border-radius: 50%;
  height: 40px;
  width: 40px;
  display: inline-block;
}

.profile-name {
  float: right;
}
</style>
