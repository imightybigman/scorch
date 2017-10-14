<template>
    <div>
        Exp: 
        <div class="progress">
            <div 
                class="progress-bar" 
                role="progressbar" 
                aria-valuenow="100" 
                :style="progressWidth" 
                aria-valuemin="0" 
                aria-valuemax="100">{{ currentExp }}</div>
        </div>
    </div>
</template>

<script>
import LevelService from 'services/levelService.js'

export default {
    name: 'exp-bar',
    props: ['character'],
    computed: {
        progressWidth: function() {
            let expRange = LevelService.getExpRange(this.character.Level)

            console.log(this.character.Exp);
            return `width: ${this.character.Exp/expRange.max * 100}%`;
        },
        currentExp: function () {
            let expRange = LevelService.getExpRange(this.character.Level)
            return `${this.character.Exp}/${expRange.max}`;
        },
    }
}
</script>

<style lang="scss" scoped>

</style>