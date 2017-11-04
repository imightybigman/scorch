<template>
    <div class="dm-main-component">
        <div class="d-flex dm-character-view">
            <div class="flex-column dm-party-view">
                <div class="dm-character-cards-container" v-for="(char, index) in party" @click="toggleCharacter(char)" :key="index">
                    <character-tile :character="char" v-bind:class="{ selected: isCharacterSelected(char) }"></character-tile>
                </div>
            </div>
            <div class="rhs-character-ops">
                <div class="d-flex bottom-bar">
                    <div class="character-operations">
                        <character-operator :character-list="selectedChars" :item="selectedItem"></character-operator>
                    </div>
                    <div class ="item-card border" >
                        <item-card :item="selectedItem"></item-card>
                    </div>
                </div>
                <div class="item-searcher flex-column">
                    <searcher @search-row-selected="searchItem" :search-data="searchItems" :limit-per-page="10" :column-keys="columnKeys"/>
                </div>
            </div>
        </div>
    </div>

</template>

<script>
    import { CharacterTile } from 'components/character'
    import CharacterOperator from './operators/CharacterOperator.vue'
    import { Searcher } from 'components/util'
    import { ItemCard } from 'components/items'
    import { ItemService } from 'services'

export default {
    name : 'dm-main-component',

    data() {
        return {
            selectedChars: [],
            selectedItem: {},
            columnKeys: ['Name', 'ItemClass', 'Cost', 'AC', 'Damage', 'Slot']
        }
    },
    async created() {
      await this.$store.dispatch('getParty');
      await this.$store.dispatch('getDisplayItems');
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
        async searchItem(item){
            if(item){
                let response = {};
                response = await ItemService.getItemById(item.ItemId);
                this.selectedItem = response.body;
            }
        }
    },
    computed: {
        party() {
            return this.$store.getters.myParty;
        },
        searchItems() {
            return this.$store.getters.items;
        }
    },
    components: {
        CharacterTile,
        CharacterOperator,
        Searcher,
        ItemCard
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
    .bottom-bar{
        flex-direction:row;
    }
    .item-card{
        flex: 1;
        min-height: 75%;
    }
</style>
