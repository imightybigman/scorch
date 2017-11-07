<template>
<div>
  <modal v-if="showModal" v-on:close="close">
    <h3 slot="header">
      {{ weapon.Name }}
    </h3>
    <div slot="body">
      <div class="d-flex">
        <div class="weapon-basic d-flex flex-column">
            <div class="form-group">
            <label for="itemId">ItemId</label>
            <input type="text" id="itemId" class="form-control" v-model="weapon.ItemId" readonly />
          </div>
          <div class="form-group">
            <label for="name">Name</label>
            <input type="text" id="name" class="form-control" v-model="weapon.Name" readonly />
          </div>
          <div class="form-group">
            <label for="description">Description</label>
            <textarea type="text" rows="8" id="description" class="form-control" v-model="weapon.Description"
              readonly />
          </div>
          <div class="form-group">
            <label for="slot">Slot</label>
            <input type="text" id="slot" class="form-control" v-model="weapon.Slot" readonly />
          </div>
          <div class="form-group">
            <label for="damage">Damage</label>
            <input type="text" id="damage" class="form-control" v-model="weapon.Damage" readonly />
          </div>
          <div class="form-group">
            <label for="damageType">Damage Type</label>
            <input type="text" id="damageType" class="form-control" v-model="weapon.DamageType" readonly />
          </div>
        </div>
        <div class="weapon-props d-flex flex-column">
            <h5>Properties</h5>
            <p v-for="(props, index) in weapon.Properties" :key="index">
                {{ props }}
            </p>
        </div>
      </div>

    </div>
  </modal>
</div>

</template>

<script>
import { Modal } from 'components/util'

export default {
    name : 'weapon-details',
    props: ['weapon', 'showModal'],
    methods: {
        close() {
            $("body").removeClass("modal-open");
            this.$emit('close');
        }
    },
    components: {
        Modal
    }
}
</script>

<style lang="scss" scoped>
.weapon-basic {
    flex: 1 0 auto;
}

.weapon-props {
    flex: 1 0 auto;
    margin-left: 3%;
}
</style>