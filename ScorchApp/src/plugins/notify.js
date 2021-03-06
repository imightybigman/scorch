import { NotificationAlert } from 'components/util'

const Notify = {
  install (Vue, options) {
    let baseNotification = function(msg){
      document.getElementById("notification-msg").innerHTML = msg;
      document.getElementById("notification-container").classList.add('notify-active'); 
      document.getElementById("notification-container").classList.add('visible');
      document.getElementById("notification-container").classList.remove('invisible');
    }

    let clearClasses = function(){
      setTimeout(() => {
        document.getElementById("notification-container").classList.add('invisible');
        document.getElementById("notification-container").classList.remove('visible');
        document.getElementById("notification-container").classList.remove('alert-info');
        document.getElementById("notification-container").classList.remove('alert-warning');
        document.getElementById("notification-container").classList.remove('alert-danger');
        document.getElementById("notification-container").classList.remove('alert-success');
        document.getElementById("notification-container").classList.remove('notify-active'); 
      }, 3950);
    }

    Vue.prototype.$notify = {};

    Vue.prototype.$notify.success = function (msg) {
      baseNotification(msg);
      document.getElementById("notification-container").classList.add('alert-success');      
      clearClasses();
    };

    Vue.prototype.$notify.failure = function (msg) {
      baseNotification(msg);
      document.getElementById("notification-container").classList.add('alert-danger');      
      clearClasses();
    };

    Vue.prototype.$notify.warning = function (msg) {
      baseNotification(msg);
      document.getElementById("notification-container").classList.add('alert-warning');    
      clearClasses();
    };

    Vue.prototype.$notify.info = function (msg) {
      baseNotification(msg);
      document.getElementById("notification-container").classList.add('alert-info');      
      clearClasses();
    };

    Vue.component('NotificationAlert', NotificationAlert);
  }
}

export default Notify;