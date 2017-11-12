import Vue from 'vue'

export default {
    getSparseSpells(){
        return Vue.http.get('spells/sparse');
    },
    getSpellDetail(id){
        return Vue.http.get('spells/' + id);
    }
}