<template>
    <div class="character-leveling">
    <modal v-if="showLevelingModal" v-on:close="showLevelingModal = false">
        <div slot="header"><h3>Level: <i class="fa fa-level-up"></i> {{ nextLevel }}</h3></div>
        <div slot="body">
            <div class="card">
            <div class="card-body">
                <div class="d-flex justify-content-between stats-leveling" v-for="(statValue, stat, index) in character.Stats" :key="index">
                    <div>
                        <strong>{{ stat }}:</strong>
                        <span class="stat">{{ statValue }}</span>
                    </div>
                    <div class="stats-leveling-buttons">
                        <button class="btn btn-primary" @click="increaseStat(stat)">+</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </modal>
    <div class="card">
      <div class="card-header">Leveling</div>
      <div class="card-body">
        <button class="level-btn btn btn-warning"  :class="{ pulse:levelingEnabled } ":disabled="!levelingEnabled" @click="showLevelingModal = true">Level Up</button>
      </div>
    </div>
    </div>
</template>

<script>
import { Modal } from 'components/util'
export default {
    name: 'character-leveling',
    props: ['character'],
    data() {
        return {
            showLevelingModal: false,
            levelingEnabled: true
        }
    },
    computed: {
        nextLevel: function() {
            return this.character.Level + 1;
        }
    },
    methods: {
        increaseStats: function(stat) {

        }
    },
    components: {
        Modal
    }
}
</script>

<style lang="scss" scoped>
.stats-leveling {
    width: 50%;
    margin-bottom: 1%;
    .stats-leveling-buttons {
        float: right;
    }
}

.pulse {
  display: block;
  cursor: pointer;
  box-shadow: 0 0 0 #cca92c;
  animation: pulse 1s infinite;
}
.pulse:hover {
  animation: none;
}

@-webkit-keyframes pulse {
  0% {
    -webkit-box-shadow: 0 0 0 0 rgba(204,169,44, 0.4);
  }
  70% {
      -webkit-box-shadow: 0 0 0 10px rgba(204,169,44, 0);
  }
  100% {
      -webkit-box-shadow: 0 0 0 0 rgba(204,169,44, 0);
  }
}
@keyframes pulse {
  0% {
    -moz-box-shadow: 0 0 0 0 rgba(204,169,44, 0.4);
    box-shadow: 0 0 0 0 rgba(204,169,44, 0.4);
  }
  70% {
      -moz-box-shadow: 0 0 0 10px rgba(204,169,44, 0);
      box-shadow: 0 0 0 10px rgba(204,169,44, 0);
  }
  100% {
      -moz-box-shadow: 0 0 0 0 rgba(204,169,44, 0);
      box-shadow: 0 0 0 0 rgba(204,169,44, 0);
  }
}
</style>