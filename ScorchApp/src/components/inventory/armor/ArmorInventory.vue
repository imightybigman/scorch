<template>
    <div class="card">
        <armor-detail :armor="selectedArmor" :showModal="showDetail" v-on:close="showDetail = false"></armor-detail>

        <div class="card-header" role="tab" id="armor">
            <h5 class="mb-0">
            <a data-toggle="collapse" href="#armorInventory" aria-expanded="false" aria-controls="armorInventory">
                Armors
            </a>
            </h5>
        </div>
        <div id="armorInventory" class="collapse" role="tabpanel" aria-labelledby="armor" data-parent="#accordion">
            <div class="card-body item-list">
            <div v-for="(armor, index) in armors" 
                    @click="armorClick(armor)" 
                    :key="index" 
                    class="list-item border">
                    <div class="d-flex justify-content-between">
                        <div class="d-flex flex-column">
                            <span>{{ armor.Name }}</span>
                            <small>{{ armor.Slot }}</small>
                            <small>AC {{ armor.AC }} </small>        
                        </div>          
                        <button class="btn btn-primary" @click="equipArmor(armor, $event)">
                            <i class="fa fa-level-up" aria-hidden="true"></i>
                        </button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import ArmorDetail from './ArmorDetail';

export default {
    name: 'armor-inventory',
    data() {
        return {
            selectedArmor: {},
            showDetail: false
        }
    },
    props: ['armors'],
    methods: {
        armorClick(armor) {
            this.selectedArmor = armor;
            this.showDetail = true;
        },
        equipArmor(armor, event) {
         if (event) {
                event.stopPropagation();
            }
            this.$emit('equip', armor);
        }
    },
    components: {
        ArmorDetail
    }
}
</script>

<style lang="scss" scoped>
@import '~styles/shared.scss';

</style>