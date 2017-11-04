<template>
<div class="card d-flex inventory">
  <div class="card-header">
    Inventory
  </div>
  <div class="card-body">
    <div id="accordion" role="tablist">
      <weapon-inventory @equip="equipItem" :weapons="weapons"></weapon-inventory>
      <armor-inventory @equip="equipItem" :armors="armors"></armor-inventory>
      <quiver-inventory @equip="equipItem" :characterId="characterId" :quivers="quivers"></quiver-inventory>
      <adventurer-gear-inventory :adventurerGears="adventurerGears"></adventurer-gear-inventory>
    </div>
  </div>
</div>


</template>

<script>
import WeaponInventory from './weapons/WeaponInventory'
import AdventurerGearInventory from './adventurergear/AdventurerGearInventory'
import QuiverInventory from './quiver/QuiverInventory'
import ArmorInventory from './armor/ArmorInventory'
import { mapGetters } from 'vuex'

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
      }
    },
    methods: {
      async equipItem(item) {
        let equipPayload = {
          characterId: this.characterId,
          item: item
        }
        await this.$store.dispatch('equipItem', equipPayload);
      }
    },
    components: {
      WeaponInventory,
      AdventurerGearInventory,
      QuiverInventory,
      ArmorInventory
    }
}

</script>

<style lang="scss" scoped>
.inventory {
  flex: 1 0 auto;
}
</style>