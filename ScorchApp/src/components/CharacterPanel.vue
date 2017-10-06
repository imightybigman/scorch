<template>
  <div class="character-panel card">
    <img class="card-img-top"  alt="Card image cap">
    <div class="card-block">
      <h4 class="card-title">Card title</h4>
      <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
      <a href="#" class="btn btn-primary">Go somewhere</a>
    </div>
  </div>
</template>

<script>
export default {
  name: 'character-panel',
  props: ['info']
  
}
</script>

<style scoped>
  .character-panel {

  }
</style>
