<template>
    <div class="item-searcher border border-dark d-flex">
            <div class="item-searcher-inner">
                <div class="d-flex top-bar">
                    <h4 class="item-searcher-header">ItemSearcher</h4>
                    <button class="filter-btn btn btn-primary">Filter</button>
                </div>            
                <div class="input-group">
                    <input type="text" class="form-control" id="name" v-model="searchTerm" placeholder="Name To Filter By" autocomplete="off" required="true"/>
                    <button class="btn btn-secondary" type="button" v-on:click="search()"><b>Search</b></button>
                </div>
                <div class="search-results table-responsive">
                    <table id="search-results-table" class="table table-hover table-bordered">
                        <thead>
                            <tr>
                                <th>Name</th>
                                <th>Type</th>
                                <th>Class</th>
                                <th>Slot</th>
                                <th>AC</th>
                                <th>Dmg</th>
                                <th>Cost</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr v-for="(item, index) in searchResults" :key="index" v-on:click="selectItem(item)">
                                <td>{{item.Name}}</td>
                                <td>{{item.ItemType}}</td>
                                <td>{{item.ItemClass}}</td>
                                <td>{{item.Slot}}</td>
                                <td>{{item.AC}}</td>
                                <td>{{item.Damage}}</td>
                                <td>{{item.Cost}}</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            <div class="filter-window">
                sup
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
    created() {
        this.$store.dispatch('getItem');   
    },
    methods: {
        search(){
            
        },
        selectItem(item){
            this.$emit('search-item-selected', item);
        }
    },
    computed: {
        searchResults(){
            let results = this.$store.getters.items;
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
        flex-direction:column;
    }
    .item-searcher-outer {
        flex-direction:row;
    }
    .top-bar {
        flex-direction:row;
        margin-bottom:0.5%;
    }
    .filter-btn {
        float: right;
    }
    .item-searcher-header {
        flex:1;
    }
    .filter-window{
        flex:0;
        display:none;
    }
</style>