<template>
<div class="spell-info">
    <div v-for="(spell, index) in slots" :key="index">
      <strong>Level {{ spell.SpellLevel }} Spell Slots</strong>
      <span class="stat">{{ spell.Count }} Slots</span>
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
    </div>
</div>
</template>

<script>
export default {
    name: 'spell-info',
    props: ['characterClass', 'level'],
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
    slots() {
      if(!this.characterClass.SpellSlots){
        return []
      }
      let levelKey = `Level_${this.level}`;
      return this.characterClass.SpellSlots[levelKey] || [];
    },
    levelKey() {
      return `Level_${this.level}`;
    }
  },
}
</script>


<style lang="scss">
.stat {
  float: right;
}
</style>