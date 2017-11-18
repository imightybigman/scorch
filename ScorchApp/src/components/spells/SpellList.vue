<template>
<div class="spell-list">
    <modal v-if="showModal" v-on:close="close">
        <h3 slot="header">Spell Detail</h3>
        <spell-readonly slot="body" :spell="selectedSpell"></spell-readonly>
    </modal>
    <p>
        <button class="btn btn-primary" @click="groupByLevel = !groupByLevel">{{ spellGroupDisplay }}</button>
    </p>
    <div v-for="(spells, index) in groupedSpells" :key="index">
        <accordian :header="spells.title">
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
            selectedSpell: undefined, 
            groupByLevel: true
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
            this.$notify.success(`Spell '${spell.Name} deleted.'`)
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
        spellGroupDisplay() {
            return this.groupByLevel ? 'Group by School' : 'Group by Level';
        },
        groupedSpells() {
            return this.groupByLevel ? this.spellsGroupedByLevel : this.spellsGroupedBySchool;
        },
        spellsGroupedByLevel() {
            let grouped = _.chain(this.spells)
                            .forEach((s) => {
                                s.LevelDisplay = `Level ${s.Level}`
                            })
                            .groupBy('LevelDisplay')
                            .toPairs()
                            .map((s) => { return _.zipObject(['title', 'spells'], s); 
                            })
                            .sortBy('title', 'asc')
                            .value();
            console.log(grouped)
            return grouped;
        },
        spellsGroupedBySchool() {
            let grouped = _.chain(this.spells)
                            .groupBy('School')
                            .toPairs()
                            .map((s) => { return _.zipObject(['title', 'spells'], s); 
                            })
                            .sortBy('title')
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