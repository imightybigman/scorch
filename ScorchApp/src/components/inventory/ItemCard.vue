<template>
    <div class="item-card border">
            <div class="item-card-inner">
                <h4 class="item-card-header">{{item.Name ? item.Name : "Item Card"}}</h4>
                <small>{{item.Description}}</small>

            </div>
            <!-- <div class="filter-window">
                sup
            </div> -->
    </div>
    
</template>

<script>

export default {
    name : 'item-card',
    props: ['item']
}
</script>

<style lang="scss" scoped>
    div {
        box-sizing: border-box;
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
        flex:1;
    }
</style>