<template>
<div class="character-stat-card d-flex card">
  <div class="card-body">
    <h5>Character Stats</h5>
    <div class="d-flex">
        <span class="stat">Str: {{ stats.Strength }} <strong>{{ getABM(stats.Strength) }}</strong></span>
        <span class="stat">Dex: {{ stats.Dexterity }} <strong>{{ getABM(stats.Dexterity) }}</strong></span>
        <span class="stat">Con: {{ stats.Constitution }} <strong>{{ getABM(stats.Constitution) }}</strong></span>
        <span class="stat">Int: {{ stats.Intelligence }} <strong>{{ getABM(stats.Intelligence) }}</strong></span>
      </div>
      <div class="d-flex">
        <span class="stat">Wis: {{ stats.Wisdom }} <strong>{{ getABM(stats.Wisdom) }}</strong></span>
        <span class="stat">Cha: {{ stats.Charisma }} <strong>{{ getABM(stats.Charisma) }}</strong></span>
        <span class="stat">Prof: {{ getProf(level) }}</span>
        <span class="stat">Hit Die: {{ characterClass.HitDice }}</span>
      </div>
  </div>
</div>
</template>

<script>
import { AbilityModifierService, LevelService } from 'services'
export default {
  name: 'character-stat-card',
  props: ['stats', 'level', 'characterClass'], 
  methods: {
    getABM(val) {
      let mod = AbilityModifierService.getAbilityModifier(val);
      mod = mod > -1 ? `+${mod}` : mod;
      return mod ? `(${mod})` : '';
    }, 
    getProf(level) {
      return LevelService.getProficienyBonus(level)
    }
  }
}
</script>

<style lang="scss" scoped>
@import "~styles/shared.scss";

.character-stat-card {
  flex: 1 0;
  max-height: 115px;
}

.stat {
  flex: 1;
}
</style>
