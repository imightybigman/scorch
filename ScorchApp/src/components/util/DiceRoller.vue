<template>
<div class="card dice-roller">
    <modal v-if="showModal" v-on:close="showModal = false">
        <h3 slot="header">Dice Roller</h3>
        <div slot="body" class="d-flex flex-column">
            <div class="d-flex dices">
                <button class="btn btn-danger" @click="clear">Clear Rolls</button>            
            </div>
            <div class="d-flex justify-content-between dices">
                <div class="d-flex text-center flex-column">
                    <button id="d4" class="btn btn-primary" @click="rollD4">D4</button>
                    <span>x{{ rollD4Count}}</span>
                </div>
                <div class="d-flex text-center flex-column">
                    <button class="btn btn-primary" @click="rollD6">D6</button>
                    <span>x{{ rollD6Count }}</span>
                </div>
                <div class="d-flex text-center flex-column">
                    <button class="btn btn-primary" @click="rollD8">D8</button>
                    <span>x{{ rollD8Count }}</span>
                </div>
                <div class="d-flex text-center flex-column">
                    <button class="btn btn-primary" @click="rollD10">D10</button>
                    <span>x{{ rollD10Count }}</span>
                </div>
                <div class="d-flex text-center flex-column">
                    <button class="btn btn-primary" @click="rollD12">D12</button>
                    <span>x{{ rollD12Count }}</span>
                </div>
                <div class="d-flex text-center flex-column">
                    <button class="btn btn-primary" @click="rollD20">D20</button>
                    <span>x{{ rollD20Count }}</span>
                </div>
            </div>
            <div class="d-flex">
                <h4>Rolled: {{ rolledValues }}</h4>
            </div>
            <div class="d-flex">
                <h4>Rolled Total: <u>{{ rollTotal }}</u></h4>
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
import sum from 'lodash/sum'

export default {
    name: 'dice-roller',
    data() {
        return {
            showModal: false,
            rolledValues: [],
            rollD4Count: 0,
            rollD6Count: 0, 
            rollD8Count: 0, 
            rollD10Count: 0,
            rollD12Count: 0,
            rollD20Count: 0
        }
    },
    watch: {
        showModal: function(newValue) {
            this.clear();
        }
    },
    methods: {
        rollD4() {
            this.rolledValues.push(Math.floor(Math.random() * 4) + 1);
            this.rollD4Count++;
        },
        rollD6() {
            this.rolledValues.push(Math.floor(Math.random() * 6) + 1);
            this.rollD6Count++;
        },
        rollD8() {
            this.rolledValues.push(Math.floor(Math.random() * 8) + 1);
            this.rollD8Count++;
        },
        rollD10() {
            this.rolledValues.push(Math.floor(Math.random() * 10) + 1);
            this.rollD10Count++;
        },
        rollD12() {
            this.rolledValues.push(Math.floor(Math.random() * 12) + 1);
            this.rollD12Count++;
        },
        rollD20() {
            this.rolledValues.push(Math.floor(Math.random() * 20) + 1);
            this.rollD20Count++;
        },
        clear() {
            this.rolledValues = [];
            this.rollD4Count = 0;
            this.rollD6Count = 0;
            this.rollD8Count = 0;
            this.rollD10Count = 0;
            this.rollD12Count = 0;
            this.rollD20Count = 0;
        }
    },
    computed: {
        rollTotal() {
            return sum(this.rolledValues)
        }
    },
    components: {
        Modal
    }
}
</script>

<style lang="scss" scoped>
.dices {
    margin-bottom: 5%;
}
</style>