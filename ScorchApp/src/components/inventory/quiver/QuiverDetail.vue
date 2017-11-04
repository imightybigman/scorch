<template>
<div>
  <modal v-if="showModal" v-on:close="close">
    <h3 slot="header">
      {{ quiver.Name }}
    </h3>
    <div slot="body">
      <div class="d-flex">
        <div class="quiver-basic d-flex flex-column">
            <div class="form-group">
            <label for="itemId">ItemId</label>
            <input type="text" id="itemId" class="form-control" v-model="quiver.ItemId" readonly />
          </div>
          <div class="form-group">
            <label for="name">Name</label>
            <input type="text" id="name" class="form-control" v-model="quiver.Name" readonly />
          </div>
          <div class="form-group">
            <label for="description">Description</label>
            <textarea type="text" rows="3" id="description" class="form-control" v-model="quiver.Description"
              readonly />
          </div>
            <div class="form-group projectile-count d-flex flex-column">
            <label>Projectiles</label>
            <div class="projectiles d-flex" v-for="(count, projectile, index) in quiver.Projectiles" :key="index">
                <strong>{{projectile}} : {{ getArrowCount(count) }}</strong>
             </div>
        </div>
        </div>
        <div class="quiver-props d-flex flex-column">
            <h5>Properties</h5>
            <p v-for="(props, index) in quiver.Properties" :key="index">
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
    name : 'quiver-detail',
    props: ['quiver', 'showModal'],
    methods: {
        close() {
            this.$emit('close');
        },
        getArrowCount(projectile) {
            return `${projectile.CurrentAmount}/${projectile.MaxAmount}`;
        }
    },
    components: {
        Modal
    }
}
</script>

<style lang="scss" scoped>
.quiver-basic {
    flex: 1 0 auto;
}

.quiver-props {
    flex: 1 0 auto;
    margin-left: 3%;
}
</style>