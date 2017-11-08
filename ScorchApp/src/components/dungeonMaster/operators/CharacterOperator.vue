<template>
    <div class="dm-character-operator">
        <form>
            <div class = "d-flex">
                <div class="form-group">
                    <label for="modify-health">Modify Health : </label>
                    <input type="number" class="form-control" id="modify-health" v-model="deltaHealth" placeholder="Hp Change" autocomplete="off"/>
                </div>
                <div class="form-group">
                    <label for="modify-exp">Modify Exp : </label>
                    <input type="number" class="form-control" id="modify-exp" v-model="deltaExp" placeholder="Exp Change" autocomplete="off"/>
                </div>
            </div>
            <div class = "d-flex">
                <div class="form-group">
                    <label for="modify-gp">Modify Gold : </label>
                    <input type="number" class="form-control" id="modify-gold" v-model="deltaGold" placeholder="Gold Change" autocomplete="off"/>
                </div>
                <div class="form-group">
                    <label for="item-quantity">Items Quantity : </label>
                    <input type="number" class="form-control" id="item-quantity" v-model="itemQty" placeholder="# Items" autocomplete="off"/>
                </div>
            </div>
            <button class="btn btn-warning" @click="apply">Submit</button>
        </form>
    </div>
</template>

<script>
    import { CharacterService } from 'services'

export default {
    name: 'dm-character-operator',
    data(){
        return {
            deltaHealth : 0,
            deltaExp : 0,
            deltaGold : 0,
            itemQty: 1
        }
    },
    props: ['characterList', 'item'],
    methods: {
        async apply() {
            for(let char of this.characterList)
            {
                let payload = {};
                payload.body = {};
                payload.characterId = char.CharacterId;

                let newHealth = char.Hp + parseInt(this.deltaHealth);
                newHealth = newHealth > char.MaxHp ? char.MaxHp : newHealth;
                newHealth = newHealth < 0 ? 0 : newHealth;
                payload.body.Hp = newHealth;
                if (this.deltaHealth > 0) {
                  this.logAction(char.Firstname + " " + char.Lastname + " has gained/taken " + this.deltaHealth + " HP.");
                }

                let newExp = char.Exp + parseInt(this.deltaExp);
                newExp = newExp < 0 ? 0 : newExp;
                payload.body.Exp = newExp;
                if (this.deltaExp > 0) {
                  this.logAction(char.Firstname + " " + char.Lastname + " has gained " + this.deltaExp + " XP.");
                }

                let newGold = char.Gold + parseInt(this.deltaGold);
                newGold = newGold< 0 ? 0: newGold;
                payload.body.Gold = newGold;
                if (this.deltaGold > 0) {
                  this.logAction(char.Firstname + " " + char.Lastname + " has gained/paid " + this.deltaGold + " Gold.");
                }

                await this.$store.dispatch('updateCharacter', payload);
                if(this.item && this.itemQty > 0){
                    let itemAdded = {};
                    itemAdded.ItemId = this.item.ItemId;
                    itemAdded.Count = parseInt(this.itemQty);
                    await CharacterService.postCharacterItem(char.CharacterId, itemAdded);
                }
            };
            this.$socket.emit('updateParty');
            this.clearFields();
        },
        clearFields() {
            this.itemQty = 0;
            this.itemQty = 1;
            this.deltaExp = 0;
            this.deltaHealth = 0;
        },
        logAction(message) {
            this.$socket.emit('newLog', message);
        }
    }
}
</script>

<style lang="scss" scoped>
    .dm-character-operator {
        margin: 1%;
        flex-direction: column;
    }
    .form-group{
        flex: 1;
        margin-right: 1%;
    }
    input{
        background-color: #E8E8E8
    }
</style>
