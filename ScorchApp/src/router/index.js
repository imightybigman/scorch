import Vue from 'vue'
import Router from 'vue-router'
import Home from 'views/Home'
import DM from 'views/DM'
import Character from 'views/Character'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Home',
      component: Home
    },
    {
      path: '/dm',
      name: 'DM View',
      component: DM
    },
    {
      path: '/character/:characterId',
      name: 'Character View',
      component: Character,
      props: true
    }
  ]
})
