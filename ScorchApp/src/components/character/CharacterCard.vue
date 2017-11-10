<template>
<div class="character-card">
  <div class="card">
    <img class="card-img-top" src="~assets/blank-background.jpg" alt="Card image cap">
    <div class="card-body">
      <h4 class="card-title">{{ characterInfo.Firstname }}</h4>
      <p class="card-text">{{ description }}</p>
      <router-link class="btn btn-primary" :to="'/character/' + characterInfo.CharacterId">Select</router-link>
    </div>
  </div>
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
    },
    imageUrl() {
      let characterMap = [{"id" : "84674b34-b513-497f-8909-dc8d5dfffe86",  "url" : "evil-paladin.jpg"}];
      let myChar = find(characterMap, {"id" : this.characterInfo.CharacterId});
      if(myChar){
        console.log("~assets/" + myChar.url);
        return "~assets/" + myChar.url;
      }
      else
        return "~assets/blank-background.jpg";
    }
  }
}
</script>

<style lang="scss" scoped>
  .card{
    text-align:center;
  }

</style>
