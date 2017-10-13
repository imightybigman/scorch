<template>
    <div class="character-skill list-group">
        <modal v-if="showModal" v-on:close="showModal = false">
            <h3 slot="header">
                {{ displaySkillName(selectedSkill) }}
            </h3>
            <div slot="body">
                {{ selectedSkill.Description }}
            </div>
        </modal>
        <div class="card">
            <div class="card-header">
            Skills
            </div>
            <div class="card-body">
            <div v-for="(skill, index) in skills" @click="skillClick(skill)" :key="index" class="list-group-item list-group-item-action flex-column align-items-start">
                <div class="d-flex w-100 justify-content-between">
                <h6>{{ displaySkillName(skill) }}</h6>
                </div>
            </div>
            </div>
        </div>
    </div>
</template>

<script>
import { Modal } from 'components/util'

export default {
    name: 'character-skill',
    data() {
        return {
            showModal: false,
            selectedSkill: {}
        }
    },
    props: ['skills'],
    methods: {
        displaySkillName: function(skill) {
            return `${skill.Name} (${skill.Stat})`;
        },
        skillClick: function(skill) {
            this.selectedSkill = skill;
            this.showModal = true;
        }
    },
    components: {
        Modal
    }
}
</script>

<style lang="scss" scoped>

</style>
