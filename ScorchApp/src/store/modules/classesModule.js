import { ClassService } from 'services'
import * as types from '../mutation-types'
import Vue from 'vue'


// initial state
const state = {
    classes: []
}

// getters
const getters = {
    classes: state => state.classes,
    getClass: (state, getters) => (name) => {
        return state.classes.find(c => c.Name === name)
    }
}

// actions
const actions = {
    async loadClass({ commit }, name) {
        if(!state.classes.find(c => c.Name === name)) {    
            let response = await ClassService.getClass(name);
            if(response.status === 200){
                commit(types.LOAD_CLASS,  response.body);
            }
        }
    }
}

// mutations
const mutations = {
    [types.LOAD_CLASS] (state, characterClass) {
        state.classes.push(characterClass);
    }
}

export default {
    state,
    getters,
    actions,
    mutations
}
