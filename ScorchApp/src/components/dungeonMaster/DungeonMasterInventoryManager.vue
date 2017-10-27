<template>
    <div class="dm-inventory-component d-flex">
        <div class="flex-column">
            <div class="btn-group-vertical creator-group" role="group">
                <button class="btn btn-secondary border border-dark" type="button" v-on:click="state='createAG'">Create Adv. Gear</button>
                <button class="btn btn-secondary border border-dark" type="button" v-on:click="state='createArmor'">Create Armor</button>
                <button class="btn btn-secondary border border-dark" type="button" v-on:click="state='createQuiver'">Create Quiver</button>
                <button class="btn btn-secondary border border-dark" type="button" v-on:click="state='createWeapon'">Create Weapon</button>                    
            </div>
        <div class="item-search flex-column">
            <div>
              <p>search bar here...</p>
            </div>
        </div>
        <div class="item-creator flex-column">
            <div>
              <p>results here</p>
            </div>
        </div>
        <div class="flex-column item-store">
          <button class="createAdvGear" type="button" v-on:click="state='createAG'"></button><br />
          <button class="createArmor" type="button" v-on:click="state='createArmor'"></button><br />
          <button class="createQuiver" type="button" v-on:click="state='createQuiver'"></button><br />
          <button class="createWeapon" type="button" v-on:click="state='createWeapon'"></button>
        </div>
        <div class="flex-column item-creator">
          <div>
              <adventurer-gear-creator v-if="state == 'createAG'" />
              <weapon-creator v-if="state == 'createWeapon'" />
              <armor-creator v-if="state == 'createArmor'" />
              <quiver-creator v-if="state == 'createQuiver'" />
          </div>
        </div>
    </div>

</template>

<script>
    import AdventurerGearCreator from './operators/AdventurerGearCreator.vue'
    import WeaponCreator from './operators/WeaponCreator.vue'
    import ArmorCreator from './operators/ArmorCreator.vue'
    import QuiverCreator from './operators/QuiverCreator.vue'

export default {
    name : 'dm-inventory-manager-component',

    data() {
      return {
        state : ''
      }
    },
    computed: {

    },
    components: {
        AdventurerGearCreator,
        WeaponCreator,
        ArmorCreator,
        QuiverCreator
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
        padding: 1%;
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
</style>
