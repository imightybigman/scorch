<template>
    <div class="card inventory-card">
        <weapon-detail :weapon="selectedWeapon" :showModal="showDetail" v-on:close="showDetail = false"></weapon-detail>
        <div class="card-header" role="tab" id="weapons">
            <h5 class="mb-0">
            <a data-toggle="collapse" href="#weaponInventory" aria-expanded="false" aria-controls="weaponInventory">
                Weapons
            </a>
            </h5>
        </div>
        <div id="weaponInventory" class="collapse show" role="tabpanel" aria-labelledby="weapons" data-parent="#inventory">
            <div class="card-body item-list">
                <div v-for="(weapon, index) in weapons" 
                    :key="index" 
                    class="d-flex flex-column list-item border">
                    <div @click="weaponClick(weapon)">
                        <item-card :item="weapon"></item-card>
                    </div>
                    <div>
                        <button class="btn btn-primary" @click="equipWeapon(weapon)">
                            Equip
                        </button>
                        <button class="btn btn-danger" @click="sellWeapon(weapon)">
                            Sell
                        </button>
                    </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import WeaponDetail from './WeaponDetail'
import { ItemCard } from 'components/items'

export default {
    name: 'weapon-inventory',
    props: ['characterId', 'weapons'],
    data() {
        return {
            showDetail: false,
            selectedWeapon: {}
        }
    },
    methods: {
        weaponClick(weapon) {
            this.selectedWeapon = weapon;
            this.showDetail = true;
        },
        equipWeapon(weapon) {
            if(weapon.Slot == 'Two-Handed') {
                // Need unequip the off hand item
                let payload = {
                    characterId: this.characterId,
                    slot: 'OffHand'
                };
                this.$store.dispatch('unequipItem', payload);
            }
            this.$emit('equip', weapon);
        },
        sellWeapon(weapon) {
            this.$emit('sell', weapon);
        }
    },
    components: {
        WeaponDetail,
        ItemCard
    }
}
</script>

<style lang="scss" scoped>
@import '~styles/shared.scss';

</style>