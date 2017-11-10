<template>
  <div>
    <div class="home-logo-container">
      <router-link :to="'/'">
        <img class="home-logo" src="../assets/DnD_transparent.png">
      </router-link>
    </div>
    <div class="home container">
      <div class="home-message">
        <h1>{{ msg }}</h1>
      </div>
      <div class="character-card-container d-flex">
        <div class="card" v-for="(char, index) in characters" :key="index">
          <character-card :characterInfo="char"></character-card>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { CharacterCard } from 'components/character'

export default {
  name: 'home',
  data () {
    return {
      msg: 'Welcome to Scorch',
    }
  },
  created() {
      this.$store.dispatch('getParty')
  },
  computed: {
    characters () {
      return this.$store.getters.myParty;
    }
  },
  components : {
    CharacterCard
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
  .home-message {
    text-align: center;
  }
  .card {
    margin: 1%;
    flex:1;
    min-width: 45%;
    min-height: 10%;
    max-height: 100%;
  }
  .character-card-container {
    margin: 0 auto;
    display: flex;
    align-items: center;
    flex-wrap: wrap;
    width: 75%;
  }
</style>
