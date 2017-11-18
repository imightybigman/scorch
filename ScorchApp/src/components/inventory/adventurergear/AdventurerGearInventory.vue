<template>
<div class="d-flex inventory-card">
  <adventurer-gear-details :adventurergear="selectedAdvGear" :showModal="showDetail" v-on:close="showDetail = false"></adventurer-gear-details>
    <div class="item-list scrollbar">
      <div v-for="(adventurerGear, index) in adventurerGears" :key="index" class="d-flex flex-wrap flex-column list-item border">
        <div @click="adventurerGearClick(adventurerGear)">
          <item-card :item="adventurerGear"></item-card>
        </div>
        <div>
          <button class="btn btn-warning" @click="sellAdventurerGear(adventurerGear)">
            Sell
          </button>
          <button class="btn btn-danger" @click="deleteAdventureGear(adventurergear)">
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
        deleteAdventureGear(adventureGear) {
          this.$emit('delete', adventurerGear);

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