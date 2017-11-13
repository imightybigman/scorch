import Vue from 'vue'
import Vuex from 'vuex'
import charactersModule from './modules/charactersModule'
import spellsModule from './modules/spellsModule'
import itemModule from './modules/itemModule'
import classesModule from './modules/classesModule'

Vue.use(Vuex)

export default new Vuex.Store({
    modules: {
        charactersModule,
        itemModule,
        classesModule,
        spellsModule
    }
});