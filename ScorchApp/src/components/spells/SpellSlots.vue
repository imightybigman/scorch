<template>
<div class="character-stat-card">
        <div v-for="(spell, index) in slots" :key="index">
          <strong>Spell Level: {{ spell.SpellLevel }}</strong>
          <span class="spell">{{ spell.Count }} Slots</span>
        </div>
</div>

</template>

<script>

export default {
  name: 'character-stat-card',
  props: ['spellSlots', 'level'],
  computed: {
      slots() {
          let levelKey = `Level_${this.level}`;
          return this.spellSlots[levelKey];
      }
  }
}
</script>

<style lang="scss" scoped>
@import "~styles/shared.scss";

.spell {
  float: right;
}


</style>
