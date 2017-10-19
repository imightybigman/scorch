<template>
    <div>
         <modal v-if="showModal" v-on:close="close">
            <h3 slot="header">
                {{ weapon.Name }}
            </h3>
            <div slot="body">
                <div class="form-group">
                    <label for="damage">Damage Type</label>
                    <input type="text" id="damage" class="form-control" v-model="weapon.Damage" placeholder="e.g. Force" readonly />
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
            this.$emit('close');
        }
    },
    components: {
        Modal
    }
}
</script>

<style lang="scss" scoped>
</style>