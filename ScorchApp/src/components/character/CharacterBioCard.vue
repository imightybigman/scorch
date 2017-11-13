<template>
<div class="character-bio-card">
    <div>
      <strong>Race:</strong>
      <span class="bio">{{ character.Race }}</span>
    </div>
    <div>
      <strong>Class:</strong>
      <span class="bio">{{ character.Class }}</span>
    </div>
    <div>
      <strong>Sex:</strong>
      <span class="bio">{{ character.Sex }}</span>
    </div>
    <div>
      <strong>Age:</strong>
      <span class="bio">{{ character.Age }}</span>
    </div>
    <div>
      <strong>Race:</strong>
      <span class="bio">{{ character.Race }}</span>
    </div>
    <div>
      <strong>Align:</strong>
      <span class="bio">{{ character.Align }}</span>
    </div>
    <div>
      <strong>Gold:</strong>
      <span class="bio">{{ character.Gold }}g</span>
    </div>
</div>
</template>

<script>
import { AbilityModifierService } from 'services'

export default {
  name: 'character-bio-card',
  props: ['character'], 
  computed: {

  },
  methods: {

  }
}
</script>

<style lang="scss" scoped>
@import "~styles/shared.scss";

.bio {
  float: right;
}
</style>
