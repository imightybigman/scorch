<template>
<div class="card">
  
  <div class="card-header">
    Inventory
  </div>
  <div class="card-body">
    <div id="accordion" role="tablist">
      <adventurer-gear-inventory :adventurerGears="adventurerGears"></adventurer-gear-inventory>
      <weapon-inventory :weapons="weapons"></weapon-inventory>
      <armor-inventory :armors="armors"></armor-inventory>
      <quiver-inventory :quivers="quivers"></quiver-inventory>
    </div>
  </div>
</div>


</template>

<script>
import WeaponInventory from './WeaponInventory'
import AdventurerGearInventory from './AdventurerGearInventory'
import QuiverInventory from './QuiverInventory'
import ArmorInventory from './ArmorInventory'
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
    components: {
      WeaponInventory,
      AdventurerGearInventory,
      QuiverInventory,
      ArmorInventory
    }
}

</script>

<style lang="scss" scoped></style>