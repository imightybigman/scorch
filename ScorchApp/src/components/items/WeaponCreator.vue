<template>
    <div>
        <div class="alert alert-success success-notification" id='success-weapon-msg'>
            <strong>Success Weapon Added!</strong>
        </div>
        <div class="alert alert-success success-notification" id='update-weapon-msg'>
            <strong>Success Weapon Updated!</strong>
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
                        <textarea rows="4" class="form-control" id="description" v-model="description" placeholder="Description" autocomplete="off" required="true"/>
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
                            <label for="damage">Damage : </label>
                            <input type="text" class="form-control" id="damage" v-model="damage" placeholder="Damage" autocomplete="off" required="true"/>
                        </div>
                        <div class="form-group numeric-entry">
                            <label for="slot">Slot : </label>
                            <select class="form-control" v-model="slot">
                                <option>One-Handed</option>
                                <option>Two-Handed</option>
                                <option>OffHand</option>                                
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
                                <span class="badge-small badge-pill badge-secondary">{{prop}}</span>
                            </div>
                        </div>
                        <div class="input-group">
                            <button class="btn btn-primary" type="button" @click="addProp"><b>+</b></button>
                            <button class="btn btn-danger" type="button" @click="removeProp"><b>-</b></button>
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
                            <button class="btn btn-primary " type="button" @click="addStatMod"><b>+</b></button>
                            <button class="btn btn-danger" type="button" @click="removeStatMod"><b>-</b></button>
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
                    <button class="btn btn-primary" @click="update">Update</button>
                    <button class="btn btn-danger clear-button" type="button" @click="clearFields">Clear</button>
                </form>
            </div>
        </div>

    </div>
</template>

<script>
export default {
    name: 'dm-weapon-creator',
    props: ['weapon'],
    data(){
        return {
            newStatModStat: 'Strength',
            description : this.weapon.Description || '',
            damageType: this.weapon.DamageType || '',
            itemType : this.weapon.ItemType || '',
            newProp: '',
            damage : this.weapon.Damage || '',
            name : this.weapon.Name || '',
            slot : this.weapon.Slot || 'One-Handed',
            newStatModAmount: 0,
            shortRange : this.weapon.ShortRange || 0,
            longRange : this.weapon.LongRange || 0,
            weight : this.weapon.Weight || 0,
            cost : this.weapon.Cost || 0,
            statModifiers: this.weapon.StatModifiers || [],
            properties: this.weapon.Properties || [],
            itemId: this.weapon.ItemId || ''
        }
    },
    watch: {
      weapon: function () {
        console.log(this.weapon);
        this.clearFields();
        this.newStatModStat = 'Strength',
        this.description = this.weapon.Description;
        this.damageType = this.weapon.DamageType;
        this.itemType = this.weapon.ItemType;
        this.newProp = '';
        this.damage = this.weapon.Damage;
        this.name = this.weapon.Name;
        this.slot = this.weapon.Slot;
        this.newStatModAmount = 0;
        this.shortRange = this.weapon.ShortRange;
        this.longRange = this.weapon.LongRange;
        this.weight = this.weapon.Weight;
        this.cost = this.weapon.Cost;
        this.statModifiers = this.weapon.StatModifiers;
        this.properties = this.weapon.Properties;
        this.itemId = this.weapon.ItemId;
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
            body.ItemClass = 'Weapon';

            body.Name = this.name;
            body.Cost = this.cost;
            body.Slot = this.slot;
            body.Weight = this.weight;
            body.Damage = this.damage;
            body.ItemType = this.itemType;
            body.DamageType = this.damageType;
            body.ShortRange = this.shortRange;
            body.LongRange = this.longRange;
            body.Properties = this.properties;
            body.Description = this.description;
            body.StatModifiers = this.statModifiers;

            payload.body = body;
            await this.$store.dispatch('addItem', payload);
            if(this.$store.getters.error){
                console.log("Encountered an error during item creation : " + this.error);

                $('#success-weapon-msg').fadeIn(0);
                setTimeout(13000, () => {
                    $('#success-weapon-msg').fadeOut(5000);
                });
            }
            else{
                this.clearFields();

                $('#success-weapon-msg').fadeIn(0);
                setTimeout(13000, () => {
                    $('#success-weapon-msg').fadeOut(5000);
                });
            }
        },
        async update() {
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
          body.ShortRange = this.shortRange;
          body.LongRange = this.longRange;
          body.Properties = this.properties;
          body.Description = this.description;
          body.StatModifiers = this.statModifiers;
          body.ItemId = this.itemId;

          payload.body = body;
          await this.$store.dispatch('updateInventory', payload);

          if(this.$store.getters.error){
              console.log("Encountered an error during item update : " + this.error);

              $('#success-weapon-msg').fadeIn(0);
              setTimeout(13000, () => {
                  $('#success-weapon-msg').fadeOut(5000);
              });
          }
          else{
              this.clearFields();

              $('#update-weapon-msg').fadeIn(0);
              setTimeout(13000, () => {
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
            this.slot = 'One-Handed';
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
        flex: 1;
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
    .stat-modifiers{
        margin-bottom: 3%;
    }
</style>