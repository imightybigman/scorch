<template>
    <div class="dm-inventory-component d-flex">
        <div class="flex-column">
            <div class="btn-group-vertical creator-group" role="group">
                <button class="btn btn-secondary border border-dark" type="button" v-on:click="state='createAG'">Create Adv. Gear</button>
                <button class="btn btn-secondary border border-dark" type="button" v-on:click="state='createArmor'">Create Armor</button>
                <button class="btn btn-secondary border border-dark" type="button" v-on:click="state='createQuiver'">Create Quiver</button>
                <button class="btn btn-secondary border border-dark" type="button" v-on:click="state='createWeapon'">Create Weapon</button>                    
            </div>
        </div>
        <div class="item-creator flex-column">
            <div>
                <adventurer-gear-creator v-if="state == 'createAG'" />
                <weapon-creator v-if="state == 'createWeapon'" />
                <armor-creator v-if="state == 'createArmor'" />
                <quiver-creator v-if="state == 'createQuiver'" />
            </div>

        </div>
        <div class="flex-column item-store">
            sup
        </div>
    </div>
    
</template>

<script>
    import AdventurerGearCreator from './operators/AdventurerGearCreator.vue'
    import WeaponCreator from './operators/WeaponCreator.vue'
    import ArmorCreator from './operators/ArmorCreator.vue'
    import QuiverCreator from './operators/QuiverCreator.vue'

export default {
    name : 'dm-inventory-manager-component',
    
    data() {
      return {
        state : ''
      }
    },
    computed: {

    },
    components: {
        AdventurerGearCreator,
        WeaponCreator,
        ArmorCreator,
        QuiverCreator
    }
}
</script>

<style lang="scss" scoped>
    div {
        box-sizing: border-box;
    }
    
    .dm-inventory-component {
        margin: 1%;
    }
    .item-creator {
        margin-left: 1%;
        margin-right: 1%;
        flex: 1;
        flex-grow: 2;
        border-radius: 10px;
    }
    .item-store {
        flex: 1;
        flex-grow: 3;
    }
</style>