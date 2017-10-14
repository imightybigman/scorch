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

          </div>
          <div class="d-flex character-screen">
            <div class="d-flex flex-column character-stats-skills">
                <character-stats-card :stats="character.Stats" :proficiency="this.character.Proficiency"></character-stats-card>
                <character-skills-card :skills="character.Skills"></character-skills-card>          
            </div>
            <div class="d-flex character-equip justify-content-center">
              <character-equip :character="character"></character-equip>
            </div>
            <div class="d-flex character-spells">
              <character-spells-card :characterId="character.CharacterId" :spells="character.Spells"></character-spells-card>
            </div>
          </div>
          <div class="d-flex notes black-border">
          </div>    
        </div>
        <div class="d-flex flex-column character-inventory">
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
            CharacterSpellsCard } from 'components/character'

  import { Inventory } from 'components/inventory'

  export default {
    name: 'character-view',

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
      CharacterSpellsCard,
      CharacterEquip,
      Inventory
    }
  }

</script>

<style lang="scss" scoped>
  .black-border {
    border: 1px solid black;
    box-sizing: border-box;
  }

  .character-view {
    flex: 1 0 auto;
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
      flex: 1 0 auto;
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
        flex-grow: 2;
      }

      .character-spells {
        flex: 1;
        flex-grow: 1;
      }
    }
    .character-basic-info {
      padding: 1% 0 0 1%;
    }
    .notes {
      flex: 1 0 auto;
      height: 200px;
    }
  }

  .character-inventory {
    flex: 1;
    flex-grow: 1;
  }


</style>
