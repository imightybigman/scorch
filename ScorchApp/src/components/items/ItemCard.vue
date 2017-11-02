<template>
    <div class="item-card border">
        <div class="item-card-inner">
            <div class="d-flex">
                <h4 class="item-card-header">{{item.Name ? item.Name : "Item Card"}}</h4>
                <small>{{item.ItemClass}}</small>
            </div>
            <div class = "d-flex item-card-detail">
                <small class = "description">{{item.Description}}</small>
                <div>
                    <span class = "entry">Cost : {{item.Cost}} GP</span>
                    <span class = "entry">Weight : {{item.Weight}} lbs </span>
                    <span class = "entry">Item Type : {{item.ItemType}}</span>
                </div>
                <div v-if="item.ItemClass === 'Weapon'">
                    <span class = "entry">Damage : {{item.Damage}}</span>
                    <span class = "entry">DamageType : {{item.DamageType}}</span>
                    <span class = "entry">Slot : {{item.Slot}}</span>
                </div>
                <div v-if="item.ItemClass === 'Weapon' && item.LongRange > 0 && item.ShortRange > 0">
                    <span class = "entry">ShortRange : {{item.ShortRange}}</span>
                    <span class = "entry">LongRange : {{item.LongRange}}</span>
                </div>
                
                <div v-if="item.ItemClass === 'Armor'">
                    <span class = "entry">AC : {{item.AC}}</span>
                    <span class = "entry">Slot : {{item.Slot}}</span>
                </div>
                <div v-if="item.ItemClass === 'Quiver'">
                    <span class = "entry">Slot : {{item.Slot}}</span>
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
        min-height: 75%;
    }
    .item-card-inner {
        padding: 0.5%;
    }
    .item-card-header {
        flex:1;
    }
    .item-card-detail {
        flex-direction: column;
    }
    .badge{
        margin-right: 1%;
    }
    .entry{
        margin-right: 5%;
    }
</style>