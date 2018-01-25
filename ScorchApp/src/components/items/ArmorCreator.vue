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
                        <textarea class="form-control" rows="4" id="description" v-model="description" placeholder="Description" autocomplete="off" required="true"/>
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
                        <div class="form-group numeric-entry">
                            <div>
                                <label for="slot">Slot : </label>
                            </div>
                            <select class="form-control" v-model="slot">
                                <option>Chest</option>
                                <option>Bracer</option>
                                <option>Shoulders</option>
                                <option>Leggings</option>
                                <option>Boots</option>
                                <option>Helm</option>
                                <option>Gloves</option>
                                <option>Shield</option>                                
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
                            <button class="btn btn-primary" type="button" v-on:click="addProp()"><b>+</b></button>
                            <button class="btn btn-danger" type="button" v-on:click="removeProp()"><b>-</b></button>
                            <input type="text" class="form-control" id="property-input" v-model="newProp" placeholder="Properties" autocomplete="off"/>
                        </div>
                    </div>
                    <div class="stat-modifiers">
                        <label class="stat-modifiers-label">Stat Modifiers</label>
                        <div class="stat-modifiers-holder">
                            <div class="stat-modifiers-list-items" v-for="(smod, index) in statModifiers" :key="index">
                                <span class="badge-small badge-pill badge-secondary">{{(smod.value > 0 ? "+" : "") + smod.value + " " + smod.mod}}</span>
                            </div>
                        </div>
                        <div class="input-group">
                            <button class="btn btn-primary " type="button" v-on:click="addStatMod()"><b>+</b></button>
                            <button class="btn btn-danger" type="button" v-on:click="removeStatMod()"><b>-</b></button>
                            <input type="number" class="form-control" id="stat-mod-input" v-model="newStatModAmount" placeholder="Stat Modifier" autocomplete="off"/>
                            <select class="form-control" v-model="newStatModStat">
                                <option>Strength</option>
                                <option>Dexterity</option>
                                <option>Wisdom</option>
                                <option>Intelligence</option>
                                <option>Charisma</option>
                                <option>Health</option>
                                <option>Proficiency</option>
                            </select>
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
    name: 'dm-armor-creator',
    props: ['armor'],
    currentArmor: [],
    data(){
        return {
            newStatModStat: 'Strength',
            description : this.armor.Description || '',
            itemType : this.armor.ItemType || '',
            slot: this.armor.Slot || 'Chest',
            newProp: '',
            name : this.armor.Name || '',
            newStatModAmount: 0,
            armorClass : this.armor.AC || 0,
            weight : this.armor.Weight || 0,
            cost : this.armor.Cost || 0,
            statModifiers: this.armor.statModifiers || [],
            properties: this.armor.Properties || [],
            stealthAdvantage: this.armor.StealthAdvantage || false
        }
    },
    watch: {
      armor: function () {
        this.clearFields();
        this.description = this.armor.Description;
        this.itemType = this.armor.ItemType;
        this.slot = this.armor.Slot;
        this.name = this.armor.Name;
        this.armorClass = this.armor.AC;
        this.weight = this.armor.Weight;
        this.cost = this.armor.Cost;
        this.statModifiers = this.armor.statModifiers;
        this.properties = this.armor.Properties;
        this.stealthAdvantage = this.armor.StealthAdvantage;
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
        removeStatMod(){
            if(this.newStatModStat){
                let index = this.statModifiers.findIndex(statMod => statMod.mod == this.newStatModStat);
                if(index >= 0){
                    this.statModifiers.splice(index, 1);
                }
            }
        },
        addStatMod() {
            let updateStat = this.statModifiers.find(statMod => statMod.mod == this.newStatModStat);
            if(updateStat)
                this.removeStatMod();

            if(this.newStatModStat && this.newStatModAmount != 0){
                let statModBuilder = {};

                statModBuilder.value = this.newStatModAmount;
                statModBuilder.mod = this.newStatModStat;
                this.statModifiers.push(statModBuilder);
                this.newStatModAmount = 0;
            }
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
                setTimeout(13000, () => {
                    $('#success-armor-msg').fadeOut(5000);
                });
            }
            else{
                this.clearFields();

                $('#success-armor-msg').fadeIn(0);
                setTimeout(13000, () => {
                    $('#success-armor-msg').fadeOut(5000);
                });
            }
        },
        clearFields(){
            this.newStatModStat = '';
            this.description = '';
            this.itemType = '';
            this.newProp = '';
            this.damage = '';
            this.name = '';
            this.slot = 'Chest';
            this.newStatModAmount = 0;
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
        padding: 1%;
        border-radius: 10px;
    }
    .armor-form{
        margin : 3%;
    }
    .properties{
        margin-bottom: 3%;
    }
    .stat-modifiers{
        margin-bottom: 3%;
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
    .clear-button{
        float: right;
    }
</style>