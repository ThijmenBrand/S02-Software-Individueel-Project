<template>
  <span class="loader"></span>
</template>

<style>
.loader {
  display: flex;
  justify-content: center;
  color: gainsboro;
  font-family: Consolas, Menlo, Monaco, monospace;
  font-weight: bold;
  font-size: 78px;
  opacity: 0.8;
}
.loader:before {
  content: "{";
  display: inline-block;
  animation: pulse 0.4s alternate infinite ease-in-out;
}
.loader:after {
  content: "}";
  display: inline-block;
  animation: pulse 0.4s 0.3s alternate infinite ease-in-out;
}

@keyframes pulse {
  to {
    transform: scale(0.8);
    opacity: 0.5;
  }
}
</style>
