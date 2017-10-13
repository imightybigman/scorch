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
        let party = await CharacterService.getParty();
        party = sortBy(party.body, (c) => c.Firstname);
        commit(types.GET_PARTY, party);
    }
}

// mutations
const mutations = {
    [types.GET_PARTY] (state, party) {
        state.party = party
    }
}

export default {
    state,
    getters,
    actions,
    mutations
}
