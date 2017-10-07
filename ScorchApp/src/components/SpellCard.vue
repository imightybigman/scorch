<template>
  <div class="spell-detail" v-on:click="toggleShow">
  <div class="card" v-if="!show">
    <div class="card-body">
      <h4 class="card-title">{{ spell.Name }}</h4>
    </div>
  </div>
    <div class="card" v-else>
      <div class="card-body" >
      <h4 class="card-title">{{ spell.Name }}</h4>
      <p class="card-text">{{ Description }}</p>
      <p class="card-text">{{ CastTime }}</p>
      <p class="card-text">{{ Damage }}</p>
      <p class="card-text">{{ Duration }}</p>
      <p class="card-text">{{ Range }}</p>
      <p class="card-text">{{ SpellType  }}</p>
    </div>
</div>
  </div>
</template>

<script>
export default {
  name: 'spell-detail-card',
  props: ['spell'],
  data() {
    return {
      show: false
    }
  },
  computed: {
    Description() {
      return `Description: ${this.spell.Description}`;
    }, 
    CastTime() {
      return `CastTime: ${this.spell.CastTime}`;
    },
    Damage() {
      return `Damage: ${this.spell.Damage}`;
    },
    Duration() {
      return `Duration: ${this.spell.Duration}`;
    },
    Range() {
      return `Range: ${this.spell.Range}`;
    },
    SpellType() {
      return `SpellType: ${this.spell.SpellType}`;
    }   
  },
  methods :{
    toggleShow: function(event) {
      this.show = !this.show;
    }
  }
}
</script>

<style lang="scss" scoped>


</style>
