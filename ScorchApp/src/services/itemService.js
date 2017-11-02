import Vue from 'vue'

export default {
    getItem() {
        return Vue.http.get('item');
    },
    getItemById(id) {
        return Vue.http.get('item/' + id);
    },
    postItem(item) {
        return Vue.http.post('item', item);
    },
    deleteItem(id) {
        return Vue.http.delete('item/' + id);
    }
}