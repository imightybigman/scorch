<template>
  <div class="home container">
    <div class="home-message">
      <h1>{{ msg }}</h1>
    </div>
    <div class="character-panel-container">
      <div class="panel" v-for="(char, index) in characters" :key="index">
        <character-panel :characterInfo="char"></character-panel>
      </div>
    </div>
  </div>
</template>

<script>
import CharacterPanel from '@/components/CharacterPanel.vue'
import CharacterService from '../services/CharacterService'

export default {
  name: 'home',
  data () {
    return {
      msg: 'Welcome to Your DnD App',
      characters: []
    }
  },
  async beforeMount() {
    const characterSvc = new CharacterService();
    let response = await characterSvc.getCharacters();
    console.log(response);
    this.characters = response.body;
  },
  components : {
    CharacterPanel
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
  .home-message {
    text-align: center;
  }
  .panel {
    width: 45%;
    margin: 1%;
  }
  .character-panel-container {
    margin: 0 auto;
    width: 70%;
    display: flex;
    align-items: center;
    flex-wrap: wrap;
  }
</style>
