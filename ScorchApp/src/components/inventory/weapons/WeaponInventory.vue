<template>
    <div class="card">
         <modal v-if="showModal" v-on:close="showModal = false">
            <h3 slot="header">
                {{ selectedWeapon.Name }}
            </h3>
            <div slot="body">
                
            </div>
        </modal>
    <div class="card-header" role="tab" id="weapos">
        <h5 class="mb-0">
        <a data-toggle="collapse" href="#weaponInventory" aria-expanded="false" aria-controls="weaponInventory">
            Weapons
        </a>
        </h5>
    </div>
    <div id="weaponInventory" class="collapse" role="tabpanel" aria-labelledby="weapos" data-parent="#accordion">
        <div class="card-body weapon-list">
            <div v-for="(weapon, index) in weapons" 
                 @click="weaponClick(weapon)" 
                 :key="index" 
                 class="list-group-item list-group-item-action ">
                <div class="d-flex align-items-center justify-content-between">
                    <div class="d-flex flex-column">
                        <span>{{ weapon.Name }}</span>
                        <small>Damage {{ weapon.Damage }} </small>        
                    </div>
                    <button class="btn btn-primary" @click="equipWeapon(weapon, $event)">+</button>
                </div>
            </div>
        </div>
    </div>
    </div>
</template>

<script>

import { Modal } from 'components/util'

export default {
    name: 'weapon-inventory',
    props: ['weapons'],
    data() {
        return {
            showModal: false,
            selectedWeapon: {}
        }
    },
    methods: {
        weaponClick(weapon) {
            this.selectedWeapon = weapon;
            this.showModal = true;
        },
        equipWeapon(weapon, event) {
            if (event) {
                event.stopPropagation();
            }
            this.$emit('equip', weapon);
        }
    },
    components: {
        Modal
    }
}
</script>

<style lang="scss" scoped>
.weapon-list {
    height: 400px;
    overflow-y: scroll;
}
</style>