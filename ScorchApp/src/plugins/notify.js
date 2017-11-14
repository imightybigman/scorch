import { NotificationAlert } from 'components/util'

const Notify = {
  install (Vue, options) {
    Vue.prototype.$notify = function (msg, msgType) {
      document.getElementById("notification-msg").innerHTML = msg;
      document.getElementById("notification-container").classList.add('notify-active'); 
      
      let classAdded = '';
      if(msgType === 'success'){
        classAdded = 'alert-success';
      }
      else if(msgType === 'failure'){
        classAdded = 'alert-danger';        
      }
      else if(msgType === 'warning'){
        classAdded = 'alert-warning';
      }
      else{
        classAdded = 'alert-info';        
      }

      document.getElementById("notification-container").classList.add(classAdded);

      setTimeout(() => {
        document.getElementById("notification-container").classList.remove(classAdded);
        document.getElementById("notification-container").classList.remove('notify-active'); 
      }, 4000);   
    }

    Vue.component('NotificationAlert', NotificationAlert)
  }
}

export default Notify;