<template>
<div class="character-companion-card">
  <modal v-if="showDetailModal" v-on:close="close">
    <div slot="header">
      <h4>Attack Details</h4>
    </div>
    <div slot="body">
      <h2>{{ selectedAttack.Name }}</h2>
      <p>{{ selectedAttack.Description }}</p>
    </div>
  </modal>
  <div class="companion-content">
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
      },
      close() {
          $("body").removeClass("modal-open");
          this.showDetailModal = false;
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
