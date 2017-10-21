<template>
    <div class="form spell-form">
        <div class="form-group">
            <label for="spellName">Spell Name</label>
            <input type="text" id="spellName" readonly class="form-control" v-model="spell.Name" placeholder="Spell Name" />
        </div>
        <div class="form-group">
            <label for="spellDesc">Spell Description</label>
            <textarea type="text" id="spellDesc" readonly class="form-control" v-model="spell.Description" placeholder="Spell Description" rows="8" />
        </div>
        <div class="form-group">
            <label for="spellDamage">Spell Damage</label>
            <input type="text" id="spellDamage" readonly class="form-control" v-model="spell.Damage" placeholder="e.g. 1d8" />
        </div>
        <div class="form-group">
            <label for="spellType">Damage Type</label>
            <input type="text" id="spellType" readonly class="form-control" v-model="spell.DamageType" placeholder="e.g. Force" />
        </div>
        <div class="form-group">
            <label for="spellDuration">Spell Duration</label>
            <input type="text" id="spellDuration" readonly class="form-control" v-model="spell.Duration" placeholder="e.g. 1 Hour" />
        </div>
        <div class="form-group">
            <label for="range">Range</label>
            <input type="text" id="range" readonly class="form-control" v-model="spell.Range" placeholder="e.g. 120 ft" />
        </div>
    </div>
</template>

<script>
export default {
    name: 'spell-form',
    props: ['spell']
}
</script>

<style lang="scss" scoped>
.spell-form {
    max-height: 400px;
    overflow-y: scroll;
}
</style>