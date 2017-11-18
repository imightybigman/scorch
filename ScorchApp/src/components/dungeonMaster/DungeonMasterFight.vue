<template>
    <div class="dm-fight-component">
        <div class="d-flex dm-character-view">
            <div class="flex-column dm-party-view">
                <div class="dm-character-cards-container" v-for="(char, index) in party" @click="toggleCharacter(char)" :key="index">
                    <character-tile :character="char" v-bind:class="{ selected: isCharacterSelected(char) }"></character-tile>
                </div>
            </div>
            <div class="dm-fight-view">
                <div class="d-flex bottom-bar">
                    <div class="character-operations">
                        <fight-operator :character-list="selectedChars"></fight-operator>
                    </div>
                </div>
            </div>
            <div class="d-flex dm-initiative-view">
                <div class="flex-column">
                    <div class="initiative">
                      <h3>
                          Initiative
                      </h3>
                        <div v-for="user in party">
                            <ul>0 : {{user.Firstname}} {{user.Lastname}}</ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</template>

<script>
    import { CharacterTile } from 'components/character'
    import CharacterOperator from './operators/CharacterOperator.vue'
    import FightOperator from './operators/FightOperator'

export default {
    name : 'dm-fight-component',
    data() {
        return {
            selectedChars: [],
        }
    },
    async created() {
      await this.$store.dispatch('getParty');
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
        FightOperator,
        CharacterOperator
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
    .dm-initiative-view {
        flex: 2;
    }
    .dm-fight-view {
      flex: 3;
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
    .bottom-bar{
        flex-direction:row;
    }
    .item-card{
        flex: 1;
    }
    .item-card-inner{
        min-height: 75%;
    }
</style>
