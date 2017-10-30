<template>
    <div>
        Exp: 
        <div class="progress">
            <div 
                class="progress-bar bg-warning" 
                role="progressbar" 
                aria-valuenow="100" 
                :style="progressWidth" 
                aria-valuemin="0" 
                aria-valuemax="100">
                <span>{{ currentExp }}</span>
            </div>
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
            return `width: ${this.character.Exp/expRange.max * 100}%`;
        },
        currentExp: function () {
            let expRange = LevelService.getExpRange(this.character.Level)
            if(this.character.Exp > expRange.max) {
                this.$emit('levelup');
            }
            return `${this.character.Exp}/${expRange.max}`;
        },
    }
}
</script>

<style lang="scss" scoped>
.progress {
    position: relative;
}

.progress span {
    position: absolute;
    display: block;
    width: 100%;
    color: black;
 }
</style>