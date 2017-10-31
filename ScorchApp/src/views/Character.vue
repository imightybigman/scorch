<template>
<div class="character-view d-flex flex-wrap" v-if="character">
  <modal v-if="showLevelingModal" v-on:close="showLevelingModal = false">
    <div slot="header"><h3>Level Up</h3></div>
    <div slot="body"><character-leveling :character="character"></character-leveling></div>
  </modal>
  <div class="d-flex flex-column party-navigation border">
    <div class="character-cards-container" v-for="(char, index) in party" @click="goTo(char.CharacterId)" :key="index">
      <character-tile :character="char"></character-tile>
    </div>
  </div>
  <div class="d-flex flex-column character-info border">
    <div class="d-flex flex-column character-basic-info">
      <h4>
        <strong>{{ name }}</strong>
        <small>Lv. {{ character.Level }}</small>
      </h4>
      <div class="gold-counter"><img class="gold" src="~assets/icons/gold.png"/> {{ character.Gold }} </div>
      <hp-bar :character="character"></hp-bar>
      <exp-bar :character="character" v-on:levelup="levelingEnabled = true"></exp-bar>
    </div>
    <div class="d-flex flex-row flex-wrap character-screen">
      <div class="d-flex flex-column character-details">
        <h4>Character Info</h4>
        <character-bio-card :character="character"></character-bio-card>
        <character-stats-card :stats="character.Stats" :proficiency="character.Proficiency"></character-stats-card>
        <character-skills-card :skills="character.Skills"></character-skills-card>
        <character-spells-card :characterId="character.CharacterId" :spells="character.Spells"></character-spells-card>
      </div>
      <div class="d-flex flex-column character-equip">
        <h4>Character Equip</h4>
        <character-equip :character="character"></character-equip>
      </div>

    </div>
    <div class="d-flex notes black-border">
    </div>
  </div>
  <div class="d-flex flex-column character-other border">
    <div class="card">
      <div class="card-header">Utilities</div>
      <div class="card-body">
        <button class="level-btn btn btn-warning" :disabled="!levelingEnabled" @click="showLevelingModal = true">Level Up</button>
      </div>
    </div>
    <dice-roller></dice-roller>
    <inventory :characterId="character.CharacterId"></inventory>
  </div>
</div>

</template>

<script>

  import {  CharacterTile, 
            CharacterEquip, 
            CharacterStatsCard, 
            CharacterDetailCard, 
            CharacterSkillsCard, 
            CharacterSpellsCard,
            CharacterBioCard,
            CharacterLeveling,
            ExpBar,
            HpBar } from 'components/character'

  import { Inventory } from 'components/inventory'
  import { DiceRoller, Modal } from 'components/util'
  export default {
    name: 'character-view',
    data() {
      return {
        levelingEnabled : false,
        showLevelingModal: false
      }
    },
    async created() {
      await this.$store.dispatch('getParty')
    },
    props: ['characterId'],
    computed: {
      name() {
          let firstName = this.character.Firstname || '';
          let lastName = this.character.Lastname || '';
          return `${firstName} ${lastName}`; 
      },
      party() {
        return this.$store.getters.myParty;
      },
      character() {
        return this.$store.getters.getCharacterById(this.characterId);
      }
    },
    methods: {
      goTo(characterId) {
        this.$router.push('/character/' + characterId)
      }
    },
    components: {
      CharacterTile,
      CharacterStatsCard,
      CharacterDetailCard,
      CharacterSkillsCard,
      CharacterSpellsCard,
      CharacterEquip,
      CharacterBioCard,
      CharacterLeveling,
      ExpBar,
      HpBar,
      Inventory,
      DiceRoller,
      Modal
    }
  }

</script>

<style lang="scss" scoped>
  .black-border {
    border: 1px solid black;
    box-sizing: border-box;
  }

  .character-view {
    width: 100%;
  }

  .party-navigation {
    padding: 1%;
    flex: 1 0 auto;
    overflow-y: scroll;
    
    .character-cards-container {
      margin-bottom: 1%;
      border-radius: 10px;
    }

  }

  .character-info {
    flex: 2 0 auto;

    .character-screen {
      flex: 1 0 auto;

      >div {
        margin: 1%;
      }

      .character-details {
        flex: 1 0 auto;
        > div {
          margin-bottom: 1%;
        }
      }

      .character-equip {
        flex: 1 0 auto;
      }

    }
    .character-basic-info {
      flex: 1 0 auto;
      padding: 1% 1% 0 1%;
    }
    .notes {
      flex: 1 0 auto;
      height: 200px;
    }
  }

  .character-other {
    flex: 2 0 auto;
  }

.gold {
  width: 2%;
  height: 2%;
}
.gold-counter {
  float: right;
}

.level-btn {
  color: white;
}
</style>
