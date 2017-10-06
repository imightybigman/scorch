<template>
  <div class="home">
    <h1>{{ msg }}</h1>
    <character-panel :info="stuff"></character-panel>
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

</style>
