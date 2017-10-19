import Vue from 'vue'

export default {
    getItem() {
        return Vue.http.get('item');
    },
    postItem(item) {
        return Vue.http.post('item', item);
    },
    deleteItem(id) {
        return Vue.http.delete('item/' + id);
    }
}