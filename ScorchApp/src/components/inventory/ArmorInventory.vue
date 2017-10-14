<template>
    <div class="card">
    <div class="card-header" role="tab" id="weapos">
        <h5 class="mb-0">
        <a data-toggle="collapse" href="#armorInventory" aria-expanded="false" aria-controls="armorInventory">
            Armors
        </a>
        </h5>
    </div>
    <div id="armorInventory" class="collapse" role="tabpanel" aria-labelledby="weapos" data-parent="#accordion">
        <div class="card-body armor-list">
        <div v-for="(armor, index) in armors" 
                 @click="armorClick(armor)" 
                 :key="index" 
                 class="list-group-item list-group-item-action">
                <div class="d-flex align-items-center justify-content-between">
                    <span>{{ armor.Name }}</span>            
                    <button class="btn btn-primary" @click="equipArmor(armor, $event)">+</button>
                </div>
            </div>
        </div>
    </div>
    </div>
</template>

<script>
export default {
    name: 'armor-inventory',
    props: ['armors'],
    methods: {
        armorClick() {

        },
        equipArmor(armor, event) {
            if (event) {
                event.stopPropagation();
            }
            console.log('equip')
        }
    }
}
</script>

<style lang="scss" scoped>
.armor-list {
    height: 400px;
    overflow-y: scroll;
}
</style>