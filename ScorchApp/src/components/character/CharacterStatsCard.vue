<template>
<div class="character-stat-card card">
  <div class="card-body">
    <div class="d-flex">
        <span>Str: {{ stats.Strength }} {{ getABM(stats.Strength) }}</span>
        <span>Dex: {{ stats.Dexterity }} {{ getABM(stats.Dexterity) }}</span>
        <span>Con: {{ stats.Constitution }} {{ getABM(stats.Constitution) }}</span>
      </div>
      <div class="d-flex">
        <span>Int: {{ stats.Intelligence }} {{ getABM(stats.Intelligence) }}</span>
        <span>Wis: {{ stats.Wisdom }} {{ getABM(stats.Wisdom) }}</span>
        <span>Cha: {{ stats.Charisma }} {{ getABM(stats.Charisma) }}</span>
      </div>
    <span>Pro: {{ proficiency }}</span>
  </div>
</div>
  <!-- <div v-for="(statValue, stat, index) in stats" :key="index">
    <strong>{{ stat }}:</strong>
    <span class="stat">{{ statValue }} {{ getABM(statValue) }}</span>
  </div>
  <div>
    <strong>Proficiency:</strong>
    <span class="stat">{{ proficiency }}</span>
  </div>
  <div>
    <strong>Hit Dice:</strong>
    <span class="stat">{{ characterClass.HitDice }}</span>
  </div>
  
  <div v-if="characterClass && ['Bard', 'Warlock'].indexOf(characterClass.Name) !== -1">
    <strong>Known Cantrips:</strong>
    <span class="stat">{{ knownCantrips }}</span>
  </div>
  <div v-if="characterClass && ['Bard', 'Warlock', 'Ranger'].indexOf(characterClass.Name) !== -1">
    <strong>Known Spells:</strong>
    <span class="stat">{{ knownSpells }}</span>
  </div>
  <div v-if="characterClass && characterClass.Name === 'Warlock'">
    <strong>Known Invocations:</strong>
    <span class="stat">{{ knownInvocations }}</span>
  </div> -->
</div>

</template>

<script>
import { AbilityModifierService } from 'services'
export default {
  name: 'character-stat-card',
  props: ['stats', 'proficiency', 'characterClass', 'level'], 
  computed: {
    knownSpells() {
      return this.characterClass && this.characterClass.SpellsKnown[this.levelKey];
    },
    knownCantrips() {
      return this.characterClass && this.characterClass.CantripsKnown[this.levelKey];
    },
    knownInvocations() {
      return this.characterClass && this.characterClass.InvocationsKnown[this.levelKey];
    },
    levelKey() {
      return `Level_${this.level}`;
    }
  },
  methods: {
    getABM(val) {
      let mod = AbilityModifierService.getAbilityModifier(val);
      mod = mod > -1 ? `+${mod}` : mod;
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

hr {
    color: white;
    background-color: white;
}

</style>
