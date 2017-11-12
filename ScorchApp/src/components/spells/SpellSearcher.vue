<template>
<div class="spell-searcher">
    <searcher :search-data="getSpells" :limit-per-page="8" :column-keys="columns" v-on:search-row-selected="spellSelected"></searcher>
</div>
</template>

<script>
import { Searcher } from 'components/util'

import { mapGetters, mapActions } from 'vuex'

export default {
    name: 'spell-searcher',
    data() {
        return {
            columns: ['Level', 'Name', 'Classes', 'DamageType']
        }
    },
    methods: {
        async spellSelected(spell) {
            await this.loadSpellDetails(spell.SpellId);
            spell = this.getSpell(spell.SpellId);
            this.$emit('spell-clicked', spell);
        },
        ...mapActions([
            'loadSpellDetails'
        ])
    },
    computed: {
        ...mapGetters([
            'getSpells',
            'getSpell'
        ]),

    },
    components: {
        Searcher
    }
}
</script>