<template>
    <div class="card">
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
                 @click="adventurerGearClick(adventurerGear)" 
                 :key="index" 
                 class="list-item border">
                <div class="d-flex justify-content-between">
                    <span>{{ adventurerGear.Name }}</span>            
                </div>
            </div>
        </div>
        </div>
    </div>
    </div>
</template>

<script>
export default {
    name: 'adventurerGear-inventory',
    props: ['adventurerGears'],
    methods: {
        adventurerGearClick() {

        },
        equipAdventurerGear(adventurerGear, event) {
            if (event) {
                event.stopPropagation();
            }
        }   
    }
}
</script>

<style lang="scss" scoped>
@import '~styles/shared.scss';

</style>