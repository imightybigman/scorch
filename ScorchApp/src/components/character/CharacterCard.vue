<template>
<div class="character-card">
  <router-link :to="'/character/' + characterInfo.CharacterId">
    <div class="card">
      <img v-if="characterInfo.Firstname === 'Dildo'" src="~assets/evil-paladin.jpg" alt="Card image cap" class="card-img-top">
      <img v-else-if="characterInfo.Firstname === 'Flavius'" src="~assets/tiefling-warlock.jpg" alt="Card image cap" class="card-img-top">
      <img v-else-if="characterInfo.Firstname === 'Grabnar'" src="~assets/fighter.jpg" alt="Card image cap" class="card-img-top">
      <img v-else-if="characterInfo.Firstname === 'Ramin'" src="~assets/lizard-bard.jpg" alt="Card image cap" class="card-img-top">
      <img v-else-if="characterInfo.Firstname === 'Samari'" src="~assets/ranger.png" alt="Card image cap" class="card-img-top">
      <img v-else class="card-img-top" src="~assets/blank-background.jpg" alt="Card image cap">
      <div class="card-body">
        <h4 class="card-title">{{ characterInfo.Firstname }}</h4>
        <p class="card-text">{{ description }}</p>
      </div>
    </div>
  </router-link>
</div>
</template>

<script>
  import find from 'lodash/find'

export default {
  name: 'character-card',
  props: ['characterInfo'],
  computed: {
    description() {
      return `Lvl: ${this.characterInfo.Level}, Race: ${this.characterInfo.Race}, Class: ${this.characterInfo.Class}`
    }
  }
}
</script>

<style lang="scss" scoped>
  .card{
    text-align:center;
    max-height: 100%;
  }
  a {
    color: red;
  }
  .card-img-top {
    max-width: 100%; 
  }
</style>
