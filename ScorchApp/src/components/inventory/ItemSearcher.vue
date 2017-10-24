<template>
    <div class="item-searcher border border-dark">
        <div class="d-flex flex-wrap item-searcher-inner">
            <h4>ItemSearcher</h4>
            
            <div class="input-group">
                <input type="text" class="form-control" id="name" v-model="searchTerm" placeholder="Name To Filter By" autocomplete="off" required="true"/>
                <button class="btn btn-secondary" type="button" v-on:click="search()"><b>Search</b></button>
            </div>
            <div class="search-results list-group">
                <div class="list-group-item item-result" v-for="(item, index) in searchResults" :key="index">
                    <h6>{{item.Name}}</h6>
                </div>
            </div>
        </div>
    </div>
    
</template>

<script>
export default {
    name : 'item-searcher',
    
    data() {
      return {
        searchTerm : ''
        
      }
    },
    methods: {
        search(){
            this.$store.dispatch('getItem');
        }
    },
    computed: {
        searchResults(){
            console.log("blah");
            return this.$store.getters.items;
        }
    },
    components: {
        
    }
}
</script>

<style lang="scss" scoped>
    div {
        box-sizing: border-box;
    }
    
    .item-searcher {
        margin: 1%;
        margin-top: 2%;
        padding: 1%;
        border-radius: 5px;
    }
    .item-searcher-inner {
        padding: 1%;
    }
    .item-result {
        width: 100%;
    }
</style>