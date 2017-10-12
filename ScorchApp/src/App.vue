<template>
  <div class="app">
    <div class="home-logo-container">
      <router-link :to="'/'">
        <img class="home-logo" src="./assets/DnD_transparent.png">
      </router-link>
    </div>
    <router-view></router-view>
  </div>
</template>

<script>
export default {
  name: 'app'
}
</script>

<style lang="scss" scoped>
.app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
}

.home-logo-container {
  text-align: center;
}

.home-logo {
  max-width: 50%;
  max-height: 50%;
}
</style>
