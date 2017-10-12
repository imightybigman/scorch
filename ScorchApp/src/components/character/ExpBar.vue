<template>
    <div>
        Exp: 
        <div class="progress">
            <div 
                class="progress-bar" 
                role="progressbar" 
                aria-valuenow="100" 
                :style="progressWidth" 
                aria-valuemin="0" 
                aria-valuemax="100">50/100</div>
        </div>
    </div>
</template>

<script>
    export default {
        name: 'exp-bar',
        computed: {
            progressWidth: function() {
                return 'width: 50%';
            }
        }
    }
</script>

<style lang="scss" scoped>

</style>