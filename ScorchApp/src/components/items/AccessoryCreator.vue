<template>
    <div>
        <div class="alert alert-success success-notification" id='success-accessory-msg'>
            <strong>Success Item Added!</strong>
        </div>
        <div class="alert alert-danger failure-notification" id='failure-accessory-msg'>
            <strong>Error creating Item!</strong>
        </div>
        <div class="dm-acessory-creator border border-dark">
            <h4>Accessory</h4>
            <div class="accessory-form">
                <form v-on:submit="create">
                    <div class="form-group">
                        <label for="name">Name : </label>
                        <input type="text" class="form-control" id="name" v-model="name" placeholder="Name" autocomplete="off" required="true"/>
                    </div>
                    <div class="form-group">
                        <label for="description">Description : </label>
                        <textarea rows="4" class="form-control" id="description" v-model="description" placeholder="Description" autocomplete="off" required="true"/>
                    </div>
 
                    <div class="d-flex">
                        <div class="form-group numeric-entry">
                            <label for="item-type">Item Type : </label>
                            <input type="text" class="form-control" id="item-type" v-model="itemType" placeholder="Item Type" autocomplete="off" required="true"/>
                        </div>
                        <div class="form-group numeric-entry">
                            <label for="slot">Slot : </label>
                            <select class="form-control" v-model="slot">
                                <option>Ring</option>
                                <option>Necklace</option>
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
    name: 'dm-acessory-creator',
    props: ['accessory'],
    data(){
        return {
            description : this.accessory.Description || '',
            itemType : this.accessory.ItemType || '',
            newProp: '',
            name : this.accessory.Name || '',
            weight : this.accessory.Weight || 0,
            cost : this.accessory.Cost || 0,
            properties: this.accessory.Properties || [],
            slot: this.accessory.Slot || ''
        }
    },
    watch: {
      accessory: function () {
        this.description = this.accessory.Description;
        this.itemType = this.accessory.ItemType;
        this.name =  this.accessory.Name;
        this.weight = this.accessory.Weight;
        this.cost = this.accessory.Cost;
        this.properties = this.accessory.Properties;
        this.slot = this.accessory.Slot;
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
            body.ItemClass = 'Accessory';

            body.Description = this.description;
            body.Properties = this.properties;
            body.ItemType = this.itemType;
            body.Weight = this.weight;
            body.Cost = this.cost;
            body.Name = this.name;
            body.Slot = this.slot;

            payload.body = body;
            await this.$store.dispatch('addItem', payload);
            if(this.$store.getters.error){
                console.log("Encountered an error during item creation : " + this.error);

                $('#failure-accessory-msg').fadeIn(0);
                setTimeout(13000, () => {
                    $('#failure-accessory-msg').fadeOut(5000);
                });
            }
            else{
                this.clearFields();

                $('#success-accessory-msg').fadeIn(0);
                setTimeout(13000, () => {
                    $('#success-accessory-msg').fadeOut(5000);
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
            this.slot = '';
        }
    }
}
</script>

<style lang="scss" scoped>
    .dm-acessory-creator {
        margin: 1%;
        padding: 1%;
        border-radius: 10px;
    }
    .accessory-form{
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
