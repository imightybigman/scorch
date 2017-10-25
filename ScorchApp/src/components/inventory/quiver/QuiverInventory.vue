<template>
    <div class="card">
    <div class="card-header" role="tab" id="quiver">
        <h5 class="mb-0">
        <a data-toggle="collapse" href="#quiverInventory" aria-expanded="false" aria-controls="quiverInventory">
            Quivers
        </a>
        </h5>
    </div>
    <div id="quiverInventory" class="collapse" role="tabpanel" aria-labelledby="quiver" data-parent="#accordion">
        <div class="card-body item-list">
        <div v-for="(quiver, index) in quivers" 
                 @click="quiverClick(quiver)" 
                 :key="index" 
                 class="list-item border">
                <div class="d-flex justify-content-between">
                    <span>{{ quiver.Name }}</span>            
                    <button class="btn btn-primary" @click="equipQuiver(quiver, $event)">
                        <i class="fa fa-level-up" aria-hidden="true"></i>
                    </button>
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

            this.$emit('equip', quiver);
        }
    }
}
</script>

<style lang="scss" scoped>
@import '~styles/shared.scss';

</style>