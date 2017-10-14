import { ItemService } from 'services'
import * as types from '../mutation-types'

// initial state
const state = {
    items: []
}

// getters
const getters = {
    items: state => state.items,
}

// actions
const actions = {
    async addItem({ commit }, payload) {
        let response = await ItemService.postItem(payload.body);
        if(response.status === 200){
            commit(types.ADD_ITEM, response.body);
        }
    }
}

// mutations
const mutations = {
    [types.ADD_ITEM] (state, item) {
        state.items.push(item);
    }
}

export default {
    state,
    getters,
    actions,
    mutations
}
