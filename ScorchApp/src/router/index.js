import Vue from 'vue'
import VueResource from 'vue-resource'
import Router from 'vue-router'
import Home from '@/views/Home'
import DM from '@/views/DM'
import Character from '@/views/Character'

Vue.use(Router)
Vue.use(VueResource);
Vue.url.options.root = "https://dnd-api.imightybigman.com/api"
//Vue.url.options.root = "http://localhost:5000/api"

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
