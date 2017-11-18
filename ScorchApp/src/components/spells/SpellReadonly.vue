<template>
    <div class="form spell-form">
        <h4>Level: {{ spell.Level }}, {{ spell.Name}}</h4>
        <div class="form-group">
            <label for="spellDescription">Spell Description</label>
            <textarea rows="8" type="text" id="spellDescription" readonly class="form-control" v-model="spell.Description" placeholder="Spell Description" />
        </div>
        <div class="form-group" v-if="spell.Damage">
            <label for="damage">Spell Damage</label>
            <input type="text" id="damage" readonly class="form-control" v-model="spell.Damage" />
        </div>
        <div class="form-group" v-if="spell.DamageType">
            <label for="damageType">Spell Damage Type</label>
            <input type="text" id="damageType" readonly class="form-control" v-model="spell.DamageType" />
        </div>
        <div class="form-group" v-if="spell.Range">
            <label for="range">Spell Range</label>
            <input type="text" id="range" readonly class="form-control" v-model="spell.Range" />
        </div>
        <div class="form-group" v-if="spell.Save">
            <label for="save">Spell Save (stat + 8 + proficiency)</label>
            <input type="text" id="save" readonly class="form-control" v-model="spell.Save" />
        </div>
        <div class="form-group" v-if="spell.SaveSuccess">
            <label for="saveSuccess">Spell Save Success</label>
            <input type="text" id="saveSuccess" readonly class="form-control" v-model="spell.SaveSuccess" />
        </div>
        <div class="form-group" v-if="spell.AddCastingModifier">
            <label for="castingMod">Add Casting Modifier</label>
            <input type="text" id="castingMod" readonly class="form-control" v-model="spell.AddCastingModifier" />
        </div>
        <div class="form-group" v-if="spell.CastingTime">
            <label for="castingTime">Spell Casting Time</label>
            <input type="text" id="castingTime" readonly class="form-control" v-model="spell.CastingTime" />
        </div>
        <div class="form-group" v-if="spell.Concentration">
            <label for="concentration">Spell Concentration</label>
            <input type="text" id="concentration" readonly class="form-control" v-model="spell.Concentration" />
        </div>
        <div class="form-group" v-if="spell.Duration">
            <label for="duration">Spell Duration</label>
            <input type="text" id="duration" readonly class="form-control" v-model="spell.Duration" />
        </div>
        <div class="form-group" v-if="spell.Healing">
            <label for="healing">Spell Healing</label>
            <input type="text" id="healing" readonly class="form-control" v-model="spell.Healing" />
        </div>
        <div class="form-group" v-if="spell.HigherLevelHealing">
            <label for="higherLevelHealing">Spell Higher Level Healing</label>
            <input type="text" id="higherLevelHealing" readonly class="form-control" v-model="spell.HigherLevelHealing" />
        </div>
        <div class="form-group" v-if="spell.HigherSpellSlotBonus">
            <label for="higherSpellSlotBonus">Spell Higher Spell Slot Bonus</label>
            <input type="text" id="higherSpellSlotBonus" readonly class="form-control" v-model="spell.HigherSpellSlotBonus" />
        </div>
        <div class="form-group" v-if="spell.HigherSpellSlotDice">
            <label for="higherSpellSlotDice">Spell Higher Spell Slot Dice</label>
            <input type="text" id="higherSpellSlotDice" readonly class="form-control" v-model="spell.HigherSpellSlotDice" />
        </div>
        <div class="form-group" v-if="spell.SavingThrows">
            <label for="savingThrows">Spell Saving Throws</label>
            <input type="text" id="savingThrows" readonly class="form-control" v-model="spell.SavingThrows" />
        </div>
        <div class="form-group" v-if="spell.School">
            <label for="school">Spell School</label>
            <input type="text" id="school" readonly class="form-control" v-model="spell.School" />
        </div>
        <div class="form-group" v-if="spell.SecondaryDamage">
            <label for="secondaryDamage">Spell Secondary Damage</label>
            <input type="text" id="secondaryDamage" readonly class="form-control" v-model="spell.SecondaryDamage" />
        </div>
        <div class="form-group" v-if="spell.SecondaryDamageType">
            <label for="secondaryDamageType">Spell Secondary Damage Type</label>
            <input type="text" id="secondaryDamageType" readonly class="form-control" v-model="spell.SecondaryDamageType" />
        </div>
        <div class="form-group" v-if="spell.SecondaryHigherSpellSlotDice">
            <label for="secondaryHigherSpellSlotDice">Spell Secondary Higher Spell Slot Dice</label>
            <input type="text" id="secondaryHigherSpellSlotDice" readonly class="form-control" v-model="spell.SecondaryHigherSpellSlotDice" />
        </div>
        <div class="form-group" v-if="spell.SpellType">
            <label for="spellType">Spell Type</label>
            <input type="text" id="spellType" readonly class="form-control" v-model="spell.SpellType" />
        </div>
        <div class="form-group" v-if="spell.Target">
            <label for="target">Spell Target</label>
            <input type="text" id="target" readonly class="form-control" v-model="spell.Target" />
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

</style>