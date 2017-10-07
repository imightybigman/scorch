<template>
  <div class="character-card">
  <div class="card">
    <img class="card-img-top" src="../assets/blank-background.jpg" alt="Card image cap">
    <div class="card-body">
      <h4 class="card-title">{{ characterInfo.Firstname }}</h4>
      <p class="card-text">{{ description }}</p>
      <router-link class="btn btn-primary" :to="'/character/' + characterInfo.CharacterId">This is me!!</router-link>
    </div>
</div>
  </div>
</template>

<script>
export default {
  name: 'character-card',
  props: ['characterInfo'],
  computed: {
    description: function() {
      return `Lvl: ${this.characterInfo.Level}, Race: ${this.characterInfo.Race}, Class: ${this.characterInfo.Class}`
    }
  }
}
</script>

<style lang="scss" scoped>


</style>
