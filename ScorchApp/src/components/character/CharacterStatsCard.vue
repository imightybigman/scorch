<template>
  <div class="character-stat-card">
    <div class="card">
      <div class="card-header">
        Stats
      </div>
      <div class="card-body">
        <div v-for="(statValue, stat, index) in stats" :key="index">
          <strong>{{ stat }}:</strong>
          <span class="stat">{{ statValue }} {{ getABM(statValue) }}</span>
        </div>
        <div>
          <strong>Proficiency:</strong>
          <span class="stat">{{ proficiency }}</span>
        </div>
      </div>
  </div>
  </div>
</template>

<script>
import { AbilityModifierService } from 'services'

export default {
  name: 'character-stat-card',
  props: ['stats', 'proficiency'], 
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
  },
  methods: {
    getABM(val) {
      let mod = AbilityModifierService.getAbilityModifier(val);
      return mod ? `(${mod})` : '';
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
