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
      console.log(msg);
      Vue.prototype.$socket.emit("init", msg);
    };

  }
}

export default Logging;
