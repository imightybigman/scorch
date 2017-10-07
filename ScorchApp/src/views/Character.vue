<template>
    <div class="character-view" v-if="dataDone">
        <div class="character-detail-container">
            <character-detail-card :characterInfo="character"></character-detail-card>
        </div>
        <div class="stats-card-container">
            <stats-card :stats="character.Stats"></stats-card>
        </div>

        <div class="spell-card-container card">
            <h4>Spells</h4>
            <spell-card v-for="(spell, index) in character.Spells" :spell="spell" :key="index"></spell-card>
        </div>
    </div>
</template>

<script>
import StatsCard from '@/components/StatsCard.vue'
import CharacterDetailCard from '@/components/CharacterDetailCard.vue'
import SpellCard from '@/components/SpellCard.vue'

import CharacterService from '../services/CharacterService'

export default {
    name: 'character-view',
    data() {
        return {
            character: {},
            dataDone: false
        }
    },
    props: ['characterId'],
    async beforeMount() {
        const characterSvc = new CharacterService();
        let response = await characterSvc.getCharacterById(this.characterId);
        this.character = response.body;

        this.dataDone = true;
    },
    components : {
        StatsCard, CharacterDetailCard, SpellCard
    }
}
</script>

<style lang="scss" scoped>
.character-view {
    border: 1px solid black;
    box-sizing: border-box;

    div {
        margin: 1%;
    }
}
.character-detail-container {
    width: 15%;
}
.stats-card-container {
    width: 15%;
}

.spell-card-container {
    width: 15%;
}
</style>