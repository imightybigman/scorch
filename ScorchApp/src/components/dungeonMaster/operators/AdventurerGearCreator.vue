<template>
    <div class="dm-adventurer-gear-creator border border-dark">
        <h4> Adventurer Gear </h4>
        <div class="adv-gear-form">
            <form v-on:submit="create">
                <div class="form-group">
                    <label for="name">Name : </label>
                    <input type="text" class="form-control" id="name" v-model="name" placeholder="Name" autocomplete="off"/>
                </div>
                <div class="form-group">
                    <label for="description">Description : </label>
                    <input type="text" class="form-control" id="description" v-model="description" placeholder="Description" autocomplete="off"/>
                </div>
                <div class="form-group">
                    <label for="item-type">Item Type : </label>
                    <input type="text" class="form-control" id="item-type" v-model="itemType" placeholder="Item Type" autocomplete="off"/>
                </div>
                <div class="d-flex">
                    <div class="form-group numeric-entry">
                        <label for="weight">Weight : </label>
                        <div class="input-group">
                            <input type="text" class="form-control" id="weight" v-model="weight" placeholder="Weight" autocomplete="off"/>
                            <span class="input-group-addon">lbs</span>
                        </div>
                    </div>
                    <div class="form-group numeric-entry">
                        <label for="cost">Cost : </label>
                        <div class="input-group">
                            <input type="number" class="form-control" id="cost" v-model="cost" placeholder="Cost in gp" autocomplete="off"/>
                            <span class="input-group-addon">gp</span>
                        </div>
                    </div>
                </div>
                <div class="properties">
                    <label class="property-label"> Properties </label>
                    <div class="property-holder">
                        <div class="property-list-items" v-for="(prop, index) in properties" :key="index">
                            <!-- <li class="list-group-item"><b>{{prop}}</b></li> -->
                            <span class="badge badge-pill badge-default">{{prop}}</span>
                        </div>
                    </div>
                    <div class="input-group">
                        <button class="btn btn-primary " type="button" v-on:click="addProp()"><b>+</b></button>                        
                        <input type="text" class="form-control" id="properties" v-model="newProp" placeholder="Properties" autocomplete="off"/>
                    </div>
                </div> 
                <button class="btn btn-primary">Submit</button>                
            </form>
        </div>
    </div>
</template>

<script>
export default {
    name: 'dm-adventurer-gear-creator',
    data(){
        return {
            name : "",
            description : "",
            itemType : "",
            cost : 0,
            properties: [],
            newProp: "",
            weight : 0
        }
    },
    methods: {
        async addProp() {
            this.properties.push(this.newProp);
        },
        async create(){
            //TODO implement
        }
    }
}
</script>

<style lang="scss" scoped>
    .dm-adventurer-gear-creator {
        margin: 1%;
        margin-top: 4%;
        padding: 1%;
        border-radius: 10px;
    }
    .adv-gear-form{
        margin : 3%;
    }
    .properties{
        margin-bottom: 5%;
    }
    .property-list-items {
        float:left;
    }
    .property-holder {
        padding:1%;
    }   
    .numeric-entry {
        padding-right:2%;
        // padding-right:2%;
    }
    .property-label {
        margin-bottom:1%;
    }
    .badge{
        background-color: grey;
    }
</style>