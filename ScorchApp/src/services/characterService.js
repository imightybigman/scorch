import Vue from 'vue'

export default {
    getParty() {
        return Vue.http.get('character');
    },
    patchCharacter(id, props) {
        console.log(props);
        return Vue.http.patch('character/' + id, props);
    }
}