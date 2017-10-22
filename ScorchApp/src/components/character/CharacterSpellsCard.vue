<template>
<div class="d-flex flex-column character-spell">
  <modal v-if="showSpellDescription" v-on:close="showSpellDescription = false">
    <h3 slot="header">
      {{ selectedSpell.Name }}
    </h3>
    <div slot="body">
      <spell-readonly :spell="selectedSpell"></spell-readonly>
    </div>
  </modal>
  <modal v-if="showSpellAddModal" v-on:close="showSpellAddModal = false">
    <h3 slot="header">
      Add New Spell
    </h3>
    <div slot="body">
      <spell-form @submit="spellFormSubmit"></spell-form>
    </div>
    <div slot="footer"></div>
  </modal>
  <div class="card spell-card">
    <div class="card-header" role="tab" id="character-spells">
      <h5 class="mb-0">
        <a data-toggle="collapse" href="#spells" aria-expanded="false" aria-controls="spells">Spell</a>
      </h5>
    </div>
    <div id="spells" class="collapse" role="tabpanel" aria-labelledby="character-spells" data-parent="#accordion">
      <div class="card-body">
        <div v-for="(spell, index) in spells" @click="spellClick(spell)" :key="index" class="list-group-item list-group-item-action">
          <h6>{{ spell.Name }}</h6>
          <small>Damage: {{ spell.Damage }}</small>
          <small>Damage Type: {{ spell.DamageType }}</small>
        </div>
        <div class="list-group-item list-group-item-action">
          <button class="btn btn-block btn-primary" @click="showSpellAddModal = true">+</button>
        </div>
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

.spell-card {
    min-width: $min-card-width;
    flex: 1 0 auto;
}

</style>
