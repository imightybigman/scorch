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
    border: 1px solid black;
    box-sizing: border-box;
    margin: 1%;
  }
  .character-panel-container {
    margin: 0 auto;
    width: 50%;
    display: flex;
    align-items: center;
    flex-wrap: wrap;
  }
</style>
