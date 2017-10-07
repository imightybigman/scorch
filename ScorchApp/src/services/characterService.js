import Vue from 'vue'

export default class CharacterService {
    getCharacters() {
        return Vue.http.get('character');
    }
}