<template>
    <div class="dm-notes-component">
        <div class="d-flex flex-wrap" v-if="dataDone">
            <div class="flex-column">
                Sup
            </div>
            <div>
                Yo Yo Yo
            </div>
        </div>
    </div>
    
</template>

<script>

export default {
    name : 'dm-notes-component',
    
    data() {
      return {
        dataDone: false
      }
    },
    
    async beforeRouteUpdate (to, from, next) {
      await this.loadData();
      next();
    },
    async beforeMount() {
      await this.loadData();
    },
    methods: {
      async loadData() {
        this.dataDone = true;
      }
    }
}
</script>

<style lang="scss" scoped>
    div {
        box-sizing: border-box;
    }
    .notelet-section{
        flex: 1;
        flex-grow: 2;
    }

</style>