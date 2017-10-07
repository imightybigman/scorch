<template>
  <div class="character-detail">
  <div class="card">
    <img class="card-img-top" src="../assets/blank-background.jpg" alt="Card image cap">
    <div class="card-body">
      <h4 class="card-title">{{ characterInfo.Firstname }}</h4>
      <p class="card-text">{{ description }}</p>
    </div>
</div>
  </div>
</template>

<script>
export default {
  name: 'character-equip-card',
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
