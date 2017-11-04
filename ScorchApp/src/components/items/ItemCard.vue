<template>
    <div class="item-card border">
        <div class="item-card-inner">
            <div class="d-flex">
                <h4 class="item-card-header">{{item.Name ? item.Name : "Item Card"}} <span v-if="item.Count > 0">x {{item.Count}}</span></h4>
                <small>{{item.ItemClass}}</small>
            </div>
            <div class = "d-flex item-card-detail">
                <small class = "description">{{item.Description}}</small>
                <div class = "d-flex">
                    <span class = "entry"><i class="ra ra-gold-bar"/> {{item.Cost}} GP</span>
                    <span class = "entry"><i class="fa fa-balance-scale"/> {{item.Weight}} lbs </span>
                    <span class = "entry"><i class="ra ra-gears"/> {{item.ItemType}}</span>
                </div>
                <div class = "d-flex" v-if="item.ItemClass === 'Weapon'">
                    <span class = "entry"><i class="ra ra-axe-swing"/> {{item.Damage}}</span>
                    <span class = "entry"><i class="ra ra-gear-hammer"/> {{item.DamageType}}</span>
                    <span class = "entry"><i class="ra ra-hand"/> {{item.Slot}}</span>
                </div>
                <div class = "d-flex" v-if="item.ItemClass === 'Weapon' && item.LongRange > 0 && item.ShortRange > 0">
                    <span class = "entry"><i class="ra ra-broadhead-arrow"/> {{item.ShortRange}} ft</span>
                    <span class = "entry"><i class="ra ra-arrow-flights"/> {{item.LongRange}} ft</span>
                    <span class = "entry"></span>
                </div>
                
                <div class = "d-flex" v-if="item.ItemClass === 'Armor'">
                    <span class = "entry"><i class="ra ra-shield"/> {{item.AC}} AC</span>
                    <span class = "entry"><i class="ra ra-hand"/> {{item.Slot}}</span>
                    <span class = "entry"></span>
                </div>
                <div class = "d-flex" v-if="item.ItemClass === 'Quiver'">
                    <span class = "entry"><i class="ra ra-hand"/> {{item.Slot}}</span>
                </div>
                <div class="property-holder">
                    <span class="badge badge-pill badge-primary" v-for="(prop, index) in itemPropStatMods" :key="index">{{prop}}</span>
                </div>
            </div>
        </div>
    </div>
    
</template>

<script>

export default {
    name : 'item-card',
    props: ['item'],
    computed : {
        itemPropStatMods (){
            let result = [];
            if(this.item && this.item.StatModifiers){
                this.item.StatModifiers.forEach(mod => {
                    let stringBuilder = mod.Value >= 0 ? '+' : '-';
                    stringBuilder += mod.Value;
                    stringBuilder += ' ' + mod.Mod;
                    result.push(stringBuilder);
                });
            }
        
            return result.concat(this.item.Properties);
        }
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
    .item-card {
        margin: 1%;
        margin-top: 2%;
        padding: 1%;
        border-radius: 10px;
    }
    .item-card-inner {
        padding: 0.5%;
    }
    .item-card-header {
        flex:1 0 auto;
    }
    .item-card-detail {
        flex-direction: column;
    }
    .badge{
        margin-right: 1%;
    }
    .entry{
        margin-right: 5%;
        flex: 1;
    }
    .ra-gold-bar{
        color:gold;
    }
    .ra-axe-swing{
        color:darkred;
    }
</style>