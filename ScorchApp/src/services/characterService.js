import Vue from 'vue'

export default {
    getParty() {
        return Vue.http.get('character');
    },
    patchCharacter(id, props) {
        return Vue.http.patch('character/' + id, props);
    },
    sellItem(id, itemId){
        let endpoint = `character/${id}/inventory/sell?itemId=${itemId}`;
        return Vue.http.delete(endpoint);
    },
    putCharacterSpell(id, spellId) {
        let endpoint = `character/${id}/spells?spellId=${spellId}`;
        return Vue.http.put(endpoint)
    },
    deleteCharacterSpell(id, spellId) {
        let endpoint = `character/${id}/spells?spellId=${spellId}`;
        return Vue.http.delete(endpoint)
    },
    putCharacterItem(id, item) {
        let endpoint = `character/${id}/inventory`;
        return Vue.http.put(endpoint, item);
    },
    postCharacterItem(id, item) {
        let endpoint = `character/${id}/inventory`;
        return Vue.http.post(endpoint, item);
    },
    equipItem(id, item) {
        let endpoint = `character/${id}/equipment`;
        return Vue.http.put(endpoint, item);
    },
    unequipItem(id, slot){
        let endpoint = `character/${id}/equipment`;
        return Vue.http.delete(endpoint, { params: { slot: slot } });
    },
    deleteItem(id, itemId){
      let endpoint = `character/${id}/inventory/delete?itemId=${itemId}`;
      return Vue.http.delete(endpoint);
    }
}