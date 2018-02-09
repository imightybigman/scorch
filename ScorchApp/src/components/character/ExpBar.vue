<template>
    <div class="d-flex exp-holder">
        <span class="exp-header">EXP</span> 
        <div class="progress">
            <div 
                class="progress-bar bg-warning" 
                role="progressbar" 
                aria-valuenow="100" 
                :style="progressWidth" 
                aria-valuemin="0" 
                aria-valuemax="100">
                <span class="exp-text">{{ currentExp }}</span>
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
        progressWidth() {
            let expRange = LevelService.getExpRange(this.character.Level);
            return `width: ${(this.character.Exp - expRange.min)/expRange.range * 100}%`;
        },
        currentExp() {
            let expRange = LevelService.getExpRange(this.character.Level);
            return `${this.character.Exp - expRange.min}/${expRange.range}`;
        },
    }
}
</script>

<style lang="scss" scoped>
.progress {
    position: relative;
    flex: 1;
}

.exp-text{
    font-family: Verdana, Geneva, Tahoma, sans-serif;
    font-weight: bolder;
}

.exp-holder{
    align-items: center;
}

.exp-header{
    margin-right: 2%;
}

.progress span {
    position: absolute;
    display: block;
    width: 100%;
    color: black;
 }
</style>