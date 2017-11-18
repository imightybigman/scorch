import { CharacterService } from 'services'
import _ from 'lodash'
import * as types from '../mutation-types'
import Vue from 'vue'


// initial state
const state = {
    party: []
}

// getters
const getters = {
    myParty: state => state.party,
    getCharacterById: (state, getters) => (id) => {
        return state.party.find(char => char.CharacterId === id);
    },
    getCharacterInventory: (state, getters) => (id) => {
        return state.party.find(char => char.CharacterId === id).Inventory;
    },
    getCharacterWeapons: (state, getters) => (id) => {
        let inventory = state.party.find(char => char.CharacterId === id).Inventory;
        return inventory.filter(item => item.ItemClass === 'Weapon');
    },
    getCharacterArmors: (state, getters) => (id) => {
        let inventory = state.party.find(char => char.CharacterId === id).Inventory;
        return inventory.filter(item => item.ItemClass === 'Armor');
    },
    getCharacterAdventurerGears: (state, getters) => (id) => {
        let inventory = state.party.find(char => char.CharacterId === id).Inventory;
        return inventory.filter(item => item.ItemClass === 'AdventurerGear');
    },
    getCharacterQuivers: (state, getters) => (id) => {
        let inventory = state.party.find(char => char.CharacterId === id).Inventory;
        return inventory.filter(item => item.ItemClass === 'Quiver');
    },
    getCharacterAccessories: (state, getters) => (id) => {
        let inventory = state.party.find(char => char.CharacterId === id).Inventory;
        return inventory.filter(item => item.ItemClass === 'Accessory');
    },
    getCharacterEquipment: (state, getters) => (id) => {
        return state.party.find(char => char.CharacterId === id).Equipment || { };
    }
}

// actions
const actions = {
    async getParty({ commit }) {
        let response = await CharacterService.getParty();
        let myParty = _.sortBy(response.body, (c) => c.Firstname);
        commit(types.GET_PARTY, myParty);
    },
    async updateCharacter({ commit }, payload) {
        let response = await CharacterService.patchCharacter(payload.characterId, payload.body);
        if(response.status === 200){
            await actions.getParty({ commit });
        }
    },
    async addSpellToCharacter({ commit }, payload) {
        let response = await CharacterService.putCharacterSpell(payload.characterId, payload.body.SpellId);
        if(response.status === 200){
            payload.addedSpell = response.body;
            commit(types.ADD_SPELL_CHARACTER, payload);
        }
    },
    async deleteSpellFromCharacter({ commit }, payload) {
        let response = await CharacterService.deleteCharacterSpell(payload.characterId, payload.spellId);
        if(response.status === 200){
            payload.addedSpell = response.body;
            commit(types.DELETE_SPELL_CHARACTER, payload);
        }
    },
    async equipItem({ commit }, payload) {
        try {
            let response = await CharacterService.equipItem(payload.characterId, payload.item);
            if(response.status === 200) {
                commit(types.EQUIP_ITEM, payload);
            }
        }
        catch(ex){
            console.error('EQUIP ERROR: ' + ex.body.error)
        }

    },
    async updateItem({ commit }, payload) {
        let response = await CharacterService.putCharacterItem(payload.characterId, payload.item);
        if(response.status === 200){
            commit(types.UPDATE_ITEM, payload)
        }
    },
    async unequipItem({ commit }, payload) {
        let response = await CharacterService.unequipItem(payload.characterId, payload.slot);
        if(response.status === 200){
            commit(types.UNEQUIP_ITEM, payload);
        }
    },
    async sellItem({commit}, payload){
        let response = await CharacterService.sellItem(payload.characterId, payload.itemId);
        if(response.status === 200){
            commit(types.SOLD_ITEM, payload);
        }
    },
    async deleteItem({commit}, payload) {
      let response = await CharacterService.deleteItem(payload.characterId, payload.itemId);
      if(response.status === 200){
          commit(types.DELETE_ITEM, payload);
      }
    },
    async socket_getParty({ commit }, message) {
        let response = await CharacterService.getParty();
        let myParty = _.sortBy(response.body, (c) => c.Firstname);
        commit(types.GET_PARTY, myParty);
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
                    state.party[i] = {...ch, [key]: props[key] };
                }
            break;
            }
        }
    },
    [types.ADD_SPELL_CHARACTER] (state, payload) {
        let id = payload.characterId;
        let addedSpell = payload.addedSpell;

        for(let i = 0; i < state.party.length; i++) {
            let ch = state.party[i];
            if(ch.CharacterId === id) {
                ch.Spells.push(addedSpell);
                state.party[i].Spells = _.sortBy(ch.Spells, (s) => s.Name);
                break;
            }
        }
    },
    [types.DELETE_SPELL_CHARACTER] (state, payload) {
        let id = payload.characterId;
        let spellId = payload.spellId;
        for(let i = 0; i < state.party.length; i++) {
            let ch = state.party[i];
            if(ch.CharacterId === id) {
                _.remove(ch.Spells, (s) => { s.SpellId === spellId});
                let index = _.findIndex(ch.Spells,(s) => s.SpellId === spellId);
                ch.Spells.splice(index, 1);
                break;
            }
        }
    }, 
    [types.EQUIP_ITEM] (state, payload) {
        let id = payload.characterId;
        let item = payload.item;
        let slot = (item.Slot == 'One-Handed' || item.Slot == 'Two-Handed') ? 'MainHand' : item.Slot;
        for(let i = 0; i < state.party.length; i++) {
            let ch = state.party[i];
            if(ch.CharacterId === id) {
                if (!state.party[i].Equipment) {
                    state.party[i].Equipment = {};
                }
                let equipment = state.party[i].Equipment;
                state.party[i].Equipment = { ...state.party[i].Equipment, [slot] : item };
                break;
            }
        }
    },
    [types.UNEQUIP_ITEM] (state, payload) {
        let id = payload.characterId;
        let slot = (payload.slot == 'One-Handed' || payload.slot == 'Two-Handed') ? 'MainHand' : payload.slot;
        for(let i = 0; i < state.party.length; i++) {
            let ch = state.party[i];
            if(ch.CharacterId === id) {
                state.party[i].Equipment = { ...state.party[i].Equipment, [slot] : null };
                break;
            }
        }
    },
    [types.UPDATE_ITEM] (state, payload) {
        // this really only exists for quivers....
        let id = payload.characterId;
        let item = payload.item;
        for(let i = 0; i < state.party.length; i++) {
            let ch = state.party[i];
            if(ch.CharacterId === id) {
                let equipment = state.party[i].Equipment;
                if(equipment.Quiver) {
                    state.party[i].Equipment = { ...state.party[i].Equipment, Quiver : item };
                }
                let index = _.findIndex(state.party[i].Inventory,(i) => i.ItemId === item.ItemId);
                state.party[i].Inventory.splice(index, 1, item);
                break;
            }
        }
    },
    [types.SOLD_ITEM] (state, payload) {
        let id = payload.characterId;
        let itemId = payload.itemId;
        for(let i = 0; i < state.party.length; i++) {
            let ch = state.party[i];
            if(ch.CharacterId === id) {
                let index = _.findIndex(state.party[i].Inventory,(i) => i.ItemId === itemId);
                state.party[i].Gold += state.party[i].Inventory[i].Cost || 0;
                state.party[i].Inventory.splice(index, 1);
                break;
            }
        }
    },
    [types.DELETE_ITEM] (state, payload) {
        let id = payload.characterId;
        let itemId = payload.itemId;
        for(let i = 0; i < state.party.length; i++) {
            let ch = state.party[i];
            if(ch.CharacterId === id) {
                let index = _.findIndex(state.party[i].Inventory,(i) => i.ItemId === itemId);
                state.party[i].Inventory.splice(index, 1);
                break;
            }
        }
    }
}

export default {
    state,
    getters,
    actions,
    mutations
}