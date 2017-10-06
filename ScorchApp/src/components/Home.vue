<template>
  <div class="hello">
    <h1>{{ msg }}</h1>
    <character-panel :info="stuff"></character-panel>
  </div>
</template>

<script>
import CharacterPanel from './CharacterPanel.vue'

export default {
  name: 'hello',
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
h1, h2 {
  font-weight: normal;
}

ul {
  list-style-type: none;
  padding: 0;
}

li {
  display: inline-block;
  margin: 0 10px;
}

a {
  color: #42b983;
}
</style>
