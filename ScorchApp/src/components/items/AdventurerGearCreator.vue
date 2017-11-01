<template>
    <div>
        <div class="alert alert-success success-notification" id='success-adv-gear-msg'>
            <strong>Success Item Added!</strong>
        </div>
        <div class="alert alert-danger failure-notification" id='failure-adv-gear-msg'>
            <strong>Error creating Item!</strong>
        </div>
        <div class="dm-adventurer-gear-creator border border-dark">
            <h4> Adventurer Gear </h4>
            <div class="adv-gear-form">
                <form v-on:submit="create">
                    <div class="form-group">
                        <label for="name">Name : </label>
                        <input type="text" class="form-control" id="name" v-model="name" placeholder="Name" autocomplete="off" required="true"/>
                    </div>
                    <div class="form-group">
                        <label for="description">Description : </label>
                        <textarea rows="4" class="form-control" id="description" v-model="description" placeholder="Description" autocomplete="off" required="true"/>
                    </div>
                    <div class="form-group">
                        <label for="item-type">Item Type : </label>
                        <input type="text" class="form-control" id="item-type" v-model="itemType" placeholder="Item Type" autocomplete="off" required="true"/>
                    </div>
                    <div class="d-flex">
                        <div class="form-group numeric-entry">
                            <label for="weight">Weight : </label>
                            <div class="input-group">
                                <input type="text" class="form-control" id="weight" v-model="weight" placeholder="Weight" autocomplete="off" required="true"/>
                                <span class="input-group-addon">lbs</span>
                            </div>
                        </div>
                        <div class="form-group numeric-entry">
                            <label for="cost">Cost : </label>
                            <div class="input-group">
                                <input type="number" class="form-control" id="cost" v-model="cost" placeholder="Cost in gp" autocomplete="off" required="true"/>
                                <span class="input-group-addon">gp</span>
                            </div>
                        </div>
                    </div>
                    <div class="properties">
                        <label class="property-label">Properties</label>
                        <div class="property-holder">
                            <div class="property-list-items" v-for="(prop, index) in properties" :key="index">
                                <span class="badge-small badge-pill badge-secondary">{{prop}}</span>
                            </div>
                        </div>
                        <div class="input-group">
                            <button class="btn btn-primary add-remove-btn" type="button" v-on:click="addProp()"><b>+</b></button>
                            <button class="btn btn-danger add-remove-btn" type="button" v-on:click="removeProp()"><b>-</b></button>
                            <input type="text" class="form-control" id="property-input" v-model="newProp" placeholder="Properties" autocomplete="off"/>
                        </div>
                    </div>
                    <button class="btn btn-primary">Submit</button>
                    <button class="btn btn-danger clear-button" type="button" v-on:click="clearFields()">Clear</button>
                </form>
            </div>
        </div>

    </div>
</template>

<script>
export default {
    name: 'dm-adventurer-gear-creator',
    props: ['gear'],
    data(){
        return {
            description : this.gear.Description || '',
            itemType : this.gear.ItemType || '',
            newProp: '',
            name : this.gear.Name || '',
            weight : this.gear.Weight || 0,
            cost : this.gear.Cost || 0,
            properties: this.gear.Properties || []
        }
    },
    watch: {
      gear: function () {
        this.description = this.gear.Description;
        this.itemType = this.gear.ItemType;
        this.name =  this.gear.Name;
        this.weight = this.gear.Weight;
        this.cost = this.gear.Cost;
        this.properties = this.gear.Properties;
      }
    },
    methods: {
        addProp() {
            let isPresent = this.properties.includes(this.newProp);
            if(this.newProp && !isPresent){
                this.properties.push(this.newProp);
                this.newProp = '';
            }
        },
        removeProp(){
            let index = this.properties.indexOf(this.newProp);
            if(index >= 0 && this.newProp){
                this.properties.splice(index, 1);
                this.newProp = '';
            } else {
                this.properties.pop();
            }
        },
        async create(){
            let payload = {};
            let body = {};
            body.ItemClass = 'AdventurerGear';

            body.Description = this.description;
            body.Properties = this.properties;
            body.ItemType = this.itemType;
            body.Weight = this.weight;
            body.Cost = this.cost;
            body.Name = this.name;

            payload.body = body;
            await this.$store.dispatch('addItem', payload);
            if(this.$store.getters.error){
                console.log("Encountered an error during item creation : " + this.error);

                $('#failure-adv-gear-msg').fadeIn(0);
                setTimeout(13000, new function(){
                    $('#failure-adv-gear-msg').fadeOut(5000);
                });
            }
            else{
                this.clearFields();

                $('#success-adv-gear-msg').fadeIn(0);
                setTimeout(13000, new function(){
                    $('#success-adv-gear-msg').fadeOut(5000);
                });
            }

        },
        clearFields(){
            this.name = '';
            this.description = '';
            this.itemType = '';
            this.cost = 0;
            this.weight = 0;
            this.properties = [];
            this.newProp = '';
        }
    }
}
</script>

<style lang="scss" scoped>
    .dm-adventurer-gear-creator {
        margin: 1%;
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
        font-size:medium;
    }
    .property-holder {
        padding:1%;
    }
    .numeric-entry {
        padding-right:2%;
    }
    .property-label {
        margin-bottom:1%;
    }
    .success-notification{
        display: none;
        position: absolute;
        width: 88%;
        margin-top: -4%;
    }
    .failure-notification{
        display: none;
        position: absolute;
        width: 88%;
        margin-top: -4%;
    }
    .clear-button{
        float: right;
    }
    .add-remove-btn{
        width: 10%;
    }
</style>
