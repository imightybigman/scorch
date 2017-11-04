<template>
    <div class="card d-flex inventory-card">
        <adventurer-gear-details :adventurergear="selectedAdvGear" :showModal="showDetail"  v-on:close="showDetail = false"></adventurer-gear-details>
        <div class="card-header" role="tab" id="adventurergear">
            <h5 class="mb-0">
            <a data-toggle="collapse" href="#adventurerGearInventory" aria-expanded="false" aria-controls="adventurerGearInventory">
                Adventure Gear
            </a>
            </h5>
        </div>
        <div id="adventurerGearInventory" class="collapse" role="tabpanel" aria-labelledby="adventurergear" data-parent="#accordion">
            <div class="card-body item-list">
                <div v-for="(adventurerGear, index) in adventurerGears" 
                    :key="index" 
                    class="d-flex flex-wrap flex-column list-item border">
                    <div @click="adventurerGearClick(adventurerGear)">
                        <item-card :item="adventurerGear"></item-card>
                    </div>
                </div>
            </div>
            </div>
        </div>
    </div>

</template>

<script>
import AdventurerGearDetails from './AdventurerGearDetails';
import { ItemCard } from 'components/items'

export default {
    name: 'adventurerGear-inventory',
    data() {
        return {
            selectedAdvGear: {},
            showDetail: false
        }
    }, 
    props: ['adventurerGears'],
    methods: {
        adventurerGearClick(adventurerGear) {
            this.selectedAdvGear = adventurerGear;
            this.showDetail = true;
        }
    },
    components: {
        AdventurerGearDetails,
        ItemCard
    }
}
</script>

<style lang="scss" scoped>
@import '~styles/shared.scss';

</style>