<template>
<div class="inventory-card">
  <accessory-detail :accessory="selectedAccessory" :showModal="showDetail" v-on:close="showDetail = false"></accessory-detail>
  <div class="item-list scrollbar">
    <div v-for="(accessory, index) in accessories" :key="index" class="d-flex flex-column  list-item border">
      <div @click="accessoryClick(accessory)">
        <item-card :item="accessory"></item-card>
      </div>
      <div>
        <button class="btn btn-primary dropdown-toggle" type="button" id="accessoryEquip" data-toggle="dropdown" aria-haspopup="true"
          aria-expanded="false">
          Equip
        </button>
        <button class="btn btn-warning" @click="sellAccessory(accessory)">
          Sell
        </button>
        <button class="btn btn-danger" @click="deleteAccessory(accessory)">
          Delete
        </button>
        <div class="dropdown-menu" aria-labelledby="accessoryEquip">
          <a class="dropdown-item" @click="equipAccessory(accessory, 'Necklace')" v-if="accessory.Slot === 'Necklace'">Necklace</a>
          <a class="dropdown-item" @click="equipAccessory(accessory, 'LeftRing')" v-if="accessory.Slot.indexOf('Ring') !== -1">Left Ring</a>
          <a class="dropdown-item" @click="equipAccessory(accessory, 'RightRing')" v-if="accessory.Slot.indexOf('Ring') !== -1">Right Ring</a>
        </div>
      </div>
    </div>
  </div>
</div>
</template>

<script>
import AccessoryDetail from './accessoryDetail'
import { ItemCard } from 'components/items'

export default {
    name: 'accessory-inventory',
    data() {
        return {
            selectedAccessory: {},
            showDetail: false
        }
    },
    props: ['accessories'],
    methods: {
        accessoryClick(accessory) {
            this.selectedAccessory = accessory;
            this.showDetail = true;
        },
        equipAccessory(accessory, slot) {
            accessory.Slot = slot;
            this.$emit('equip', accessory);
        },
        sellAccessory(accessory){
            this.$emit('sell', accessory);
        },
        deleteAccessory(accessory){
            this.$emit('delete', accessory);
        }
    },
    components: {
        AccessoryDetail,
        ItemCard
    }
}
</script>

<style lang="scss" scoped>
@import '~styles/shared.scss';

</style>