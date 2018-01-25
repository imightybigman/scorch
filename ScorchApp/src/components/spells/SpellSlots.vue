<template>
<div class="character-spell-slot">
  <h5>Spell Slots</h5>
  <div class="spell-slot" v-for="(slot, index) in computedSpellSlots" :key="index">
    <div class="slot-level">Level {{ slot.SpellLevel }}</div>
    <div v-for="(usedSlots, usedIndex) in slot.usedSlots" :key="usedIndex">
      <i class="used ra ra-diamonds ra-2x"></i>
    </div>
    <div v-for="(availableSlots, availableIndex) in slot.availableSlots" :key="availableIndex">
      <i class="available ra ra-diamonds ra-2x"></i>
    </div>
    <div class="spell-slot-btn-container">
      <button class="spell-slot-btn btn btn-primary" @click="useSpellSlot(index)" :disabled="slot.useButtonDisabled">Use</button>
      <button class="spell-slot-btn btn btn-primary btn-success" @click="gainSpellSlot(index)" :disabled="slot.gainButtonDisabled">Gain</button>
    </div>
  </div>
</div>

</template>

<script>
import map  from 'lodash/map'

export default {
  name: 'character-stat-card',
  props: ['characterId', 'spellSlots', 'level'],
  computed: {
    computedSpellSlots() {
      if(!this.spellSlots){
        return [];
      }
      return map(this.spellSlots, (slot) => {
        slot.usedSlots = [];
        slot.useButtonDisabled = false;
        slot.gainButtonDisabled = false;
        slot.availableSlots = [];
        const usedSlots = slot.Count - slot.Available;
        for(var i = 0; i < usedSlots; i++) {
          slot.usedSlots.push({ class: 'used' });
        }
        for(var i = 0; i < slot.Available; i++) {
          slot.availableSlots.push({ class: 'available' });
        }
        return slot;
      });
    },
  },
  methods: {
    useSpellSlot(index) {
      this.spellSlots[index].useButtonDisabled = true;
      this.spellSlots[index].Available--;
      if(this.spellSlots[index].Available < 0) {
        this.spellSlots[index].Available = 0;
      }
      const payload = {
        characterId: this.characterId,
        body : {
          SpellSlots : this.spellSlots
        }
      };
      //await this.$store.dispatch('updateCharacter', payload);
    },
    gainSpellSlot(index) {
      this.spellSlots[index].Available++;
      if(this.spellSlots[index].Available > this.spellSlots[index].Count) {
        this.spellSlots[index].Available = this.spellSlots[index].Count;
      }
      const payload = {
        characterId: this.characterId,
        body : {
          SpellSlots : this.spellSlots
        }
      };
      //await this.$store.dispatch('updateCharacter', payload);
    }
  }
}
</script>

<style lang="scss" scoped>
@import "~styles/shared.scss";

.spell {
  float: right;
}

.spell-slot {
  display: flex;
  flex-direction: row;
  margin-bottom: 1%;  
}

.spell-slot-btn-container{
  display: flex;
  flex-direction: row;
}

.slot-level {
  display: flex;
  align-content: center;
  font-size: 1.5em;
}

.available {
  color: green;
}

.used {
  color: red;
}

.level {
  font-size: 1em;
}

.spell-slot-btn {
  margin-right: 1%;
}
</style>
