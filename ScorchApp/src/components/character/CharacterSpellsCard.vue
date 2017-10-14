<template>
    <div class="d-flex flex-column character-spell">
        <modal v-if="showSpellDescription" v-on:close="showSpellDescription = false">
            <h3 slot="header">
                {{ selectedSpell.Name }}
            </h3>
            <div slot="body">
                {{ selectedSpell.Description }}
            </div>
        </modal>
        <modal v-if="showSpellAddModal" v-on:close="showSpellAddModal = false">
            <h3 slot="header">
                Add New Spell
            </h3>
            <div slot="body">
                Spell
            </div>
        </modal>
        <div class="card spell-card">
            <div class="card-header">
            Spells
            </div>
            <div class="card-body text-center">
            <div v-for="(spell, index) in spells" 
                 @click="spellClick(spell)" 
                 :key="index" 
                 class="list-group-item list-group-item-action">
                <h6>{{ spell.Name }}</h6>
            </div>
            <button class="btn btn-primary" @click="showSpellAddModal = true">+</button>
            </div>
        </div>
    </div>
</template>

<script>
import { Modal } from 'components/util'

export default {
    name: 'character-spells',
    data() {
        return {
            showSpellDescription: false,
            showSpellAddModal: false,
            selectedSpell: {}
        }
    },
    props: ['spells'],
    methods: {
        spellClick: function(spell) {
            this.selectedSpell = spell;
            this.showSpellDescription = true;
        }
    },
    components: {
        Modal
    }
}
</script>

<style lang="scss" scoped>
.spell-card {
    flex: 1 0 auto;
}

</style>
