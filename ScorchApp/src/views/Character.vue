<template>
  <div>
    <modal v-if="showModal" @close="showModal = false">
      <h2 slot="header">FUck</h2>
      <stats-card slot="body" :stats="character.Stats"></stats-card>
    </modal>
    <div class="character-view" v-if="dataDone">

      <div class="character-detail-container">
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
      </div>
    </div>
  </div>

</template>

<script>

  import { SpellCard } from 'components/spells'
  import { MaleCharacterEquipment, FemaleCharacterEquipment } from 'components/equipment'
  import { Modal } from 'components/util'
  import { CharacterStatsCard, CharacterDetailCard } from 'components/character'
  import { CharacterService } from 'services'

  export default {
    name: 'character-view',
    data() {
      return {
        character: {},
        showModal: false,
        dataDone: false
      }
    },
    props: ['characterId'],
    async beforeMount() {
      const characterSvc = new CharacterService();
      let response = await characterSvc.getCharacterById(this.characterId);
      this.character = response.body;
      this.dataDone = true;
    },
    methods: {},
    components: {
      CharacterStatsCard,
      CharacterDetailCard,
      SpellCard,
      MaleCharacterEquipment,
      FemaleCharacterEquipment,
      Modal
    }
  }

</script>

<style lang="scss" scoped>
  .character-view {
    border: 1px solid black;
    box-sizing: border-box;
    div {
        margin: 1%;
    }
  }

  .character-detail-container {
    width: 15%;
  }

  .stats-card-container {
    width: 15%;
  }

  .spell-card-container {
    width: 25%;
  }

  .character-equipment {
    width: 25%;
  }

  .modal-component-container {
    width: 50%;
  }

</style>
