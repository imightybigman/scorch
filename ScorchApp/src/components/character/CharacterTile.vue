<template>
    <div class="character-tile list-group">
        <a class="list-group-item list-group-item-action flex-column align-items-start">
            <div class="d-flex w-100 justify-content-between">
                <h4>{{ name }}</h4>
                <small>Lv. {{ this.character.Level }}</small>
            </div>
            <div class="icons">
                <img :class="classIcon" src="~assets/icons/class-icons.jpg">            
            </div>
            <div class="progress">
                <div 
                    :class="progressBarType" 
                    role="progressbar" 
                    aria-valuenow="100" 
                    :style="progressWidth" 
                    aria-valuemin="0" 
                    aria-valuemax="100">{{currentHp}}</div>
            </div>
        </a>
    </div>
</template>

<script>
export default {
    name: 'character-tile',
    props: ['character'],
    computed: {
        name: function() {
            let firstName = this.character.Firstname || '';
            let lastName = this.character.Lastname || '';
            return `${firstName} ${lastName}`;
        },
        progressWidth: function() {
            return `width: ${this.character.Hp/this.character.MaxHp * 100}%`;
        },
        currentHp: function() {
            return `${this.character.Hp}/${this.character.MaxHp}`;
        },
        progressBarType: function() {
            let percentage = this.character.Hp/this.character.MaxHp * 100
            if(percentage < 30) {
                return 'progress-bar bg-danger'
            }
            else if(percentage >=30 && percentage < 50)
            {
                return 'progress-bar bg-warning';
            }
            else {
                return 'progress-bar bg-success'
            }
        },
        classIcon: function() {
            return this.character.Class.toLowerCase();
        }
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