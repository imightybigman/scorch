<template>
<div class="character-stat-card">
  <div class="card">
    <div class="card-header" role="tab" id="character-stats">
      <h5 class="mb-0">
        <a data-toggle="collapse" href="#stats" aria-expanded="false" aria-controls="stats">Stats</a>
      </h5>
    </div>
    <div id="stats" class="collapse" role="tabpanel" aria-labelledby="character-stats" data-parent="#accordion">
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
@import "~styles/shared.scss";

.stat {
  float: right;
}

.character-stat-card {
  min-width: $min-card-width;
  width: 100%;
}

</style>
