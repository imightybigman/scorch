<template>
    <div class="dm-character-operator">
        <form v-on:submit="apply">
            <div class="form-group">
                <label for="modify-health">Modify Health : </label>
                <input type="number" class="form-control" id="modify-health" v-model="deltaHealth" placeholder="Hp Change" autocomplete="off"/>
            </div>
            <div class="form-group">
                <label for="modify-exp">Modify Exp : </label>
                <input type="number" class="form-control" id="modify-exp" v-model="deltaExp" placeholder="Exp Change" autocomplete="off"/>
            </div>
            <button class="btn btn-default">Submit</button>
        </form>
    </div>
</template>

<script>
export default {
    name: 'dm-character-operator',
    data(){
        return {
            deltaHealth : 0,
            deltaExp : 0
        }
    },
    props: ['characterList'],
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
                
                await this.$store.dispatch('updateCharacter', payload);
            });

        }
    }
}
</script>

<style lang="scss" scoped>
    .dm-character-operator {
        margin: 1%;
    }

</style>