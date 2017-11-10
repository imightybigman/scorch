<template>
    <div class="dm-inventory-component d-flex">
        <div class="item-search flex-column">
          <div class="item-searcher flex-column">
            <searcher v-on:search-row-selected="searchItem" :search-data="searchItems" :limit-per-page="10" :column-keys="columnKeys"/>
          </div>
        </div>
        <div class="flex-row item-store">
          <button class="createAdvGear" type="button" v-on:click="state='createAdventurerGear';selectedItem=''"></button>
          <button class="createArmor" type="button" v-on:click="state='createArmor';selectedItem=''"></button>
          <button class="createQuiver" type="button" v-on:click="state='createQuiver';selectedItem=''"></button>
          <button class="createWeapon" type="button" v-on:click="state='createWeapon';selectedItem=''"></button>
          <button class="createAccessory" type="button" v-on:click="state='createAccessory';selectedItem=''"></button>
        </div>
        <div class="flex-column item-creator">
          <div>
              <adventurer-gear-creator :gear="this.selectedItem" v-if="state == 'createAdventurerGear'" />
              <weapon-creator :weapon="this.selectedItem" v-if="state == 'createWeapon'" />
              <armor-creator :armor="this.selectedItem" v-if="state == 'createArmor'" />
              <quiver-creator :quiver="this.selectedItem" v-if="state == 'createQuiver'" />
              <accessory-creator :accessory="this.selectedItem" v-if="state == 'createAccessory'" />
          </div>
        </div>
    </div>

</template>

<script>
    import { Searcher } from 'components/util'
    import { QuiverCreator, ArmorCreator, WeaponCreator, AdventurerGearCreator, AccessoryCreator } from 'components/items'
    import { ItemService } from 'services'


export default {
    name : 'dm-inventory-manager-component',

    data() {
      return {
        state : '',
        selectedItem: {},
        columnKeys: ['Name', 'ItemClass', 'Cost', 'AC', 'Damage', 'Slot']
      }
    },
    async created() {
      await this.$store.dispatch('getDisplayItems');
    },
    computed: {
        searchItems() {
            return this.$store.getters.items;
        }
    },
    methods: {
      async searchItem(item){
          if(item){
              let response = {};
              response = await ItemService.getItemById(item.ItemId);
              this.selectedItem = response.body;
              this.state = "create" + this.selectedItem.ItemClass;
          }
      }
    },
    components: {
        AdventurerGearCreator,
        WeaponCreator,
        ArmorCreator,
        Searcher,
        QuiverCreator,
        AccessoryCreator
    }
}
</script>

<style lang="scss" scoped>
    div {
        box-sizing: border-box;
    }

    .dm-inventory-component {
        margin: 1%;
    }
    .item-creator {
        margin-left: 1%;
        margin-right: 1%;
        flex: 1;
        flex-grow: 2;
        border-radius: 10px;
    }
    .item-search {
        margin-top: -0.5%;
        flex: 1;
        flex-grow: 2;
        border-radius: 10px;

    }
    .item-creator {
        flex: 1;
        flex-grow: 1;
        border-radius: 10px;
    }
    .item-store {
        padding: 0.5%;
        flex: 1;
        flex-grow: 0;
    }
    .createAdvGear {
      background-color: #4CAF50;
      width: 150px;
      height: 150px;
      background-image: url("~assets/dmIcons/advpack.png");
      background-size: 130px 130px;
      background-position: center;
      background-repeat: no-repeat;
    }

    .createArmor {
      background-color: #4CAF50;
      width: 150px;
      height: 150px;
      background-image: url("~assets/dmIcons/armor.png");
      background-size: 130px 130px;
      background-position: center;
      background-repeat: no-repeat;
    }

    .createQuiver {
      background-color: #4CAF50;
      width: 150px;
      height: 150px;
      background-image: url("~assets/dmIcons/quiver.png");
      background-size: 130px 130px;
      background-position: center;
      background-repeat: no-repeat;
    }

    .createWeapon {
      background-color: #4CAF50;
      width: 150px;
      height: 150px;
      background-image: url("~assets/dmIcons/weapons.png");
      background-size: 130px 130px;
      background-position: center;
      background-repeat: no-repeat;
    }

    .createAccessory {
      background-color: #4CAF50;
      width: 150px;
      height: 150px;
      background-size: 130px 130px;
      background-position: center;
      background-repeat: no-repeat;
    }
</style>
