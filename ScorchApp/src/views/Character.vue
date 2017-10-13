<template>
    <div class="character-view d-flex flex-wrap border" v-if="character">
        <div class="d-flex flex-column party-navigation">
          <div class="character-cards-container" v-for="(char, index) in party" @click="goTo(char.CharacterId)" :key="index">
            <character-tile :character="char"></character-tile>
          </div>
        </div>
        <div class="d-flex flex-column character-info border">
          <div class="d-flex flex-column character-basic-info">
            <h4><strong>{{ name }}</strong></h4>
            <exp-bar></exp-bar>
          </div>
          <div class="d-flex character-screen">
            <div class="d-flex flex-column character-stats-skills">
              <div>
                <character-stats-card :stats="profStats"></character-stats-card>
              </div>
              <div>
                <character-skills-card :skills="character.Skills"></character-skills-card>
              </div>
              
            </div>
            <div class="d-flex character-equip">
              <character-equip :character="character"></character-equip>
            </div>
          </div>
          <div class="d-flex notes black-border">

          </div>
          
        </div>
        <div class="d-flex flex-column character-abilities">
          
        </div>
      </div>
</template>

<script>

  import { SpellCard } from 'components/spells'
  import { Modal } from 'components/util'
  import { CharacterTile, CharacterEquip, CharacterStatsCard, CharacterDetailCard, CharacterSkillsCard, ExpBar } from 'components/character'
  import { CharacterService } from 'services'
  import find from 'lodash/find'

  export default {
    name: 'character-view',
    data() {
      return {
        showModal: false,
        dataDone: false
      }
    },
    created() {
      this.$store.dispatch('getParty')
    },
    props: ['characterId'],
    computed: {
      profStats() {
        let stats = this.character.Stats;
        stats.Proficiency = this.character.Proficiency;
        return stats;
      },
      name() {
          let firstName = this.character.Firstname || '';
          let lastName = this.character.Lastname || '';
          return `${firstName} ${lastName}`; 
      },
      party() {
        return this.$store.getters.myParty;
      },
      character() {
        return this.$store.getters.getCharacterById(this.characterId)
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
      ExpBar,
      SpellCard,
      CharacterEquip,
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
    //margin: 1%;
    //height: 750px;
  }

  .party-navigation {
    padding: 1%;
    flex: 1;
    flex-grow: 1;
    overflow-y: scroll;
    .character-cards-container {
      margin-bottom: 1%;
      border-radius: 10px;
    }
  }

  .character-info {
    flex: 1;
    flex-grow: 3;
    .character-screen {
      flex: 1;
      flex-grow: 5.5;

      >div {
        margin: 1%;
      }

      .character-stats-skills {
        flex: 1;
        flex-grow: 1;
        > div {
          margin-bottom: 1%;
        }
      }
      .character-equip {
        flex: 1;
        flex-grow: 3;
      }
    }
    .character-basic-info {
      padding: 1% 0 0 1%;
    }
    .notes {
      flex: 1;
      flex-grow: 2;
    }
  }

  .character-abilities {
    flex: 1;
    flex-grow: 1;
  }

</style>
