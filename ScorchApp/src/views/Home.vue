<template>
  <div class="home container">
    <div class="home-message">
      <h1>{{ msg }}</h1>
    </div>
    <div class="character-panel-container">
      <div class="flex-test">
        <character-panel></character-panel>
      </div>
      <div class="flex-test">
        <character-panel></character-panel>        
      </div>
      <div class="flex-test">
        <character-panel></character-panel>        
      </div>
      <div class="flex-test">
        <character-panel></character-panel>        
      </div>
      <div class="flex-test">
        <character-panel></character-panel>        
      </div>
      <div class="flex-test">
        <character-panel></character-panel>        
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
      stuff: {
        moreStuff : 'asfasf'
      }
    }
  },
  beforeMount() {
    const characterSvc = new CharacterService();
        this.$http.get('https://dnd-api.imightybigman.com/api/character').then(response => {
            console.log(response);
        })  },
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
  .flex-test {
    width: 45%;
    box-sizing: border-box;
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
