<template>
    <div class="card">
    <div class="card-header" role="tab" id="weapos">
        <h5 class="mb-0">
        <a data-toggle="collapse" href="#adventurerGearInventory" aria-expanded="false" aria-controls="adventurerGearInventory">
            Adventurer Gears
        </a>
        </h5>
    </div>
    <div id="adventurerGearInventory" class="collapse" role="tabpanel" aria-labelledby="weapos" data-parent="#accordion">
        <div class="card-body adventurerGear-list">
            <div v-for="(adventurerGear, index) in adventurerGears" 
                 @click="adventurerGearClick(adventurerGear)" 
                 :key="index" 
                 class="list-group-item list-group-item-action">
                {{ adventurerGear.Name }}
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

        }
    }
}
</script>

<style lang="scss" scoped>
.adventurerGear-list {
    height: 400px;
    overflow-y: scroll;
}
</style>