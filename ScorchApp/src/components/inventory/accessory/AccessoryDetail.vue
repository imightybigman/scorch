<template>
<div>
  <modal v-if="showModal" v-on:close="close">
    <h3 slot="header">
      {{ accessory.Name }}
    </h3>
    <div slot="body">
      <div class="d-flex">
        <div class="accessory-basic d-flex flex-column">
          <div class="form-group">
            <label for="itemId">ItemId</label>
            <input type="text" id="itemId" class="form-control" v-model="accessory.ItemId" readonly />
          </div>
          <div class="form-group">
            <label for="name">Name</label>
            <input type="text" id="name" class="form-control" v-model="accessory.Name" readonly />
          </div>
          <div class="form-group">
            <label for="description">Description</label>
            <textarea type="text" rows="8" id="description" class="form-control" v-model="accessory.Description" readonly />
          </div>
          <div class="form-group">
            <label for="slot">Slot</label>
            <input type="text" id="slot" class="form-control" v-model="accessory.Slot" readonly />
          </div>
          <div class="form-group">
            <label for="cost">Cost</label>
            <input type="text" rows="3" id="cost" class="form-control" v-model="accessory.Cost" readonly />
          </div>
          <div class="form-group">
            <label for="weight">Weight</label>
            <input type="text" rows="3" id="weight" class="form-control" v-model="accessory.Weight" readonly />
          </div>
          <div class="form-group">
            <label for="count">Count</label>
            <input type="text" rows="3" id="count" class="form-control" v-model="accessory.Count" readonly />
          </div>
        </div>
        <div class="accessory-props d-flex flex-column">
            <h5>Properties</h5>
            <div v-for="(props, index) in accessory.Properties" v-bind:key="index">
                <p>{{ props }}</p>
            </div>
        </div>
      </div>
    </div>
  </modal>
</div>

</template>

<script>
import { Modal } from 'components/util'

export default {
    name : 'accessory-detail',
    props: ['accessory', 'showModal'],
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
.accessory-basic {
    flex: 1 0 auto;
}

.accessory-props {
    flex: 1 0 auto;
    margin-left: 3%;
}
</style>