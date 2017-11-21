import Vue from 'vue'

export default {
    getItem() {
        return Vue.http.get('item');
    },
    getPurchasable() {
        return Vue.http.get('purchase');
    },
    getItemById(id) {
        return Vue.http.get('item/' + id);
    },
    postItem(item) {
        return Vue.http.post('item', item);
    },
    deleteItem(id) {
        return Vue.http.delete('item/' + id);
    },
    putItem(id, item) {
        return Vue.http.put('item/' + id, item);
    }
}
