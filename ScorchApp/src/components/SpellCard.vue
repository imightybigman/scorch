<template>
  <div class="spell-detail">
  <div class="card">
    <img class="card-img-top" src="../assets/blank-background.jpg" alt="Card image cap">
    <div class="card-body">
      <h4 class="card-title">{{ spell.Name }}</h4>
      <p class="card-text">{{ spell.Description }}</p>
    </div>
</div>
  </div>
</template>

<script>
export default {
  name: 'spell-detail-card',
  props: ['spell']
}
</script>

<style lang="scss" scoped>


</style>
