<template>
<div class="character-card">
  <router-link :to="'/character/' + characterInfo.CharacterId">
    <div class="card">
      <img v-if="characterInfo.CharacterId === '84674b34-b513-497f-8909-dc8d5dfffe86'" src="~assets/evil-paladin.jpg" alt="Card image cap" class="card-img-top">
      <img v-else-if="characterInfo.CharacterId === 'b5250294-dddd-4d30-a37a-9ffb2d31a974'" src="~assets/tiefling-warlock.jpg" alt="Card image cap" class="card-img-top">
      <img v-else-if="characterInfo.CharacterId === 'b75cc207-8146-40f1-8d77-238b7cfe9247'" src="~assets/fighter.jpg" alt="Card image cap" class="card-img-top">
      <img v-else-if="characterInfo.CharacterId === '1ef65368-f69b-42aa-a6a7-4734cf95cffc'" src="~assets/lizard-bard.jpg" alt="Card image cap" class="card-img-top">
      <img v-else-if="characterInfo.CharacterId === '375c7b20-ee58-41d5-866a-6723076ce2d3'" src="~assets/ranger.png" alt="Card image cap" class="card-img-top">
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
