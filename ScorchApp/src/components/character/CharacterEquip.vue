<template>
  <div class="character-equipment">
  <div class="card">
    <img class="card-img-top" v-if="character.Sex == 'Male'" src="~assets/dnd-male.jpg" alt="Card image cap">
    <img class="card-img-top" v-else src="~assets/dnd-female.jpg" alt="Card image cap">
    <div class="equipment helm"></div>
    <div class="equipment necklace"></div>
    <div class="equipment chest"></div>
    <div class="equipment gauntlets"></div>    
    <div class="equipment legs"></div>
    <div class="equipment boots"></div>
    <div class="equipment leftring"></div>
    <div class="equipment rightring"></div>
    <div class="equipment mainhand"></div>
    <div class="equipment offhand"></div>
    <div class="equipment quiver"></div>

</div>
  </div>
</template>

<script>
export default {
  name: 'character-equip-card',
  props: ['character'],
  computed: {

  }
}
</script>

<style lang="scss" scoped>
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
    border: 4px solid black;
    box-sizing: border-box;
    border-radius: .5em;
    box-shadow: 0 0 15px 5px rgba(0,0,0,0.75);

}

</style>
