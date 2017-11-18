<template>
<div class="d-flex flex-column character-spell">
  <modal v-if="showSpellDescription" v-on:close="closeDescription">
    <h3 slot="header">
      {{ selectedSpell.Name }}
    </h3>
    <div slot="body">
      <spell-readonly :spell="selectedSpell"></spell-readonly>
    </div>
  </modal>
  <modal v-if="showSpellAddModal" v-on:close="closeAdd">
    <h3 slot="header">
      Add New Spell
    </h3>
    <div slot="body">
      <spell-form @submit="spellFormSubmit"></spell-form>
    </div>
    <div slot="footer"></div>
  </modal>
  <div class="card spell-card card-width">
      <div class="card-body">
      <div class="list-group-item list-group-item-action">
          <button class="spell-button btn btn-block btn-primary" @click="showSpellAddModal = true">Add Spell</button>
        </div>
        <div v-for="(spell, index) in spells" @click="spellClick(spell)" :key="index" class="list-group-item list-group-item-action">
          <h6>{{ spell.Name }}</h6>
          <small v-if="spell.Damage">Damage: {{ spell.Damage }}</small>
          <small v-if="spell.DamageType">Damage Type: {{ spell.DamageType }}</small>
        </div>

            </div>
  </div>
</div>

</template>

<script>
import { Modal } from 'components/util'
import { SpellForm, SpellReadonly } from 'components/spells'

export default {
    name: 'character-spells',
    data() {
        return {
            showSpellDescription: false,
            showSpellAddModal: false,
            selectedSpell: {}
        }
    },
    props: ['characterId', 'spells'],
    methods: {
        spellClick(spell) {
            this.selectedSpell = spell;
            this.showSpellDescription = true;
        },
        async spellFormSubmit(spell) {
            let payload = {
                characterId: this.characterId,
                body: spell
            }
            await this.$store.dispatch('addSpell', payload);
            $("body").removeClass("modal-open");            
            this.showSpellAddModal = false;
        },
        closeDescription() {
            $("body").removeClass("modal-open");
            this.showSpellDescription = false;
        },
        closeAdd() {
            $("body").removeClass("modal-open");
            this.showSpellAddModal = false;
        }
    },
    components: {
        Modal,
        SpellForm,
        SpellReadonly
    }
}
</script>

<style lang="scss" scoped>
@import "~styles/shared.scss";

.spell-button {
  width: 30%;
  margin: 0 auto;
}

.spell-card {

    flex: 1 0 auto;
}

</style>
