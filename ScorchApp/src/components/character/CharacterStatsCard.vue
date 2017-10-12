<template>
  <div class="character-stat-card">
  <div class="card">
    <div class="card-header">
      Stats
    </div>
    <div class="card-body">
      <div v-for="(statValue, stat, index) in stats" :key="index">
        <strong>{{ stat }}:</strong>
        <span class="stat">{{ statValue }}</span>
      </div>
    </div>
</div>
  </div>
</template>

<script>
export default {
  name: 'character-stat-card',
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

.character-stat-card {
  width: 100%;
}

</style>
