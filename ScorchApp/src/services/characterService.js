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
    },
    putCharacterItem(id, item) {
        let endpoint = `character/${id}/inventory`;
        return Vue.http.put(endpoint, item);
    },
    equipItem(id, item) {
        let endpoint = `character/${id}/equipment`;
        return Vue.http.put(endpoint, item);
    },
    unequipItem(id, slot){
        let endpoint = `character/${id}/equipment`;
        return Vue.http.delete(endpoint, { params: { slot: slot } });
    }
}