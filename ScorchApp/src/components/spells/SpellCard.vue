<template>
<div class="spell-card">
    <modal v-if="showModal" v-on:close="close">
        <h4 slot="header">Spells</h4>
        <div slot="body" class="spell-select-container">
            <spell-searcher v-on:spell-clicked="showSpellDetail"></spell-searcher>
            <div v-if="selectedSpell">
                <spell-detail-card :spell="selectedSpell"></spell-detail-card>
                <button  class="add-spell-btn btn btn-primary" @click="addSpell">Add Spell</button>
                <i v-if="successfulAdd" class="fa fa-check-circle-o"></i>

            </div>
        </div>
    </modal>
    
    <button @click="showSpellSearcher">Search Spell Glossary</button>
    <spell-list :spells="spells"></spell-list>
</div>
</template>


<script>
import { Modal } from 'components/util'
import { mapActions } from 'vuex'
import SpellSearcher from './SpellSearcher'
import SpellDetailCard from './SpellDetailCard'
import SpellList from './SpellList'

export default {
    name: 'spell-card',
    props: ['spells', 'character'],
    data() {
        return {
            showModal: false,
            selectedSpell: undefined,
            successfulAdd: false
        }
    },
    methods: {
        close() {
            $("body").removeClass("modal-open");
            this.showModal = false;
            this.successfulAdd = false;
        },
        async showSpellSearcher(){
            await this.$store.dispatch('getSpells');
            this.showModal = true;
        },
        showSpellDetail(spell) {
            this.selectedSpell = spell;
            this.successfulAdd = false;            
        },
        async addSpell() {
            if(!this.selectedSpell){
                return;
            }
            if(!(this.character.Level >= this.selectedSpell.Level)){
                alert('You are not high level enough for this spell');
                return;
            }
            if(this.selectedSpell.Classes.indexOf(this.character.Class) == -1) {
                alert('This spell cant be used by your class');
                return;
            }
            let payload = {
                characterId : this.character.CharacterId,
                body: this.selectedSpell
            };
            await this.addSpellToCharacter(payload);
            this.successfulAdd = true;
        },
        ...mapActions([
            'addSpellToCharacter'
        ])
    },
    components: {
        Modal,
        SpellSearcher,
        SpellDetailCard,
        SpellList
    }
}
</script>

<style lang="scss" scoped>
.spell-card {
    display: flex;
    flex: 1 0;
    width: 95%;
    margin: 0 auto;
    padding: 3%;
}

.fa-check-circle-o {
    color: green;
    font-size: 1.5em;
}
</style>