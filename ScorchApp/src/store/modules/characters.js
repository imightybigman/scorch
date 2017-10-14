import { CharacterService } from 'services'
import sortBy from 'lodash/sortBy'
import * as types from '../mutation-types'

// initial state
const state = {
    party: []
}

// getters
const getters = {
    myParty: state => state.party,
    getCharacterById: (state, getters) => (id) => {
        return state.party.find(char => char.CharacterId == id);
    }
}

// actions
const actions = {
    async getParty({ commit }) {
        let response = await CharacterService.getParty();
        let myParty = sortBy(response.body, (c) => c.Firstname);
        commit(types.GET_PARTY, myParty);
    },
    async updateCharacter({ commit }, payload) {
        let response = await CharacterService.patchCharacter(payload.characterId, payload.body);
        if(response.status === 200){
            commit(types.PATCH_CHARACTER, payload);
        }
    },
    async addSpell({ commit }, payload) {
        let response = await CharacterService.putCharacterSpell(payload.characterId, payload.body);
        if(response.status === 200){
            payload.addedSpell = response.body;
            commit(types.ADD_SPELL, payload);
        }
    }
}

// mutations
const mutations = {
    [types.GET_PARTY] (state, party) {
        state.party = party;
    },
    [types.PATCH_CHARACTER] (state, payload) {
        let id = payload.characterId;
        let props = payload.body;

        for(let i = 0; i < state.party.length; i++) {
            let ch = state.party[i];
            if(ch.CharacterId === id) {
                for(let key in props) {
                    ch[key] = props[key];
                }
            break;                
            }
        }
    },
    [types.ADD_SPELL] (state, payload) {
        let id = payload.characterId;
        let spell = payload.addedSpell;

        for(let i = 0; i < state.party.length; i++) {
            let ch = state.party[i];
            if(ch.CharacterId === id) {
                ch.Spells.push(spell);
                ch.Spells = sortBy(ch.Spells, (s) => s.Name);
            }
            break;
        }
    }
}

export default {
    state,
    getters,
    actions,
    mutations
}
