<template>
<div class="character-bonus-features-card">
  <div class="card card-width">
    <div class="card-header" role="tab" id="character-features">
      <h5 class="mb-0">
        <a data-toggle="collapse" href="#features" aria-expanded="false" aria-controls="features">{{ displayName }}</a>
      </h5>
    </div>
    <div id="features" class="collapse show" role="tabpanel" aria-labelledby="character-features" data-parent="#character-details">
      <div class="card-body">
          {{ feature.Name }}
      </div>
    </div>
  </div>
  </div>
</template>

<script>
export default {
    name: 'bonus-features',
    props: ['feature', 'displayName']
}
</script>

<style lang="scss" scoped>
@import "~styles/shared.scss";

</style>