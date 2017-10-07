export default class CharacterService {
    getCharacters() {
        this.$http.get('https://dnd-api.imightybigman.com/api/character').then(response => {
            console.log(response);
        })
    }
}