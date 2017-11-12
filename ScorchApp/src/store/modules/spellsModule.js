import { SpellService } from 'services'
import _ from 'lodash'
import * as types from '../mutation-types'
import Vue from 'vue'


// initial state
const state = {
    spells: {}
}

const getters = {
    getSpells() {
        return Object.values(state.spells);
    }, 
    getSpell:(state, getters) => (id) => {
        return state.spells[id];
    }
    
}

const actions = {
    async getSpells({ commit }) {
        if(Object.keys(state.spells).length !== 0){
            return;
        }
        let response = await SpellService.getSparseSpells();
        commit(types.GET_SPELLS, response.body);
    },
    async loadSpellDetails({commit}, id) {
        let response = await SpellService.getSpellDetail(id);
        if(response.status === 200){
            commit(types.GET_SPELL_DETAIL, response.body)
        }
    }
}

const mutations = {
    [types.GET_SPELLS] (state, spells) {
        let organizedSpells = _.chain(spells)
            .forEach((s) => {
                s.Classes = s.Classes.join();
            })
            .sortBy(['Level'])
            .keyBy((s) => { return s.SpellId; })
            .valueOf();

        state.spells = organizedSpells;
    },
    [types.GET_SPELL_DETAIL] (state, spell) {
        spell.Classes = spell.Classes.join();
        state.spells = { ...state.spells, [spell.SpellId] : spell };
    }
}

export default {
    state,
    getters,
    actions,
    mutations
}