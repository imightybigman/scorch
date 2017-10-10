<template>
  <div class="stats-panel">
  <div class="card">
    <div class="card-header">
      Stats
    </div>
    <div class="card-body">
      <p v-for="(statValue, stat, index) in stats" :key="index">
        <span>{{ stat }}:</span>
        <span class="stat"><strong>{{ statValue }}</strong></span>
      </p>
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
.stat {
  float: right;
}

</style>
