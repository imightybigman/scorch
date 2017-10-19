<template>
    <div class="character-view d-flex flex-wrap" v-if="character">
        <div class="d-flex flex-column party-navigation border">
          <div class="character-cards-container" v-for="(char, index) in party" @click="goTo(char.CharacterId)" :key="index">
            <character-tile :character="char"></character-tile>
          </div>
        </div>
        <div class="d-flex flex-column character-info border">
          <div class="d-flex flex-column character-basic-info">
            <h4><strong>{{ name }}</strong></h4>
            <hp-bar :character="character"></hp-bar>
            <exp-bar :character="character"></exp-bar>
          </div>
          <div class="d-flex flex-row character-screen">
            <div class="d-flex flex-column character-stats-skills">
                <character-stats-card :stats="character.Stats" :proficiency="this.character.Proficiency"></character-stats-card>
                <character-skills-card :skills="character.Skills"></character-skills-card>          
            </div>
            <div class="d-flex character-equip justify-content-center">
              <character-equip :character="this.character"></character-equip>
            </div>
            <div class="d-flex character-spells">
              <character-spells-card :characterId="character.CharacterId" :spells="character.Spells"></character-spells-card>
            </div>
          </div>
          <div class="d-flex notes black-border">
          </div>    
        </div>
        <div class="d-flex flex-column character-inventory border">
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
            ExpBar,
            HpBar } from 'components/character'

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
      ExpBar,
      HpBar,
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
    flex: 3 0 auto;

    .character-screen {
      flex: 1 0 auto;

      >div {
        margin: 1%;
      }

      .character-stats-skills {
        flex: 1 0 auto;
        > div {
          margin-bottom: 1%;
        }
      }

      .character-equip {
        flex: 1 0 auto;
      }

      .character-spells {
        flex: 3 0 auto;
      }
    }
    .character-basic-info {
      flex: 1 0 auto;
      padding: 1% 1% 0 1%;
    }
    .notes {
      flex:auto;
      height: 200px;
    }
  }

  .character-inventory {
    flex: 1 0 auto;
  }


</style>
