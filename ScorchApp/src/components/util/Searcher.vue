<template>
    <div class="searcher">
        <div class="searcher-inner">
            <div class="d-flex top-bar">
                <h4 class="searcher-header">Searcher</h4>
            </div>            
            <div class="input-group">
                <input type="text" class="form-control" id="name" v-model="searchTerm" placeholder="Search" autocomplete="off" required="true"/>
            </div>
            <div class="search-results table-responsive">
                <table id="search-results-table" class="table table-hover">
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
                <li class="page-item clickable" v-for="(page, index) in pagesToShow" :key="index" v-on:click="currentPage = page" >
                    <a class="page-link" v-bind:class ="{activated : page == currentPage}" >{{page}}</a>
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
        currentPage : 1
      }
    },
    props: ['searchData', 'limitPerPage', 'columnKeys'],
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
        includesAllChars(queryString, element){
            let result = false;
            let index = 0;
            let qsChars = queryString.toUpperCase().split('');
            let elemChars = element.toUpperCase().split('');
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
        searchResults() {
            let results = this.searchData;
            results = orderBy(results, [this.sortKey], [this.sortDirection]);

            results = filter(results, row => {
                let display = this.searchTerm ? false : true;
                for(let propKey in row){
                    if(typeof(row[propKey]) === 'string' && this.searchTerm)
                        display = display || this.includesAllChars(this.searchTerm, row[propKey]);
                    else
                        display = display || row[propKey] === this.searchTerm;                        
                }
                return display;
            });
            return results;
        },
        numPages() {
            return Math.ceil(this.searchResults.length / this.limitPerPage);
        },
        objectKeys() {
            if(this.columnKeys)
                return this.columnKeys;
            if(this.searchResults && this.searchResults.length > 0)
                return Object.keys(this.searchResults[0]);
            return [];
        },
        pagesToShow() {
            let result = [];
            if(this.numPages > 7){
                result.push(1);
                result.push(this.numPages);
            
                result.push(this.currentPage - 1 < 2 ? this.currentPage + 4 : this.currentPage - 1);
                result.push(this.currentPage - 2 < 2 ? this.currentPage + 3 : this.currentPage - 2);
                result.push(this.currentPage + 1 >= this.numPages ? this.currentPage - 4 : this.currentPage + 1);
                result.push(this.currentPage + 2 >= this.numPages ? this.currentPage - 3 : this.currentPage + 2);

                if(this.currentPage === 1)
                    result.push(this.currentPage + 5);
                else if(this.currentPage === this.numPages)
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
    }
}
</script>

<style lang="scss" scoped>
    div {
        box-sizing: border-box;
    }
    
    .searcher {
        margin: 1%;
        margin-top: 2%;
        padding: 1%;
        border-radius: 10px;
        background-image: url('~assets/Test.png');
        border-style: solid;
        box-shadow: 5px 5px 5px grey;
    }
    .searcher-inner {
        padding: 1%;
        flex-direction:column;
    }
    .searcher-outer {
        flex-direction:row;
    }
    .top-bar {
        flex-direction:row;
        margin-bottom:0.5%;
    }
    .filter-btn {
        float: right;
    }
    .searcher-header {
        flex:1;
    }
    .clickable {
        cursor: pointer;
    }
    .table-bordered {
        border: black;
    }
    .activated {
        background-color: orange;
    }
    input{
        background-color: #E8E8E8;
    }
    a{
        background-color: #E8E8E8;
    }
</style>