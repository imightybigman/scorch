<template>
    <div>
        <div class="alert alert-success success-notification" id='success-weapon-msg'>
            <strong>Success Weapon Added!</strong>
        </div>
        <div class="alert alert-danger failure-notification" id="failure-weapon-msg">
            <strong>Error creating Item!</strong>
        </div>
        <div class="dm-weapon-creator border border-dark">
            <h4> Weapon </h4>
            <div class="weapon-form">
                <form v-on:submit="create">
                    <div class="form-group">
                        <label for="name">Name : </label>
                        <input type="text" class="form-control" id="name" v-model="name" placeholder="Name" autocomplete="off" required="true"/>
                    </div>
                    <div class="form-group">
                        <label for="description">Description : </label>
                        <input type="text" class="form-control" id="description" v-model="description" placeholder="Description" autocomplete="off" required="true"/>
                    </div>                
                    <div class="d-flex">
                        <div class="form-group numeric-entry">
                            <label for="damage">Damage : </label>
                            <input type="text" class="form-control" id="damage" v-model="damage" placeholder="Damage" autocomplete="off" required="true"/>
                        </div>
                        <div class="form-group numeric-entry">
                            <label for="slot">Slot : </label>
                            <select v-model="slot">
                                <option>OneHanded</option>
                                <option>TwoHanded</option>
                            </select>
                        </div>
                    </div>
                    
                    <div class="d-flex">
                        <div class="form-group numeric-entry">
                            <label for="damage-type">Damage Type : </label>
                            <input type="text" class="form-control" id="damage-type" v-model="damageType" placeholder="Damage Type" autocomplete="off" required="true"/>
                        </div>

                        <div class="form-group numeric-entry">
                            <label for="item-type">Item Type : </label>
                            <input type="text" class="form-control" id="item-type" v-model="itemType" placeholder="Item Type" autocomplete="off" required="true"/>
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
                    <div class="d-flex">
                        <div class="form-group numeric-entry">
                            <label for="short-range">Short Range : </label>
                            <div class="input-group">
                                <input type="text" class="form-control" id="short-range" v-model="shortRange" placeholder="Weight" autocomplete="off" required="true"/>
                                <span class="input-group-addon">ft</span>
                            </div>
                        </div>
                        <div class="form-group numeric-entry">
                            <label for="long-range">Long Range : </label>
                            <div class="input-group">
                                <input type="number" class="form-control" id="long-range" v-model="longRange" placeholder="Cost in gp" autocomplete="off" required="true"/>
                                <span class="input-group-addon">ft</span>
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
    name: 'dm-weapon-creator',
    data(){
        return {
            description : '',
            damageType: '',
            itemType : '',
            newProp: '',
            damage : '',
            name : '',
            slot : 'OneHanded',
            shortRange : 0,
            longRange : 0,
            weight : 0,
            cost : 0,
            statModifiers: [],
            properties: []
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
            body.ItemClass = 'Weapon';

            body.Name = this.name;
            body.Cost = this.cost;
            body.Slot = this.slot;
            body.Weight = this.weight;
            body.Damage = this.damage;
            body.ItemType = this.itemType;
            body.DamageType = this.damageType;
            body.Properties = this.properties;
            body.Description = this.description;
            body.StatModifiers = this.statModifiers;

            payload.body = body;
            await this.$store.dispatch('addItem', payload);
            if(this.$store.getters.error){
                console.log("Encountered an error during item creation : " + this.error);

                $('#success-weapon-msg').fadeIn(0);
                setTimeout(13000, new function(){
                    $('#success-weapon-msg').fadeOut(5000);
                });
            }
            else{
                this.clearFields();

                $('#success-weapon-msg').fadeIn(0);
                setTimeout(13000, new function(){
                    $('#success-weapon-msg').fadeOut(5000);
                });
            }
        },
        clearFields(){
            this.description = '';
            this.itemType = '';
            this.newProp = '';
            this.damage = '';
            this.name = '';
            this.slot = 'OneHanded';
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
    .dm-weapon-creator {
        margin: 1%;
        margin-top: 4%;
        padding: 1%;
        border-radius: 10px;
    }
    .weapon-form{
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
</style>