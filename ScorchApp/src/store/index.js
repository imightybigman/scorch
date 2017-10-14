import Vue from 'vue'
import Vuex from 'vuex'
import characters from './modules/characters'
import store from './modules/store'

Vue.use(Vuex)

export default new Vuex.Store({
    modules: {
        characters,
        store
    }
});