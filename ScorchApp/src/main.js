// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import 'babel-core/register'
import 'babel-polyfill'
import Vue from 'vue'
import VueResource from 'vue-resource'
import App from './App'
import router from './router'
import store from './store'
import 'bootstrap'
import 'bootstrap/dist/css/bootstrap.min.css'
import 'font-awesome/scss/font-awesome.scss'
import VueSocketio from 'vue-socket.io';

Vue.use(VueResource);
Vue.config.productionTip = false
Vue.url.options.root = "https://dnd-api.imightybigman.com/api"
//Vue.url.options.root = "http://localhost:5000/api"

Vue.use(VueSocketio, 'http://localhost:3000', store);


/* eslint-disable no-new */
new Vue({
  el: '#app',
  store,
  router,
  template: '<App/>',
  components: { App }
})
