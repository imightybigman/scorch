<template>
    <div class="dm-inventory-component d-flex">
        <div class="item-creator flex-column">
            <div class="dropdown">
                <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenu2" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    Create
                </button>
                <div class="dropdown-menu" aria-labelledby="dropdownMenu2">
                    <button class="dropdown-item" type="button" v-on:click="state=1">Create Adv. Gear</button>
                    <button class="dropdown-item" type="button" v-on:click="state=2">Create Armor</button>
                    <button class="dropdown-item" type="button" v-on:click="state=3">Create Quiver</button>
                    <button class="dropdown-item" type="button" v-on:click="state=4">Create Weapon</button>
                </div>
            </div>
            <div>
                <adventurer-gear-creator v-if="state == 1" />
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
        state : 0
      }
    },
    methods: {
        doNothing() {
            
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
        padding: 1%;
        flex: 1;
        flex-grow: 1;
        border-radius: 10px;
    }
    .item-store {
        flex: 1;
        flex-grow: 3;
    }

</style>