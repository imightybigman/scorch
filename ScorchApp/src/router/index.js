import Vue from 'vue'
import VueResource from 'vue-resource'
import Router from 'vue-router'
import Home from '@/views/Home'
import DM from '@/views/DM'
import Character from '@/views/Character'

Vue.use(Router)
Vue.use(VueResource);

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Home',
      component: Home
    },
    {
      path: '/DM',
      name: 'DM View',
      component: DM
    },
    {
      path: '/Character/:characterId',
      name: 'Character View',
      component: Character,
      props: true
    }
  ]
})
