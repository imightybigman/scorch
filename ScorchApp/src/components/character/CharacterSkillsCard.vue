<template>
    <div class="d-flex flex-column character-skill">
        <modal v-if="showModal" v-on:close="close">
            <h3 slot="header">
                {{ displaySkillName(selectedSkill) }}
            </h3>
            <div slot="body">
                {{ selectedSkill.Description }}
            </div>
        </modal>

        <div v-for="(skill, index) in skills" 
                @click="skillClick(skill)" 
                :key="index" 
                class="list-group-item list-group-item-action">
            <h6>{{ displaySkillName(skill) }}</h6>
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
        displaySkillName(skill) {
            return `${skill.Name} (${skill.Stat})`;
        },
        skillClick(skill) {
            this.selectedSkill = skill;
            this.showModal = true;
        },
        close() {
            $("body").removeClass("modal-open")
            this.showModal = false;
        }
    },
    components: {
        Modal
    }
}
</script>

<style lang="scss" scoped>
@import "~styles/shared.scss";

.skill-card {
    flex: 1 0 auto;
}

</style>
