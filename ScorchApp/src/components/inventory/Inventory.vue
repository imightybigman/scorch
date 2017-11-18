<template>
<div class="card d-flex inventory scrollbar">
  <div class="card-header">
    Inventory
  </div>
  <div class="card-body">
    <div id="inventory" role="tablist">
      <accordian :header="'Weapons'">
        <weapon-inventory slot="body" @equip="equipItem" @delete="deleteItem" @sell="sellItem" :characterId="characterId" :weapons="weapons"></weapon-inventory>
      </accordian>
      <accordian :header="'Armors'">
        <armor-inventory slot="body" @equip="equipItem" @delete="deleteItem" @sell="sellItem" :armors="armors"></armor-inventory>
      </accordian>
      <accordian :header="'Accessories'">
        <accessory-inventory slot="body" @equip="equipItem" @delete="deleteItem" @sell="sellItem" :accessories="accessories"></accessory-inventory>
      </accordian>
      <accordian :header="'Quivers'">
        <quiver-inventory slot="body" @equip="equipItem" @delete="deleteItem" @sell="sellItem" :characterId="characterId" :quivers="quivers"></quiver-inventory>
      </accordian>
      <accordian :header="'Adventurer Gear'">
        <adventurer-gear-inventory slot="body" @sell="sellItem" :adventurerGears="adventurerGears"></adventurer-gear-inventory>
      </accordian>    
    </div>
  </div>
</div>


</template>

<script>
import WeaponInventory from './weapon/WeaponInventory'
import AdventurerGearInventory from './adventurergear/AdventurerGearInventory'
import QuiverInventory from './quiver/QuiverInventory'
import ArmorInventory from './armor/ArmorInventory'
import AccessoryInventory from './accessory/AccessoryInventory'
import { Accordian } from 'components/util'

export default {
    name: 'character-inventory',
    props: ['characterId'],
    computed: {
      weapons() {
        return this.$store.getters.getCharacterWeapons(this.characterId);
      },
      armors() {
        return this.$store.getters.getCharacterArmors(this.characterId);
      },
      quivers() {
        return this.$store.getters.getCharacterQuivers(this.characterId);
      },
      adventurerGears() {
        return this.$store.getters.getCharacterAdventurerGears(this.characterId);        
      },
      accessories(){
        return this.$store.getters.getCharacterAccessories(this.characterId);        
      }
    },
    methods: {
      async equipItem(item) {
        let equipPayload = {
          characterId: this.characterId,
          item: item
        }
        await this.$store.dispatch('equipItem', equipPayload);
      },
      async sellItem(item) {
        let sellPayload = {
          characterId: this.characterId,
          itemId: item.ItemId
        }
        await this.$store.dispatch('sellItem', sellPayload);
      },
      async deleteItem(item){
        let deletePayload = {
          characterId: this.characterId,
          itemId: item.ItemId
        }
        await this.$store.dispatch('deleteItem', deletePayload);
      }
    },
    components: {
      WeaponInventory,
      AdventurerGearInventory,
      QuiverInventory,
      ArmorInventory,
      AccessoryInventory,
      Accordian
    }
}

</script>

<style lang="scss" scoped>
@import '~styles/shared.scss';

.inventory {
  flex: 1 0 auto;
  max-height: 800px;
}
</style>