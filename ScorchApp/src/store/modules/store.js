import { ItemService } from 'services'
import * as types from '../mutation-types'
import pick from "lodash/pick";

// initial state
const state = {
    items: [],
    error: null
}

// getters
const getters = {
    items: state => state.items,
    error: state => state.error
}

// actions
const actions = {
    async addItem({ commit }, payload) {
        let response = {};
        try{
            response = await ItemService.postItem(payload.body);
            commit(types.ADD_ITEM, response.body);
        } catch(errorResponse) {
            commit(types.API_ERROR, errorResponse.bodyText);
        }
    },
    async getDisplayItems({ commit }) {
        let response = {};
        try{
            response = await ItemService.getItem();
            let displayItems = [];
            let displayProps = ['ItemId','Name','ItemClass','Damage','AC','Cost', 'Slot'];

            response.body.forEach(item => {
                displayItems.push(pick(item, displayProps));
            });

            commit(types.GET_DISPLAY_ITEMS, displayItems);
        } catch(errorResponse) {
            commit(types.API_ERROR, errorResponse.bodyText);
        }
    }
}

// mutations
const mutations = {
    [types.ADD_ITEM] (state, item) {
        state.items.push(item);
    },
    [types.API_ERROR] (state, error){
        error = "Item not created : " + error;
        state.error = error;
    },
    [types.GET_DISPLAY_ITEMS] (state, items) {
        state.items = items;
    }
}

export default {
    state,
    getters,
    actions,
    mutations
}
