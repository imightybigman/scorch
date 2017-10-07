import Vue from 'vue'

export default class CharacterService {
    getCharacters() {
        return Vue.http.get('character');
    }

    getCharacterById(id) {
        return Vue.http.get('character/' + id);
    }
}