<template>
    <div class="character-skill list-group">
        <div class="card">
            <div class="card-header">
            Skills
            </div>
            <div class="card-body">
            <div v-for="(skill, index) in skills" :key="index" class="list-group-item list-group-item-action flex-column align-items-start">
                <div class="d-flex w-100 justify-content-between">
                <h5>{{ skill.Name }}</h5>
                </div>
            </div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: 'character-skill',
    props: ['skills'],
    computed: {
        displaySkillName: function() {
            return 'adf';
        }
    }
}
</script>

<style lang="scss" scoped>

</style>
