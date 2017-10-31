<template>
    <div class="character-leveling">
    <div class="card">
        <div class="card-body">
        <div class="stats-leveling" v-for="(statValue, stat, index) in character.Stats" :key="index">
            <strong>{{ stat }}:</strong>
            <span class="stat">{{ statValue }}</span>
            <button class="btn btn-primary">+</button>
            <button class="btn btn-danger">-</button>            
        </div>
        </div>
    </div>
    </div>
</template>

<script>
export default {
    name: 'character-leveling',
    props: ['character']
}
</script>

<style lang="scss" scoped>
.stats-leveling {

}
</style>