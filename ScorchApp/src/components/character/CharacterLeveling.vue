<template>
    <div class="character-leveling">
    <modal v-if="showLevelingModal" v-on:close="showLevelingModal = false">
        <div slot="header"><h3>Level: <i class="fa fa-level-up"></i> {{ nextLevel }}</h3></div>
        <div slot="body">
            <div class="card modify-stats">
                <div class="card-header">
                    Increase Hp
                </div>
                <div class="card-body">
                    <p class="hp-leveling">
                        <strong>{{ hpLevelText }}</strong>
                    </p>
                    <div>
                        <strong>{{ currentHp }}</strong>
                        ( <input class="hp-input" type="text" v-model="baseHitDice" :disabled="hpRolled"/> Or
                        <button class="btn btn-primary" @click="rollForHp" :disabled="hpRolled">Roll</button> )
                        <strong>+ {{this.constModifier}} (Constitution Modifier)</strong> =
                        <span>{{ newHp }}</span>
                    </div>
                </div>
            </div>
            <div class="card modify-stats" v-if="doStatIncrease">
                <div class="card-header">
                    Increase Stats
                </div>
                <div class="card-body">
                    <p><strong>Points Left: {{ statPointsAvailable }}</strong></p>
                    <div class="d-flex justify-content-between stats-leveling" v-if="doStatIncrease" v-for="(statValue, stat, index) in character.Stats" :key="index">
                        <div>
                            <strong>{{ stat }}:</strong>
                            <span class="stat">{{ statValue }}</span>
                        </div>
                        <div class="stats-leveling-buttons">
                            <button class="btn btn-danger" @click="decreaseStat(stat)" :disabled="statPointsAvailable == 2">-</button>                            
                            <button class="btn btn-primary" @click="increaseStat(stat)" :disabled="statPointsAvailable == 0">+</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div slot="footer">
            <button class="btn btn-primary" @click="levelUp">Level Up</button>
        </div>
    </modal>
    <div class="card">
      <div class="card-header">{{ levelingEnabled ? 'Level +1' : 'Need More Exp' }} </div>
      <div class="card-body">
        <button class="level-btn btn btn-warning" :class="{ pulse:levelingEnabled } ":disabled="!levelingEnabled" @click="showLevelingModal = true">Level Up</button>
      </div>
    </div>
    </div>
</template>

<script>
import { Modal } from 'components/util'
import { AbilityModifierService, LevelService } from 'services'

export default {
    name: 'character-leveling',
    props: ['character', 'characterClass'],
    data() {
        return {
            showLevelingModal: false,
            increaseHpBaseValue: 0,
            hpRolled: false, 
            statPointsAvailable: 2
        }
    },
    computed: {
        nextLevel() {
            return this.character.Level + 1;
        },
        doStatIncrease() {
            return this.characterClass.AbilityScoreImprovement.indexOf(this.nextLevel) !== -1;
        },
        hpLevelText() {
            let hitDice = this.characterClass.HitDice,
                hitDiceFlat = this.characterClass.HitDiceFlat
            return `${hitDice} OR ${hitDiceFlat} base`;
        },
        currentHp() {
            return `Hp: ${ this.character.MaxHp } +`
        },
        newHp() {
            return this.baseHitDice + this.constModifier + this.character.MaxHp;
        },
        constModifier() {
            return AbilityModifierService.getAbilityModifier(this.character.Stats.Constitution);
        },
        baseHitDice() {
            return this.increaseHpBaseValue || this.characterClass.HitDiceFlat;
        }, 
        levelingEnabled() {
            let expRange = LevelService.getExpRange(this.character.Level)
            return this.character.Exp > expRange.max;
        }
    },
    methods: {
        increaseStat(stat) {
            this.statPointsAvailable <= 0 ? 0 : this.statPointsAvailable--;
            this.character.Stats[stat]++;
        },
        decreaseStat(stat) {
            this.statPointsAvailable >= 2 ? 2 : this.statPointsAvailable++;
            this.character.Stats[stat]--;
        },
        rollForHp() {
            let hitDice = this.characterClass.HitDice;
            let diceValue = hitDice.split('d')[1];
            this.increaseHpBaseValue = Math.floor(Math.random() * diceValue) + 1;
            this.hpRolled = true;
        },
        async levelUp() {
            let payload = {
                characterId : this.character.CharacterId,
                body: {
                    MaxHp: this.newHp,
                    Level: this.nextLevel,
                    Stats: this.character.Stats
                }
            };
            await this.$store.dispatch('updateCharacter', payload);
            this.$socket.emit('updateParty');
            this.showLevelingModal = false;
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

.modify-stats {
    margin-bottom: 1%;
}

.hp-input {
    width: 5%;
    border-radius: 5px;
    padding-left: 1%;
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