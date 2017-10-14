<template>
    <div>
        Exp: 
        <div class="progress">
          <div :class="progressBarType" 
                role="progressbar" 
                aria-valuenow="100" 
                :style="progressWidth" 
                aria-valuemin="0" 
                aria-valuemax="100">{{currentHp}}</div>
        </div>
    </div>
</template>

<script>
    export default {
      name: 'hp-bar',
      props: ['character'],
      computed: {
        progressWidth: function () {
          return `width: ${this.character.Hp/this.character.MaxHp * 100}%`;
        },
        currentHp: function () {
          return `${this.character.Hp}/${this.character.MaxHp}`;
        },
        progressBarType: function () {
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

</style>