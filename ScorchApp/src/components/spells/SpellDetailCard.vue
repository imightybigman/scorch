<template>
    <div class="spell-detail-card">
        <div class="spell-detail-card-inner">
            <div class="d-flex">
                <h4 class="spell-detail-card-header">{{spell.Name ? spell.Name : "Spell Details"}}</h4>
                <small>Level: {{ spell.Level }}</small>
            </div>
            <div class = "d-flex spell-detail-card-detail">
                <div class = "d-flex">
                    <span class = "entry"><i class="ra ra-fire-symbol"/> {{ spell.DamageType }}</span>
                    <span class = "entry"><i class="ra ra-lightning-bolt"/> {{ spell.Damage }}</span>
                    <span class = "entry"><i class="ra ra-archery-target"/> {{ spell.Range }}</span>
                </div>
                <small class = "description">{{ spell.Description }}</small>

            </div>
        </div>
    </div>
    
</template>

<script>

export default {
    name : 'spell-detail-card',
    props: ['spell'],
    computed : {

    }
}
</script>

<style lang="scss" scoped>
    div {
        box-sizing: border-box;
    }
    .description{
        padding-bottom: 1%;
    }
    .spell-detail-card {
        margin: 1%;
        margin-top: 2%;
        padding: 1%;
        border-radius: 10px;
    }
    .spell-detail-card-inner {
        padding: 0.5%;
    }
    .spell-detail-card-header {
        flex:1 0 auto;
    }
    .spell-detail-card-detail {
        flex-direction: column;
    }
    .badge{
        margin-right: 1%;
    }
    .entry{
        margin-right: 5%;
        flex: 1;
    }
    .ra-fire-symbol{
        color:darkred;
    }
</style>