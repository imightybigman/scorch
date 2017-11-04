<template>
<div class="character-bio-card">
  <div class="card card-width">
    <div class="card-header" role="tab" id="character-bios">
      <h5 class="mb-0">
        <a data-toggle="collapse" href="#bios" aria-expanded="false" aria-controls="bios">Bio</a>
      </h5>
    </div>
    <div id="bios" class="collapse" role="tabpanel" aria-labelledby="character-bios" data-parent="#character-details">
      <div class="card-body">
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
    </div>
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
