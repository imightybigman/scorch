<template>
<div class="spell-list">
    <modal v-if="showModal" v-on:close="close">
        <h3 slot="header">Spell Detail</h3>
        <spell-readonly slot="body" :spell="selectedSpell"></spell-readonly>
    </modal>
    <div v-for="(spells, index) in spellsGroupedByLevel" :key="index">
        <accordian :header="spells.level">
            <div slot="body">
                <div v-for="(spell, index) in spells.spells" 
                    @click="spellClick(spell, $event)" 
                    :key="index" 
                    class="list-group-item d-flex justify-content-between list-group-item-action">
                    <span v-if="spell.Name">{{ spell.Name }}</span>
                    <button @click="deleteSpell(spell, $event)" class="btn btn-danger delete-spell-btn">X</button>
                </div>
            </div>
        </accordian>
    </div>
</div>
</template>

<script>

import _ from 'lodash'
import SpellReadonly from './SpellReadonly'
import { Accordian, Modal } from 'components/util'
import { mapActions } from 'vuex'

export default {
    name: 'spell-list',
    props: ['characterId', 'spells'],
    data() {
        return {
            showModal: false,
            selectedSpell: undefined
        }
    },
    methods: {
        spellClick(spell, $event){
            $event.stopPropagation();
            this.selectedSpell = spell;
            this.showModal = true;
        },
        async deleteSpell(spell, $event) {
            $event.stopPropagation();
            let payload = {
                characterId: this.characterId,
                spellId: spell.SpellId
            }
            await this.deleteSpellFromCharacter(payload);
        },
        close() {
            $("body").removeClass("modal-open");
            this.showModal = false;
        },
        ...mapActions([
            'deleteSpellFromCharacter'
        ])
    },
    computed: {
        spellsGroupedByLevel() {
            let grouped = _.chain(this.spells)
                            .forEach((s) => {
                                s.LevelDisplay = `Level ${s.Level}`
                            })
                            .groupBy('LevelDisplay')
                            .toPairs()
                            .map((s) => { return _.zipObject(['level', 'spells'], s); 
                            })
                            .sortBy('level')
                            .value();
            return grouped;
        }
    },
    components: {
        Accordian,
        Modal,
        SpellReadonly
    }
}
</script>

<style lang="scss">

</style>