<template>
<div class="d-flex inventory-card">
  <adventurer-gear-details :adventurergear="selectedAdvGear" :showModal="showDetail" v-on:close="showDetail = false"></adventurer-gear-details>
    <div class="item-list scrollbar">
      <div v-for="(adventurerGear, index) in adventurerGears" :key="index" class="d-flex flex-wrap flex-column list-item border">
        <div @click="adventurerGearClick(adventurerGear)">
          <item-card :item="adventurerGear"></item-card>
        </div>
        <div>
          <button v-if="adventurerGear.Count <= 1" class="btn btn-success" @click="useAdventurerGear(adventurerGear, 1)">
            Use
          </button>
          <button v-if="adventurerGear.Count > 1" class="btn btn-success" @click="useAdventurerGear(adventurerGear, 1)">
            Use Multiple
          </button>
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
            showDetail: false
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
        useAdventurerGear(adventurerGear, count) {
          // todo
          let adventurerGearCopy = adventurerGear;
          this.$emit('update', adventurerGear);
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