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
        <stats-card :stats="character.Stats"></stats-card>
      </div>

      <div class="spell-card-container card">
        <h4>Spells</h4>
        <spell-card v-for="(spell, index) in character.Spells" :spell="spell" :key="index"></spell-card>
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
  import StatsCard from '@/components/StatsCard.vue'
  import CharacterDetailCard from '@/components/CharacterDetailCard.vue'
  import SpellCard from '@/components/SpellCard.vue'
  import MaleCharacterEquipment from '@/components/MaleCharacterEquipment.vue'
  import FemaleCharacterEquipment from '@/components/FemaleCharacterEquipment.vue'
  import Modal from '@/components/Modal.vue'
  import CharacterService from '../services/CharacterService'

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
      StatsCard,
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
    width: 15%;
  }

  .character-equipment {
    width: 25%;
  }

  .modal-component-container {
    width: 50%;
  }

</style>
