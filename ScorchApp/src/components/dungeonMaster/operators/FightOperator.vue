<template>
    <div class="dm-fight-operator">
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
            </div>
            <button class="btn btn-warning" @click="apply">Submit</button>
        </form>
        <button class="btn btn-primary" @click="resetInit()">Fight Over</button>
    </div>
</template>

<script>
    import { CharacterService } from 'services'

export default {
    name: 'dm-fight-operator',
    data(){
        return {
            deltaHealth : 0,
            deltaExp : 0,
            deltaGold : 0,
        }
    },
    props: ['characterList'],
    methods: {
        async apply() {
            for(let char of this.characterList)
            {
                let payload = {};
                payload.body = {};
                payload.characterId = char.CharacterId;

                let newHealth = char.Hp + parseInt(this.deltaHealth);
                if(!this.isTempHp)
                    newHealth = newHealth > char.MaxHp ? char.MaxHp : newHealth;

                newHealth = newHealth < 0 ? 0 : newHealth;
                payload.body.Hp = newHealth;
                if (parseInt(this.deltaHealth) !== 0) {
                    if (this.deltaHealth > 0 ) {
                        await this.$logging.notify({user: char.CharacterId, type: "success", message: "You gained " + this.deltaHealth + " HP."});
                    } else {
                        await this.$logging.notify({user: char.CharacterId, type: "warning", message: "You lost " + this.deltaHealth + " HP."});
                    }
                }

                let newExp = char.Exp + parseInt(this.deltaExp);
                newExp = newExp < 0 ? 0 : newExp;
                payload.body.Exp = newExp;
                if (parseInt(this.deltaExp) !== 0) {
                    if (this.deltaExp > 0 ) {
                        await this.$logging.notify({user: char.CharacterId, type: "success", message: "You gained " + this.deltaExp + " experience."});
                    } else {
                        await this.$logging.notify({user: char.CharacterId, type: "warning", message: "You lost " + this.deltaExp + " experience."});
                    }
                }

                let newGold = char.Gold + parseInt(this.deltaGold);
                newGold = newGold< 0 ? 0: newGold;
                payload.body.Gold = newGold;
                if (parseInt(this.deltaGold) !== 0) {
                    if (this.deltaGold > 0 ) {
                        await this.$logging.notify({user: char.CharacterId, type: "success", message: "You gained " + this.deltaGold + " gold."});
                    } else {
                        await this.$logging.notify({user: char.CharacterId, type: "warning", message: "You lost " + this.deltaGold + " gold."});
                    }
                }

                if(this.maxHealth > 0){
                    payload.body.MaxHp = parseInt(this.maxHealth);
                }

                await this.$store.dispatch('updateCharacter', payload);
            };
            this.$logging.update();
            this.clearFields();
        },
        clearFields() {
            this.deltaGold = 0;
            this.deltaExp = 0;
            this.deltaHealth = 0;
        },
        resetInit() {
          this.$logging.resetInit();
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
