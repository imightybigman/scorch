<template>
<div>
  <modal v-if="showModal" v-on:close="close">
    <h3 slot="header">
      {{ adventurergear.Name }}
    </h3>
    <div slot="body">
      <div class="d-flex">
        <div class="adventurergear-basic d-flex flex-column">
          <div class="form-group">
            <label for="name">Name</label>
            <input type="text" id="name" class="form-control" v-model="adventurergear.Name" readonly />
          </div>
          <div class="form-group">
            <label for="description">Description</label>
            <textarea type="text" rows="8" id="description" class="form-control" v-model="adventurergear.Description" readonly />
          </div>
          <div class="form-group">
            <label for="cost">Cost</label>
            <input type="text" rows="3" id="cost" class="form-control" v-model="adventurergear.Cost" readonly />
          </div>
          <div class="form-group">
            <label for="weight">Weight</label>
            <input type="text" rows="3" id="weight" class="form-control" v-model="adventurergear.Weight" readonly />
          </div>
          <div class="form-group">
            <label for="count">Count</label>
            <input type="text" rows="3" id="count" class="form-control" v-model="adventurergear.Count" readonly />
          </div>
        </div>
        <div class="adventurergear-props d-flex flex-column">
            <h5>Properties</h5>
            <div v-for="(props, index) in adventurergear.Properties" v-bind:key="index">
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
    name : 'adventurergear-details',
    props: ['adventurergear', 'showModal'],
    methods: {
        close() {
            this.$emit('close');
        }
    },
    components: {
        Modal
    }
}
</script>

<style lang="scss" scoped>
.adventurergear-basic {
    flex: 1 0 auto;
}

.adventurergear-props {
    flex: 1 0 auto;
    margin-left: 3%;
}
</style>