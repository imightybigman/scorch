<template>
    <div class="d-flex hp-holder">
        <span class="hp-header">HP</span> 
        <div class="progress">
          <div v-if="overHealth > 0"
            class="progress-bar bg-info" 
            role="progressbar" 
            aria-valuenow="100" 
            :style="overHealthWidth" 
            aria-valuemin="0" 
            aria-valuemax="100">
            <span class="hp-text">{{overHealth}}</span>
          </div>
          <div :class="progressBarType" 
                role="progressbar" 
                aria-valuenow="100" 
                :style="progressWidth" 
                aria-valuemin="0" 
                aria-valuemax="100">
                <span class="hp-text">{{currentHp}}</span>
              </div>
        </div>
    </div>
</template>

<script>
    export default {
      name: 'hp-bar',
      props: ['character'],
      computed: {
        overHealth() {
          return this.character.Hp - this.character.MaxHp;
        },
        overHealthWidth() {
          if(this.overHealth < 0) {
            return 'width: 0%';
          }
          return `width: ${this.overHealth/this.character.MaxHp * 100}%`;
        },
        progressWidth() {
          return `width: ${this.character.Hp/this.character.MaxHp * 100}%`;
        },
        currentHp() {
          return `${this.character.Hp}/${this.character.MaxHp}`;
        },
        progressBarType() {
          let percentage = this.character.Hp / this.character.MaxHp * 100
          if (percentage < 30) {
            return 'progress-bar bg-danger'
          } 
          else if (percentage >= 30 && percentage < 50) {
            return 'progress-bar bg-warning';
          } 
          else {
            return 'progress-bar bg-success'
          }
        }
      }
    }
</script>

<style lang="scss" scoped>
.progress {
    position: relative;
    flex: 1;  
}

.hp-header{
    margin-right: 5%;
}

.hp-text{
    font-family: Verdana, Geneva, Tahoma, sans-serif;
    font-weight: bolder;
}

.hp-holder{
    align-items: center;
}

.progress span {
    display: block;
    width: 100%;
    color: black;
 }
</style>