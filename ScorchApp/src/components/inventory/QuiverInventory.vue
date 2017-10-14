<template>
    <div class="card">
    <div class="card-header" role="tab" id="weapos">
        <h5 class="mb-0">
        <a data-toggle="collapse" href="#quiverInventory" aria-expanded="false" aria-controls="quiverInventory">
            Quivers
        </a>
        </h5>
    </div>
    <div id="quiverInventory" class="collapse" role="tabpanel" aria-labelledby="weapos" data-parent="#accordion">
        <div class="card-body quiver-list">
        <div v-for="(quiver, index) in quivers" 
                 @click="quiverClick(quiver)" 
                 :key="index" 
                 class="list-group-item list-group-item-action">
                <div class="d-flex align-items-center justify-content-between">
                    <span>{{ quiver.Name }}</span>            
                    <button class="btn btn-primary" @click="equipQuiver(quiver, $event)">+</button>
                </div>
            </div>
        </div>
    </div>
    </div>
</template>

<script>
export default {
    name: 'quiver-inventory',
    props: ['quivers'],
    methods: {
        quiverClick() {

        },
        equipQuiver(quiver, event) {
            if (event) {
                event.stopPropagation();
            }
            console.log('equip')
        }
    }
}
</script>

<style lang="scss" scoped>
.quiver-list {
    height: 400px;
    overflow-y: scroll;
}
</style>