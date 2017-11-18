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
    <spell-info :characterClass="characterClass" :level="character.Level"></spell-info>
    <div class="spell-list">
        <h5>Spells</h5>
        <spell-list :characterId="character.CharacterId" :spells="spells"></spell-list>
    </div>
    <button class="btn btn-primary" @click="showSpellSearcher">Add Spell</button>
</div>
</template>


<script>
import { Modal } from 'components/util'
import { mapActions } from 'vuex'
import SpellSearcher from './SpellSearcher'
import SpellDetailCard from './SpellDetailCard'
import SpellList from './SpellList'
import SpellInfo from './SpellInfo'

export default {
    name: 'spell-card',
    props: ['spells', 'character', 'characterClass'],
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
                this.$notify.failure('You are not high level enough for this spell');
                return;
            }
            if(this.selectedSpell.Classes.indexOf(this.character.Class) == -1) {
                this.$notify.failure("This spell can't be used by your class");
                return;
            }
            let payload = {
                characterId : this.character.CharacterId,
                body: this.selectedSpell
            };
            await this.addSpellToCharacter(payload);
            this.$notify.success(`Spell '${this.selectedSpell.Name}' added to your list.`)
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
        SpellList,
        SpellInfo
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
    flex-direction: column;
}

.spell-list {
    margin: 1% 0;

}

.fa-check-circle-o {
    color: green;
    font-size: 1.5em;
}

</style>