<template>
<div class="character-stat-card">
  <div class="card card-width">
    <div class="card-header" role="tab" id="character-stats">
      <h5 class="mb-0">
        <a data-toggle="collapse" href="#stats" aria-expanded="false" aria-controls="stats">Stats</a>
      </h5>
    </div>
    <div id="stats" class="collapse show" role="tabpanel" aria-labelledby="character-stats" data-parent="#character-details">
      <div class="card-body">
        <div v-for="(statValue, stat, index) in stats" :key="index">
          <strong>{{ stat }}:</strong>
          <span class="stat">{{ statValue }} {{ getABM(statValue) }}</span>
        </div>
        <div>
          <strong>Proficiency:</strong>
          <span class="stat">{{ proficiency }}</span>
        </div>
        <hr> <!-- Break line for spell stuff -->
        <div v-if="characterClass && characterClass.Name.indexOf(['Bard', 'Warlock']) !== -1">
          <strong>Known Cantrips:</strong>
          <span class="stat">{{ knownCantrips }}</span>
        </div>
        <div v-if="characterClass && characterClass.Name.indexOf(['Bard', 'Warlock', 'Ranger']) !== -1">
          <strong>Known Spells:</strong>
          <span class="stat">{{ knownSpells }}</span>
        </div>
        <div v-if="characterClass && characterClass.Name === 'Warlock'">
          <strong>Known Invocations:</strong>
          <span class="stat">{{ knownInvocations }}</span>
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


</style>
