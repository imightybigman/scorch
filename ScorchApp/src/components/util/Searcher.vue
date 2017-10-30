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
                            <th v-for="(key, index) in objectKeys" :key="index" v-on:click="sortByForm(key)">
                                <i class="fa" v-bind:class = "{'fa-sort-desc' : (key == sortKey && sortDirection == 'desc'),
                                                                        'fa-sort-asc' : (key == sortKey && sortDirection == 'asc'),
                                                                        'fa-sort' : (key != sortKey)}" 
                                                                        aria-hidden="true"/>{{key}}
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr v-for="(row, srIndex) in searchResults.slice((currentPage-1) * limitPerPage, currentPage * limitPerPage)" :key="srIndex" v-on:click="selectRow(row)">
                            <td v-for="(key, keyIndex) in objectKeys" :key="keyIndex">{{row[key]}}</td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <ul class="pagination">
                <li class="page-item clickable" v-on:click="currentPage = Math.max(currentPage-1, 1)">
                    <a class="page-link" >
                        <span aria-hidden="true">&laquo;</span>
                    </a>
                </li>
                <li class="page-item clickable" v-for="(page, index) in pagesToShow" :key="index" v-on:click="currentPage = page" v-bind:class ="{active : page == currentPage}">
                    <a class="page-link" >{{page}}</a>
                </li>
                
                <li class="page-item clickable" v-on:click="currentPage = Math.min(currentPage+1, numPages)">
                    <a class="page-link" >
                        <span aria-hidden="true">&raquo;</span>
                    </a>
                </li>
            </ul>
        </div>
    </div>
    
</template>

<script>
    import filter from 'lodash/filter'
    import orderBy from 'lodash/orderBy'
    import sortBy from 'lodash/sortBy'

export default {
    name : 'searcher',
    
    data() {
      return {
        searchTerm : '',
        sortKey : '',
        sortDirection : 'asc',
        objectKeys: [],
        keysPopulated : false,
        currentPage : 1
      }
    },
    props: ['searchData', 'limitPerPage'],
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
            if(!this.keysPopulated && this.searchData.length > 0)
                this.populateObjectKeys(results);

            results = orderBy(results, [this.sortKey], [this.sortDirection]);

            results = filter(results, row => {
                var display = this.searchTerm ? false : true;
                for(var propKey in row){
                    if(typeof(row[propKey]) === 'string' && this.searchTerm)
                        display = display || this.includesAllChars(this.searchTerm, row[propKey]);
                    else
                        display = display || row[propKey] == this.searchTerm;                        
                }
                return display;
            });
            return results;
        },
        numPages : function(){
            return Math.ceil(this.searchResults.length / this.limitPerPage);
        },
        pagesToShow : function(){
            let result = [];
            if(this.numPages > 7){
                result.push(1);
                result.push(this.numPages);
            
                result.push(this.currentPage - 1 < 2 ? this.currentPage + 4 : this.currentPage - 1);
                result.push(this.currentPage - 2 < 2 ? this.currentPage + 3 : this.currentPage - 2);
                result.push(this.currentPage + 1 >= this.numPages ? this.currentPage - 4 : this.currentPage + 1);
                result.push(this.currentPage + 2 >= this.numPages ? this.currentPage - 3 : this.currentPage + 2);

                if(this.currentPage == 1)
                    result.push(this.currentPage + 5);
                else if(this.currentPage == this.numPages)
                    result.push(this.currentPage - 5);
                else 
                    result.push(this.currentPage);
            }
            else {
                for(let i = 1; i < this.numPages + 1; i++){
                    result.push(i);
                }
            }
            return sortBy(result);
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
    .clickable {
        cursor: pointer;
    }
</style>