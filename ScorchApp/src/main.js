// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import 'babel-core/register'
import 'babel-polyfill'
import Vue from 'vue'
import VueResource from 'vue-resource'
import App from './App'
import router from './router'
import store from './store'
import VueSocketio from 'vue-socket.io';
import { Notify, Logging } from 'plugins'
import 'bootstrap'
import 'bootstrap/dist/css/bootstrap.min.css'
import 'font-awesome/scss/font-awesome.scss'
import 'rpg-awesome/scss/rpg-awesome.scss'
import 'styles/styles.scss'
import ToggleButton from 'vue-js-toggle-button'


Vue.use(VueSocketio, process.env.SOCKET_HOST, store);
Vue.use(VueResource);
Vue.use(Notify);
Vue.use(Logging);
Vue.use(ToggleButton);
Vue.config.productionTip = false
Vue.url.options.root = process.env.API_HOST;
//Vue.url.options.root = 'http://localhost:51358/api';

/* eslint-disable no-new */
new Vue({
  el: '#app',
  store,
  router,
  template: '<App/>',
  components: { App }
})
