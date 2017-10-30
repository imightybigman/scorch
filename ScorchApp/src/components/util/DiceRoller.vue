<template>
<div class="card dice-roller">
    <modal v-if="showModal" v-on:close="showModal = false">
        <h3 slot="header">Dice Roll</h3>
        <div slot="body" class="d-flex flex-column">
            <div class="d-flex">
                <h4>Rolled Value: <u>{{ rolledValue }}</u></h4>
            </div>
            <div class="d-flex justify-content-between">
                <button class="btn btn-primary" @click="rollD4">D4</button>
                <button class="btn btn-primary" @click="rollD6">D6</button>
                <button class="btn btn-primary" @click="rollD8">D8</button>
                <button class="btn btn-primary" @click="rollD10">D10</button>
                <button class="btn btn-primary" @click="rollD12">D12</button>
                <button class="btn btn-primary" @click="rollD20">D20</button>
            </div>
        </div>
    </modal>
    <div class="card-header">
        Dice Roller
    </div>
    <div class="card-body">
        <button class="btn btn-primary" @click="showModal = true">Do Dice Roller</button>
    </div>
</div>

</template>

<script>
import Modal from './Modal'

export default{
    name: "dice-roller",
    data() {
        return {
            showModal: false,
            rolledValue: ''
        }
    },
    methods: {
        rollD4: function() {
            this.rolledValue = Math.floor(Math.random() * 4) + 1;
        },
        rollD6: function() {
            this.rolledValue = Math.floor(Math.random() * 6) + 1;
        },
        rollD8: function() {
            this.rolledValue = Math.floor(Math.random() * 8) + 1;
        },
        rollD10: function() {
            this.rolledValue = Math.floor(Math.random() * 10) + 1;
        },
        rollD12: function() {
            this.rolledValue = Math.floor(Math.random() * 12) + 1;
        },
        rollD20: function() {
            this.rolledValue = Math.floor(Math.random() * 20) + 1;
        }
    }, 
    components: {
        Modal
    }
}
</script>

<style lang="scss" scoped>

</style>