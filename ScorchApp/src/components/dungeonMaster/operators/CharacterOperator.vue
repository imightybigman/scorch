<template>
    <div class="dm-character-operator">
        <form v-on:submit="apply" class="">
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
            <button class="btn btn-primary">Submit</button>
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
            itemQty: 0
        }
    },
    props: ['characterList', 'item'],
    methods: {
        async apply() {
            this.characterList.forEach(async(char) =>
            {
                let payload = {};
                payload.body = {};
                payload.characterId = char.CharacterId;
                
                let newHealth = char.Hp + parseInt(this.deltaHealth);
                newHealth = newHealth > char.MaxHp ? char.MaxHp : newHealth;
                newHealth = newHealth < 0 ? 0 : newHealth;
                payload.body.Hp = newHealth;

                let newExp = char.Exp + parseInt(this.deltaExp);
                newExp = newExp < 0 ? 0 : newExp;
                payload.body.Exp = newExp;

                let newGold = char.Gold + parseInt(this.deltaGold);
                newGold = newGold< 0 ? 0: newGold;
                payload.body.Gold = newGold;
                
                await this.$store.dispatch('updateCharacter', payload);

                if(this.item && this.itemQty > 0){
                    let itemAdded = {};
                    itemAdded.ItemId = this.item.ItemId;
                    itemAdded.Count = parseInt(this.itemQty);
                    await CharacterService.postCharacterItem(char.CharacterId, itemAdded);
                }

                this.$socket.emit('updateParty');
            });
            this.clearFields();
        },
        async clearFields() {
            this.itemQty = 0;
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

</style>