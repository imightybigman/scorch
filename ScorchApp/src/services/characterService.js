import Vue from 'vue'

export default {
    getParty() {
        return Vue.http.get('character');
    },
    
    getCharacterById(id) {
        return Vue.http.get('character/' + id);
    }
}