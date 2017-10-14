<template>
    <div class="dm-main-component">
        <div class="d-flex flex-wrap dm-character-view">
            <div class="d-flex flex-column dm-party-view">
                <div class="dm-character-cards-container" v-for="(char, index) in party" @click="toggleCharacter(char)" :key="index">
                    <character-tile :character="char" v-bind:class="{ selected: isCharacterSelected(char) }"></character-tile>
                </div>
            </div>
            <div class="d-flex character-operations">
                <character-operator :character-list="selectedChars"></character-operator>
            </div>
        </div>
    </div>
    
</template>

<script>
    import { CharacterTile } from 'components/character'
    import CharacterOperator from './CharacterOperator.vue'

export default {
    name : 'dm-main-component',
    
    data() {
      return {
        selectedChars: []
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
        }
    },
    computed: {
        party() {
            return this.$store.getters.myParty;
        }
    },
    components: {
        CharacterTile,
        CharacterOperator
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
        border-radius: 10px;
    }
    .selected {
        background-color: black;
    }
</style>