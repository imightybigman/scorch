<template>
    <div class="character-view d-flex flex-wrap" v-if="dataDone">
        <div class="d-flex flex-column party-navigation">
          <div class="character-cards-container" v-for="(char, index) in party" :key="index">
            <character-tile :character="char"></character-tile>
          </div>
        </div>
        <div class="d-flex flex-column character-info">
          <div class="d-flex character-equip">
            <character-equip :character="character"></character-equip>
          </div>
          <div class="d-flex notes"></div>
          
        </div>
        <div class="d-flex flex-column character-abilities">
          
        </div>
      </div>
      <!-- <div class="character-detail-container">
        <character-detail-card :characterInfo="character"></character-detail-card>
      </div>

      <div class="stats-card-container">
        <character-stats-card :stats="character.Stats"></character-stats-card>
      </div>

      <div class="spell-card-container">
        <spell-card :spells="character.Spells"></spell-card>
      </div>

      <div class="character-equipment">
        <female-character-equipment></female-character-equipment>
      </div>
      <div class="character-equipment">
        <male-character-equipment></male-character-equipment>
      </div> -->
</template>


<script>

  import { SpellCard } from 'components/spells'
  import { Modal } from 'components/util'
  import { CharacterTile, CharacterEquip, CharacterStatsCard, CharacterDetailCard } from 'components/character'
  import { CharacterService } from 'services'
  import sortBy from 'lodash/sortBy'

  export default {
    name: 'character-view',
    data() {
      return {
        character: {},
        party: [],
        showModal: false,
        dataDone: false
      }
    },
    async beforeRouteUpdate (to, from, next) {
      await this.loadData(to.params.characterId);
      next();
    },
    props: ['characterId'],
    async beforeMount() {
      await this.loadData(this.characterId);
    },
    methods: {
      async loadData(characterId) {
        const characterSvc = new CharacterService();
        let myCharacter = await characterSvc.getCharacterById(characterId);
        let myParty = await characterSvc.getCharacters();
        this.character = myCharacter.body;
        this.party = sortBy(myParty.body, (x) => x.Firstname);
        this.dataDone = true;
      }
    },
    components: {
      CharacterTile,
      CharacterStatsCard,
      CharacterDetailCard,
      SpellCard,
      CharacterEquip,
      Modal
    }
  }

</script>

<style lang="scss" scoped>
  div {
    box-sizing: border-box;
  }

  .character-view {
    margin: 1%;
    height: 750px;
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
  }

  .character-abilities {
    flex: 1;
    flex-grow: 1;
  }

  .character-equip {
    flex: 1;
    flex-grow: 5;
  }
  .notes {
    flex: 1;
    flex-grow: 2;
  }

</style>
