<template>
<div class="inventory-card">
  <adventurer-gear-details :adventurergear="selectedAdvGear" :showModal="showDetail" v-on:close="showDetail = false"></adventurer-gear-details>
    <div class="item-list scrollbar">
      <div v-for="(adventurerGear, index) in adventurerGears" :key="index" class="d-flex flex-wrap flex-column list-item border">
        <div @click="adventurerGearClick(adventurerGear)">
          <item-card :item="adventurerGear"></item-card>
        </div>
        <div>
          <button v-if="adventurerGear.Count <= 1" class="btn btn-success" @click="useAdventurerGear(adventurerGear)">
            Use
          </button>
          <button v-if="adventurerGear.Count > 1" class="btn btn-success dropdown-toggle" type="button" id="multipleUse" data-toggle="dropdown" aria-haspopup="true"
            aria-expanded="false">
            Use
          </button>
          <div class="dropdown-menu item-use-dropdown" aria-labelledby="multipleUse">
            <a class="input-group">
              <span class="input-group-addon" id="item-count">
                #
              </span>
              <input type="number" v-model="itemCount" class="form-control" placeholder="e.g. 1" aria-describedby="item-count">
              <button class="btn btn-success" @click="useAdventurerGear(adventurerGear)">
                Use
              </button>
            </a>
          </div>
          <button class="btn btn-warning" @click="sellAdventurerGear(adventurerGear)">
            Sell
          </button>
          <button class="btn btn-danger" @click="deleteAdventurerGear(adventurerGear)">
            Delete
          </button>
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
            showDetail: false,
            itemCount: 1
        }
    },
    props: ['adventurerGears'],
    methods: {
        adventurerGearClick(adventurerGear) {
            this.selectedAdvGear = adventurerGear;
            this.showDetail = true;
        },
        sellAdventurerGear(adventurerGear) {
            this.$emit('sell', adventurerGear);
        },
        deleteAdventurerGear(adventurerGear) {
          this.$emit('delete', adventurerGear);
        },
        useAdventurerGear(adventurerGear) {
          // todo
          let adventurerGearCopy = adventurerGear;
          adventurerGearCopy.Count -= this.itemCount;
          if(adventurerGearCopy.Count < 0){
            this.$emit('delete', adventurerGear);          
          }
          else {
            this.$emit('update', adventurerGear);
          }
          this.itemCount = 1;
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

.item-use-dropdown {
  padding: 1%;
}
</style>