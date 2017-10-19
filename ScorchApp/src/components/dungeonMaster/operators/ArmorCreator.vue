<template>
    <div>
        <div class="alert alert-success success-notification" id='success-armor-msg'>
            <strong>Success Armor Added!</strong>
        </div>
        <div class="alert alert-danger failure-notification" id="failure-armor-msg">
            <strong>Error creating Armor!</strong>
        </div>
        <div class="dm-armor-creator border border-dark">
            <h4> Armor </h4>
            <div class="armor-form">
                <form v-on:submit="create">
                    <div class="form-group">
                        <label for="name">Name : </label>
                        <input type="text" class="form-control" id="name" v-model="name" placeholder="Name" autocomplete="off" required="true"/>
                    </div>
                    <div class="form-group">
                        <label for="description">Description : </label>
                        <input type="text" class="form-control" id="description" v-model="description" placeholder="Description" autocomplete="off" required="true"/>
                    </div>                                    
                    <div class="form-group numeric-entry">
                        <label for="item-type">Item Type : </label>
                        <input type="text" class="form-control" id="item-type" v-model="itemType" placeholder="Item Type" autocomplete="off" required="true"/>
                    </div>
                    <div class="d-flex">
                        <div class="form-group numeric-entry">
                            <label for="armor-class">Armor (AC) : </label>
                            <input type="text" class="form-control" id="armor-class" v-model="armorClass" placeholder="Damage" autocomplete="off" required="true"/>
                        </div>
                        <div class="form-group numeric-entry selectSlot">
                            <label for="slot">Slot : </label>
                            <select v-model="slot">
                                <option>Chest</option>
                                <option>Bracer</option>
                                <option>Shoulders</option>
                                <option>Leggings</option>
                                <option>Boots</option>
                                <option>Helm</option>
                                <option>Gloves</option>
                            </select>
                        </div>
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
                                <span class="badge badge-pill badge-secondary">{{prop}}</span>
                            </div>
                        </div>
                        <div class="input-group">
                            <button class="btn btn-primary " type="button" v-on:click="addProp()"><b>+</b></button>                        
                            <input type="text" class="form-control" id="property-input" v-model="newProp" placeholder="Properties" autocomplete="off"/>
                        </div>
                    </div> 
                    <button class="btn btn-primary">Submit</button>                
                </form>
            </div>
        </div>

    </div>
</template>

<script>
export default {
    name: 'dm-armor-creator',
    data(){
        return {
            description : '',
            itemType : '',
            newProp: '',
            slot: 'Chest',
            name : '',
            armorClass : 0,
            weight : 0,
            cost : 0,
            statModifiers: [],
            properties: [],
            stealthAdvantage: false
        }
    },
    methods: {
        async addProp() {
            this.properties.push(this.newProp);
            this.newProp = '';
        },
        async create(){
            let payload = {};
            let body = {};
            body.ItemClass = 'Armor';

            body.Name = this.name;
            body.Cost = this.cost;
            body.Weight = this.weight;
            body.AC = this.armorClass;
            body.Slot = this.slot;
            body.ItemType = this.itemType;
            body.Properties = this.properties;
            body.Description = this.description;
            body.StatModifiers = this.statModifiers;
            body.StealthAdvantage = this.stealthAdvantage;

            payload.body = body;
            await this.$store.dispatch('addItem', payload);
            if(this.$store.getters.error){
                console.log("Encountered an error during item creation : " + this.error);

                $('#success-armor-msg').fadeIn(0);
                setTimeout(13000, new function(){
                    $('#success-armor-msg').fadeOut(5000);
                });
            }
            else{
                this.clearFields();

                $('#success-armor-msg').fadeIn(0);
                setTimeout(13000, new function(){
                    $('#success-armor-msg').fadeOut(5000);
                });
            }
        },
        clearFields(){
            this.description = '';
            this.itemType = '';
            this.newProp = '';
            this.damage = '';
            this.name = '';
            this.slot = 'Armor';
            this.shortRange = 0;
            this.longRange = 0;
            this.weight = 0;
            this.cost = 0;
            this.statModifiers = [];
            this.properties = [];
        }
    }
}
</script>

<style lang="scss" scoped>
    .dm-armor-creator {
        margin: 1%;
        margin-top: 4%;
        padding: 1%;
        border-radius: 10px;
    }
    .armor-form{
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
        flex:1;
        flex-grow:1;
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
</style>