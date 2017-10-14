<template>
<div class="character-tile list-group">
  <a class="list-group-item list-group-item-action flex-column align-items-start">
    <div class="d-flex flex-row w-100 justify-content-between">
        <div class="d-flex icon align-items-center">
          <img :class="classIcon" src="~assets/icons/class-icons.jpg">
      </div>
      <div class="d-flex flex-column character-stats">
        <div class="d-flex justify-content-between">
        <h5>{{ name }}</h5>
        <small class="level">Lv. {{ this.character.Level }}</small>
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
        name: function() {
            let firstName = this.character.Firstname || '';
            let lastName = this.character.Lastname || '';
            return `${firstName} ${lastName}`;
        },
        classIcon: function() {
            return this.character.Class.toLowerCase();
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
    padding: 1%;
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
    flex:1;
    flex-grow: 8;
}

.icon {
    flex: 1;
    flex-grow: 1;
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
</style>