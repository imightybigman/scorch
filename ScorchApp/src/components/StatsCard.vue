<template>
  <div class="stats-panel">
  <div class="card">
    <div class="card-body">
      <h4 class="card-title">{{ strength }}</h4>
      <h4 class="card-title">{{ dexterity }}</h4>
      <h4 class="card-title">{{ constitution }}</h4>
      <h4 class="card-title">{{ intelligence }}</h4>
      <h4 class="card-title">{{ wisdom }}</h4>
      <h4 class="card-title">{{ charisma }}</h4>
    </div>
</div>
  </div>
</template>

<script>
export default {
  name: 'stats-panel',
  props: ['stats'], 
  computed: {
    strength: function() {
      return `Str: ${this.stats.Strength}`;
    },
    dexterity: function() {
      return `Dex: ${this.stats.Dexterity}`;
    },
    constitution: function() {
      return `Con: ${this.stats.Constitution}`;
    },
    intelligence: function() {
      return `Int: ${this.stats.Intelligence}`;
    },
    wisdom: function() {
      return `Wis: ${this.stats.Wisdom}`;
    },
    charisma: function() {
      return `Cha: ${this.stats.Charisma}`;
    }   
  }
}
</script>

<style lang="scss" scoped>


</style>
