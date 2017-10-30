<template>
    <div class="item-searcher border border-dark">
        <div class="item-searcher-inner">
            <div class="d-flex top-bar">
                <h4 class="item-searcher-header">Searcher</h4>
            </div>            
            <div class="input-group">
                <input type="text" class="form-control" id="name" v-model="searchTerm" placeholder="Search" autocomplete="off" required="true"/>
            </div>
            <div class="search-results table-responsive">
                <table id="search-results-table" class="table table-hover table-bordered">
                    <thead>
                        <tr>
                            <th v-for="(key, index) in objectKeys" :key="index">{{key}}</th>
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
    </div>
    
</template>

<script>
    import filter from 'lodash/filter'

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
        selectItem(item){
            this.$emit('search-row-selected', item);
            //Name	Type	Class	Slot	AC	Dmg	Cost 
        }
    },
    computed: {
        searchResults : function(){
            let results = this.$store.getters.items;
            results = filter(results, item => item.Name.includes(this.searchTerm));
            return results;
        },
        objectKeys : function(){
            if(this.searchResults.length > 0)
                return Object.keys(this.searchResults[0]);
            else
                return [];
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
        border-radius: 10px;
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
</style>