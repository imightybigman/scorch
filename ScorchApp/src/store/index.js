import Vue from 'vue'
import Vuex from 'vuex'
import * as getters from './getters'
import characters from './modules/characters'

Vue.use(Vuex)

export default new Vuex.Store({
    modules: {
        characters
    }
});