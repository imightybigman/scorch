<template>
  <div class="character-equip card">
    <img class="card-img-top" v-if="this.character.Sex == 'Male'" src="~assets/dnd-male.jpg" alt="Card image cap">
    <img class="card-img-top" v-else src="~assets/dnd-female.jpg" alt="Card image cap">
    <div class="equipment helm">
      <img v-if="equipment.Helm"
        class="equipped"
        src="~assets/items/stock.jpg"
        @contextmenu.prevent="$refs.ctxMenu.open($event, equipment.Helm)"
        data-toggle="tooltip"
        data-placement="left"
        :title="equipment.Helm.Name"
        alt="Card image cap" />
    </div>
    <div class="equipment necklace">
      <img  v-if="equipment.Necklace"
        class="equipped"
        src="~assets/items/stock.jpg"
        @contextmenu.prevent="$refs.ctxMenu.open($event, equipment.Necklace)"
        data-toggle="tooltip"
        data-placement="left"
        :title="equipment.Necklace.Name"
        alt="Card image cap" />
    </div>
    <div class="equipment chest">
      <img  v-if="equipment.Chest"
        class="equipped"
        src="~assets/items/stock.jpg"
        @contextmenu.prevent="$refs.ctxMenu.open($event, equipment.Chest)"
        data-toggle="tooltip"
        data-placement="left"
        :title="displayAC(equipment.Chest.AC)"
        alt="Card image cap" />
    </div>
    <div class="equipment gauntlets">
      <img  v-if="equipment.Gauntlets"
        class="equipped"
        src="~assets/items/stock.jpg"
        @contextmenu.prevent="$refs.ctxMenu.open($event, equipment.Gauntlets)"
        data-toggle="tooltip"
        data-placement="left"
        :title="equipment.Gauntlets.Name"
        alt="Card image cap" />
    </div>
    <div class="equipment legs">
      <img  v-if="equipment.Legs"
        class="equipped"
        src="~assets/items/stock.jpg"
        @contextmenu.prevent="$refs.ctxMenu.open($event, equipment.Legs)"
        data-toggle="tooltip"
        data-placement="left"
        :title="equipment.Legs.Name"
        alt="Card image cap" />
    </div>
    <div class="equipment boots">
      <img  v-if="equipment.Boots"
        class="equipped"
        src="~assets/items/stock.jpg"
        @contextmenu.prevent="$refs.ctxMenu.open($event, equipment.Boots)"
        data-toggle="tooltip"
        data-placement="left"
        :title="equipment.Boots.Name"
        alt="Card image cap" />
    </div>
    <div class="equipment leftring">
      <img  v-if="equipment.LeftRing"
        class="equipped"
        src="~assets/items/stock.jpg"
        @contextmenu.prevent="$refs.ctxMenu.open($event, equipment.LeftRing)"
        data-toggle="tooltip"
        data-placement="left"
        :title="equipment.LeftRing.Name"
        alt="Card image cap" />
    </div>
    <div class="equipment rightring">
      <img  v-if="equipment.RightRing"
        class="equipped"
        src="~assets/items/stock.jpg"
        @contextmenu.prevent="$refs.ctxMenu.open($event, equipment.RightRing)"
        data-toggle="tooltip"
        data-placement="left"
        :title="equipment.RightRing.Name"
        alt="Card image cap" />
    </div>
    <div class="equipment mainhand">
      <img  v-if="equipment.MainHand"
            class="equipped"
            src="~assets/items/stock.jpg"
            @contextmenu.prevent="$refs.ctxMenu.open($event, equipment.MainHand)"
            data-toggle="tooltip"
            data-placement="left"
            :title="displayDamage(equipment.MainHand.Damage)"
            alt="Card image cap" />
    </div>
    <div class="equipment offhand">
      <img  v-if="equipment.OffHand"
            class="equipped"
            src="~assets/items/stock.jpg"
            @contextmenu.prevent="$refs.ctxMenu.open($event, equipment.OffHand)"
            data-toggle="tooltip"
            data-placement="left"
            :title="displayDamage(equipment.OffHand.Damage)"
            alt="Card image cap" />
    </div>
    <div class="equipment quiver">
      <img  v-if="equipment.Quiver"
            class="equipped"
            src="~assets/items/stock.jpg"
            @contextmenu.prevent="$refs.ctxMenu.open($event, equipment.Quiver)"
            data-toggle="tooltip"
            data-placement="left"
            :title="equipment.Quiver.Name"
            alt="Card image cap" />
    </div>
    <context-menu id="context-menu" @ctx-open="onCtxOpen" ref="ctxMenu">
      <li class="ctx-item" @click="unequip($event, item)">Unequip</li>
    </context-menu>
</div>
</template>

<script>
import contextMenu from 'vue-context-menu'

export default {
  name: 'character-equip-card',
  props: ['character'],
  data() {
    return {
      item: {}
    }
  },
  computed: {
    equipment() {
      return this.character.Equipment || { };
    }
  },
  watch: {
    equipment(val) {
      $(function () {
        $('[data-toggle="tooltip"]').tooltip();
      });
    }
  },
  methods: {
    onCtxOpen(locals) {
      this.item = locals
    },
    displayDamage(damage) {
      return `Damage: ${damage}`
    },
    displayAC(ac) {
      return `AC: ${ac}`
    },
    async unequip($event, item) {
      let payload = {
        characterId: this.character.CharacterId,
        slot: item.Slot
      };
      await this.$store.dispatch('unequipItem', payload);
    }
  },
  components: {
    contextMenu
  }
}
</script>

<style lang="scss" scoped>
.character-equip {
  background-color: white;
  display: flex;
  height: 80%;
  width: 80% ;
}

.card-img-top {
    height: 100%;
    width: 100% ;
}

.equipped {
    height: 100%;
    width: 100% ;
    border: 4px solid #a1887f;
    box-sizing: border-box;
    border-radius: 10px;
}

.helm {
    position: absolute;
    height: 15%;
    width: 19.5%;
    left: 39.5%;
    top: 4%;
}

.necklace {
    position: absolute;
    height: 12.5%;
    width: 16.5%;
    left: 64.5%;
    top: 14%;
}

.chest {
    position: absolute;
    height: 26%;
    width: 24.5%;
    left: 37%;
    top: 19.5%;
}

.gauntlets {
    position: absolute;
    height: 19.5%;
    width: 19.5%;
    left: 8%;
    top: 31.5%;
}

.leftring {
    position: absolute;
    height: 9.5%;
    width: 12.5%;
    left: 11.5%;
    top: 53.5%;
}

.rightring {
    position: absolute;
    height: 9.5%;
    width: 12.5%;
    left: 75%;
    top: 53.5%;
}

.legs {
    position: absolute;
    height: 19.5%;
    width: 20%;
    left: 39.5%;
    top: 54.5%;
}

.boots {
    position: absolute;
    height: 19.5%;
    width: 20%;
    left: 39.5%;
    top: 75%;
}

.mainhand {
    position: absolute;
    height: 29%;
    width: 19.5%;
    left: 8%;
    top: 66%;
}

.offhand {
    position: absolute;
    height: 29%;
    width: 19.5%;
    left: 71.5%;
    top: 66%;
}

.quiver {
    position: absolute;
    height: 19.5%;
    width: 19.5%;
    left: 15.5%;
    top: 9.5%;
}


.equipment:hover {
    border: 1px solid black;
    box-sizing: border-box;
    border-radius: .5em;
    box-shadow: 0 0 15px 5px rgba(0,0,0,0.75);
}

</style>
