import Vue from 'vue'

export default {
    getParty() {
        return Vue.http.get('character');
    },
    patchCharacter(id, props) {
        return Vue.http.patch('character/' + id, props);
    },
    putCharacterSpell(id, spell) {
        let endpoint = `character/${id}/spells`;
        return Vue.http.put(endpoint, spell)
    }
}