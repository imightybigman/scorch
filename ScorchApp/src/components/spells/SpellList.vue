<template>
<div class="spell-list">
    <div v-for="(spells, index) in spellsGroupedByLevel" :key="index">
        <accordian :header="spells.level">
            <div slot="body">
                <div v-for="(spell, index) in spells.spells" @click="spellClick(spell)" :key="index" class="list-group-item list-group-item-action">
                    <small v-if="spell.Name">{{ spell.Name }}</small>
                </div>
            </div>
        </accordian>
    </div>
</div>
</template>

<script>

import _ from 'lodash'
import { Accordian } from 'components/util'
export default {
    name: 'spell-list',
    props: ['spells'],
    methods: {
        spellClick(spell){
            console.log(spell)
        }
    },
    computed: {
        spellsGroupedByLevel() {
            let grouped = _.chain(this.spells)
                            .forEach((s) => {
                                s.Level = `Level ${s.Level}`
                            })
                            .groupBy('Level')
                            .toPairs()
                            .map((s) => { return _.zipObject(['level', 'spells'], s); 
                            })
                            .sortBy('level')
                            .value();
            console.log(grouped)
            return grouped;
        }
    },
    components: {
        Accordian
    }
}
</script>

<style lang="scss">

</style>