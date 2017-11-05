<template>
<div>
  <modal v-if="showModal" v-on:close="close">
    <h3 slot="header">
      {{ armor.Name }}
    </h3>
    <div slot="body">
      <div class="d-flex">
        <div class="armor-basic d-flex flex-column">
          <div class="form-group">
            <label for="itemId">ItemId</label>
            <input type="text" id="itemId" class="form-control" v-model="armor.ItemId" readonly />
          </div>
          <div class="form-group">
            <label for="name">Name</label>
            <input type="text" id="name" class="form-control" v-model="armor.Name" readonly />
          </div>
          <div class="form-group">
            <label for="description">Description</label>
            <textarea type="text" rows="3" id="description" class="form-control" v-model="armor.Description" readonly />
          </div>
          <div class="form-group">
            <label for="slot">Slot</label>
            <input type="text" id="slot" class="form-control" v-model="armor.Slot" readonly />
          </div>
          <div class="form-group">
            <label for="AC">AC</label>
            <input type="text" id="AC" class="form-control" v-model="armor.AC" readonly />
          </div>
          <div class="form-group">
            <label for="stealthAdvantage">Stealth Advantage</label>
            <p type="text" id="stealthAdvantage" class="form-control" readonly>{{ stealthAdv}}</p>
          </div>
        </div>
        <div class="armor-props d-flex flex-column">
            <h5>Properties</h5>
            <div v-for="(props, index) in armor.Properties" v-bind:key="index">
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
import map from 'lodash/map'

export default {
    name : 'armor-details',
    props: ['armor', 'showModal'],
    methods: {
        close() {
            $("body").removeClass("modal-open");
            this.$emit('close');
        }
    },
    computed: {
        stealthAdv() {
            return this.armor.StealthAdvantage ? 'Yes' : 'No'
        }
    },
    components: {
        Modal
    }
}
</script>

<style lang="scss" scoped>
.armor-basic {
    flex: 1 0 auto;
}

.armor-props {
    flex: 1 0 auto;
    margin-left: 3%;
}
</style>