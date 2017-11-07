import Vue from 'vue'

export default {
    getClass(name) {
        return Vue.http.get('class/' + name);
    }
}