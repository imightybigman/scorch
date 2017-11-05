<template>
<div class="character-stat-card">
  <div class="card card-width">
    <div class="card-header" role="tab" id="character-spell-slots">
      <h5 class="mb-0">
        <a data-toggle="collapse" href="#spell-slots" aria-expanded="false" aria-controls="spell-slots">Spell Slots</a>
      </h5>
    </div>
    <div id="spell-slots" class="collapse" role="tabpanel" aria-labelledby="character-spell-slots" data-parent="#character-details">
      <div class="card-body">
        <div v-for="(spell, index) in slots" :key="index">
          <strong>Spell Level: {{ spell.SpellLevel }}</strong>
          <span class="spell">{{ spell.Count }} Slots</span>
        </div>
      </div>
    </div>
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
