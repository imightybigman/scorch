<template>
<div class="character-tile list-group">
  <a class="list-group-item list-group-item-action flex-column align-items-start">
    <div class="d-flex flex-row w-100 justify-content-between">
        <div class="d-flex flex-column icon align-items-center">
            <h5 class="level">Lv. {{ this.character.Level }}</h5>
            <img :class="classIcon" src="~assets/icons/class-icons.jpg">
      </div>
      <div class="d-flex flex-column character-stats">
        <div class="d-flex justify-content-between">
        <h5>{{ name }}</h5>
        <span><b><i class="ra ra-gold-bar"/> {{gold}} GP</b></span>
        </div>
        <hp-bar :character="character"></hp-bar>
        <exp-bar :character="character"></exp-bar>
      </div>
    </div>
  </a>
</div>
</template>

<script>
import ExpBar from './ExpBar'
import HpBar from './HpBar'

export default {
    name: 'character-tile',
    props: ['character'],
    computed: {
        name() {
            let firstName = this.character.Firstname || '';
            let lastName = this.character.Lastname || '';
            return `${firstName} ${lastName}`;
        },
        classIcon() {
            return this.character.Class.toLowerCase();
        },
        gold() {
            return this.character.Gold;
        }
    }, 
    components: {
        ExpBar,
        HpBar
    }
}
</script>

<style lang="scss" scoped>
.character-tile {
    flex: 1 0;
}

.router-link-active {
    z-index: 2;
    color: white;
    background-color: #03a9f4 ;
    border-color: #03a9f4 ;
}
img {
  object-fit: none;
  object-position: 0 0;
  width: 60px;
  height: 60px;
  margin: 1% 0;
}

.character-stats {
    flex: auto;
}

.icon {
    margin-right: 10%;
}

.fighter {
    object-position: -60px 0;
}

.bard {
    object-position: -60px -120px;
}

.ranger {
    object-position: -120px -60px;
}

.warlock {
    object-position: -60px -60px;
}

.paladin {
    object-position: -180px -60px;
}

.level {
    font-weight: bolder;
}
.ra-gold-bar{
    color:gold;
}
</style>