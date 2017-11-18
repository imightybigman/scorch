const Logging = {
  install (Vue, options) {
    Vue.prototype.$logging = {};

    Vue.prototype.$logging.info = function (msg) {
      Vue.prototype.$socket.emit("newLog", msg);
    };
    Vue.prototype.$logging.dm = function (msg) {
      Vue.prototype.$socket.emit("dm", msg);
    };
    Vue.prototype.$logging.init = function (msg) {
      Vue.prototype.$socket.emit("init", msg);
    };
    Vue.prototype.$logging.notify = function (msg) {
      Vue.prototype.$socket.emit("notify", msg);
    };
    Vue.prototype.$logging.update = function () {
      Vue.prototype.$socket.emit("updateParty");
    };
  }
}

export default Logging;
