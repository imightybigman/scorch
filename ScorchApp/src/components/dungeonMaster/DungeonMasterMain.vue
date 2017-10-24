<template>
    <div class="dm-main-component">
        <div class="d-flex dm-character-view">
            <div class="flex-column dm-party-view">
                <div class="dm-character-cards-container" v-for="(char, index) in party" @click="toggleCharacter(char)" :key="index">
                    <character-tile :character="char" v-bind:class="{ selected: isCharacterSelected(char) }"></character-tile>
                </div>
            </div>
            <div class="rhs-character-ops">
                <div class="item-searcher flex-column">
                    <item-searcher @search-item-selected="searchItem" />
                </div>
                <div class="character-operations">
                    <character-operator :character-list="selectedChars"></character-operator>
                </div>
            </div>
        </div>
    </div>
    
</template>

<script>
    import { CharacterTile } from 'components/character'
    import CharacterOperator from './operators/CharacterOperator.vue'
    import { ItemSearcher } from 'components/inventory'

export default {
    name : 'dm-main-component',
    
    data() {
      return {
        selectedChars: [],
        selectedItem: {}
      }
    },
    async created() {
      await this.$store.dispatch('getParty')
    },
    methods: {
        toggleCharacter(character) {
            var foundChar = this.selectedChars.find(char => char.CharacterId == character.CharacterId); 
            
            if(foundChar){
                var index = this.selectedChars.findIndex(char => char.CharacterId == character.CharacterId);
                this.selectedChars.splice(index, 1);
            }
            else{
                this.selectedChars.push(character);
            }
        },
        isCharacterSelected(character) {
            return !(this.selectedChars.find(char => char.CharacterId == character.CharacterId) == undefined);
        },
        searchItem(item){
            console.log(item);
            this.selectedItem = item;
        }
    },
    computed: {
        party() {
            return this.$store.getters.myParty;
        }
    },
    components: {
        CharacterTile,
        CharacterOperator,
        ItemSearcher
    }
}
</script>

<style lang="scss" scoped>
    div {
        box-sizing: border-box;
    }
    
    .dm-main-component {
        height: 600px;
    }
    .dm-character-view {
        flex-wrap: wrap;
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
        border-radius: 10px;
    }
    .selected {
        background-color: black;
    }
    .item-searcher{
        flex: 1;
        flex-grow: 3;
    }
    .rhs-character-ops{
        flex: 2;
        flex-grow: 5;
        flex-direction:column;
    }
</style>