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
        <div class="card skill-card card-width">
            <div class="card-header" role="tab" id="character-skills">
                <h5 class="mb-0">
                    <a data-toggle="collapse" href="#skills" aria-expanded="false" aria-controls="skills">
                    Skills
                    </a>
                </h5>
            </div>
            <div id="skills" class="collapse" role="tabpanel" aria-labelledby="character-skills" data-parent="#character-details">

            <div class="card-body">
            <div v-for="(skill, index) in skills" 
                 @click="skillClick(skill)" 
                 :key="index" 
                 class="list-group-item list-group-item-action">
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
