<template>
  <div class="character-companion-card">
    <modal v-if="showDetailModal" v-on:close="showDetailModal = false">
      <div slot="header">
        <h4>Attack Details</h4>
      </div>
      <div slot="body">
        <h2>{{ selectedAttack.Name }}</h2>
        <p>{{ selectedAttack.Description }}</p>
      </div>
    </modal>
    <div class="card card-width">
      <div class="card-header" role="tab" id="character-companion">
        <h5 class="mb-0">
          <a data-toggle="collapse" href="#companion" aria-expanded="false" aria-controls="companion">Companion</a>
        </h5>
      </div>
      <div id="companion" class="collapse show" role="tabpanel" aria-labelledby="character-companion" data-parent="#character-details">
        <div class="card-body">
          <div>
            <strong>Hp:</strong>
            <span class="stat">{{ companion.Hp }}</span>
          </div>
          <div>
            <strong>AC:</strong>
            <span class="stat">{{ companion.AC }}</span>
          </div>
          <div>
            <strong>Type</strong>
            <span class="stat">{{ companion.Type }}</span>
          </div>
          <div>
            <strong>Attacks</strong>
            <div v-for="(attack, index) in companion.Attacks" :key="index" @click="attackClick(attack)" class="attack-item border">
              <p>{{ attack.Name }}</p>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  import {
    Modal
  } from 'components/util'
  export default {
    name: 'character-stat-card',
    props: ['companion'],
    data() {
      return {
        selectedAttack: {},
        showDetailModal: false
      }
    },
    methods: {
      attackClick(attack) {
        this.selectedAttack = attack;
        this.showDetailModal = true;
      }
    },
    components: {
      Modal
    }
  }

</script>

<style lang="scss" scoped>
  @import "~styles/shared.scss";

  .stat {
    float: right;
  }

  .attack-item {
    padding: 3% 3% 0 3%;
    border-radius: 10px;
    margin-bottom: 1%;
  }

  .attack-item:hover {
    cursor: pointer;
  }

</style>
