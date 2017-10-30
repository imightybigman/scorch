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
                            <th v-for="(key, index) in objectKeys" :key="index" v-on:click="sortByForm(key)">{{key}}</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr v-for="(row, srIndex) in searchResults" :key="srIndex" v-on:click="selectRow(row)">
                            <td v-for="(key, keyIndex) in objectKeys" :key="keyIndex">{{row[key]}}</td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
    
</template>

<script>
    import filter from 'lodash/filter'
    import orderBy from 'lodash/orderBy'

export default {
    name : 'searcher',
    
    data() {
      return {
        searchTerm : '',
        sortKey : '',
        sortDirection : 'asc',
        objectKeys: [],
        keysPopulated : false
      }
    },
    props: ['searchData'],
    methods: {
        selectRow(row){
            this.$emit('search-row-selected', row);
        },
        sortByForm(key){
            if(this.sortKey === key){
                this.sortDirection = this.sortDirection === 'desc' ? 'asc' : 'desc';
            }
            else{
                this.sortKey = key;
                this.sortDirection = 'asc';
            }
        },
        populateObjectKeys(results){
            this.keysPopulated = true;
            var allKeys = [];
            results.forEach(result => {
                Object.keys(result).forEach(key => {
                    if(!allKeys.includes(key))
                        allKeys.push(key);
                });
            });
            if(allKeys.length > 0)
            {
                this.sortKey = allKeys[0];
            }
            this.objectKeys = allKeys;
        },
        includesAllChars(queryString, element){
            var result = false;
            var index = 0;
            var qsChars = queryString.toUpperCase().split('');
            var elemChars = element.toUpperCase().split('');
            elemChars.forEach(elemChar => {
                if(qsChars[index] === elemChar){
                    index++;
                }
                if(qsChars.length == index){
                    result = true;
                }
            });

            return result;
        }
    },
    computed: {
        searchResults : function(){
            let results = this.searchData;
            results = orderBy(results, [this.sortKey], [this.sortDirection]);
            if(!this.keysPopulated)
                this.populateObjectKeys(results);

            results = filter(results, row => {
                let display = this.searchTerm ? false : true;
                for(var propKey in row){
                    if(typeof(row[propKey]) === 'string' && this.searchTerm)
                        display = display || this.includesAllChars(this.searchTerm, row[propKey]);
                    else
                        display = display || row[propKey] == this.searchTerm;                        
                }
                return display;
            });
    
            return results;
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