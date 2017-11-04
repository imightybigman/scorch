<template>
    <div class="card inventory-card">
    <quiver-detail :quiver="selectedQuiver" :showModal="showDetail" v-on:close="showDetail = false"></quiver-detail>
    <div class="card-header" role="tab" id="quiver">
        <h5 class="mb-0">
        <a data-toggle="collapse" href="#quiverInventory" aria-expanded="false" aria-controls="quiverInventory">
            Quivers and Arrows
        </a>
        </h5>
    </div>
    <div id="quiverInventory" class="collapse" role="tabpanel" aria-labelledby="quiver" data-parent="#inventory">
        <div class="card-body item-list">
        <div v-for="(quiver, index) in quivers" 
                 :key="index" 
                    class="d-flex flex-column list-item border">
                <div  @click="quiverClick(quiver)" >
                    <item-card :item="quiver"></item-card>
                </div>
                <div>
                    <button class="btn btn-primary" @click="equipQuiver(quiver)">
                        Equip
                    </button>
                </div>
                <div class="projectile-count d-flex flex-column">
                    <div class="projectiles d-flex" v-for="(count, projectile, index) in quiver.Projectiles" :key="index">
                        <strong>{{projectile}} : {{ getArrowCount(count) }}</strong>
                        <div class="d-flex flex-row ml-auto">
                        <button class="projectile-mod btn btn-primary btn-sm" @click="decrementProjectile(count, quiver)"><i class="fa fa-minus"></i></button>                        
                        <button class="projectile-mod btn btn-primary btn-sm" @click="incrementProjectile(count, quiver)"><i class="fa fa-plus"></i></button>
                        <button class="projectile-mod btn btn-primary" @click="updateCount(quiver, $event)">Update Arrows</button>
                        </div>
                   </div>
                </div>
            </div>
        </div>
    </div>
    </div>
</template>

<script>
import QuiverDetail from './QuiverDetail'
import { ItemCard } from 'components/items'

export default {
    name: 'quiver-inventory',
    props: ['characterId', 'quivers'],
    data() {
        return {
            selectedQuiver: {},
            showDetail: false
        }
    },
    methods: {
        quiverClick(quiver) {
            this.selectedQuiver = quiver;
            this.showDetail = true;
        },
        incrementProjectile(projectile, quiver) {
            projectile.CurrentAmount++;
            if(projectile.CurrentAmount >= projectile.MaxAmount) {
                projectile.CurrentAmount = projectile.MaxAmount;
            }
            
        },
        decrementProjectile(projectile) {
            projectile.CurrentAmount--;
            if(projectile.CurrentAmount <= 0){
                projectile.CurrentAmount = 0;
            }
        },
        getArrowCount(projectile) {
            return `${projectile.CurrentAmount}/${projectile.MaxAmount}`;
        },
        equipQuiver(quiver) {

            this.$emit('equip', quiver);
        },
        async updateCount(quiver, event) {
            if (event) {
                event.stopPropagation();
            }
            let payload = {
                characterId: this.characterId,
                item: quiver
            };
            await this.$store.dispatch('updateItem', payload);
        }
    },
    components : {
        QuiverDetail,
        ItemCard
    }
}
</script>

<style lang="scss" scoped>
@import '~styles/shared.scss';
.projectile-count {
    margin-top: 1%;
}
.projectile-mod {
    margin-right: 1%;
}
.projectiles {
    margin-bottom: 1%;
}
</style>