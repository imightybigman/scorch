<template>
    <div>
        <div class="form-group">
            <label for="spellName">Spell Name</label>
            <input type="text" id="spellName" class="form-control" v-model="name" placeholder="Spell Name" />
        </div>
        <div class="form-group">
            <label for="spellDesc">Spell Description</label>
            <textarea type="text" id="spellDesc" class="form-control" v-model="description" placeholder="Spell Description" rows="8" />
        </div>
        <div class="form-group">
            <label for="spellDamage">Spell Damage</label>
            <input type="text" id="spellDamage" class="form-control" v-model="damage" placeholder="e.g. 1d8" />
        </div>
        <div class="form-group">
            <label for="spellDuration">Spell Duration</label>
            <input type="text" id="spellDuration" class="form-control" v-model="duration" placeholder="e.g. 1 Hour" />
        </div>
        <div class="form-group">
            <label for="spellType">Spell Type</label>
            <input type="text" id="spellType" class="form-control" v-model="spellType" placeholder="e.g. Force" />
        </div>
        <div class="form-group">
            <label for="range">Range</label>
            <input type="text" id="range" class="form-control" v-model="range" placeholder="e.g. 120 ft" />
        </div>
        <div class="form-group text-center">
            <button class="btn btn-primary" @click="submitSpell">Submit</button>
        </div>
    </div>
</template>

<script>
export default {
    name: 'spell-form',

    data() {
        return  {
            name: undefined,
            description: undefined,
            damage: undefined,
            duration: undefined,
            spellType: undefined,
            range: undefined
        }
    },
    methods: {
        submitSpell() {
            let spell = {
                Name : this.name,
                Description: this.description,
                Damage: this.damage,
                Duration: this.duration,
                SpellType: this.spellType,
                Range: this.range
            }

            this.$emit('submit', spell);
        }
    }
}
</script>

<style lang="scss" scoped>

</style>