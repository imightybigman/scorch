<template>
    <div class="dm-main-component">
        <div class="d-flex flex-wrap dm-character-view" v-if="dataDone">
            <div class="d-flex flex-column dm-party-view">
                <div class="dm-character-cards-container" v-for="(char, index) in party" :key="index">
                    <character-tile :character="char"></character-tile>
                </div>
            </div>
            <div class="d-flex character-operations">
                <span>sup </span>
            </div>
        </div>
    </div>
    
</template>

<script>
  import { CharacterTile } from 'components/character'
  import { CharacterService } from 'services'
  import sortBy from 'lodash/sortBy'

export default {
    name : 'dm-main-component',
    
    data() {
      return {
        party: [],
        dataDone: false
      }
    },
    async created() {
      await this.$store.dispatch('getParty')
    },
    methods: {
      async loadData() {
        const characterSvc = new CharacterService();
        let myParty = await characterSvc.getCharacters();
        this.party = sortBy(myParty.body, (x) => x.Firstname);
        this.dataDone = true;
      }
    },
    computed: {
        party() {
            return this.$store.getters.myParty;
        }
    },
    components: {
      CharacterTile
    }
}
</script>

<style lang="scss" scoped>
    div {
        box-sizing: border-box;
    }
    
    .dm-main-component {
        margin: 1%;
        height: 600px;
    }
    .dm-party-view {
        margin: 1%;
        flex: 1;
        flex-grow: 2;
        .dm-character-cards-container {
            margin-bottom: 1%;
            border-radius: 10px;
            
        }
    }
    .character-operations {
        margin: 1%;
        flex: 1;
        flex-grow: 5;
    }
</style>