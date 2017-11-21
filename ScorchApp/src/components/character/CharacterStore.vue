<template>
    <div class="character-shop" >
    <modal v-if="showStoreModal" v-on:close="close">
        <div slot="header"><h3>Shop</h3></div>
        <div slot="body">
            <div v-if="selectedItem.ItemId" class="item-card">
                <div  class ="border border-dark item-card-inner">
                    <div class="item-card-detail">
                        <item-card :item="selectedItem"></item-card>
                    </div>
                    <div class="item-qty-entry d-flex">
                        <div class="input-group">
                          <button class="purchase-btn btn btn-success" @click="buyItem">Purchase</button>
                        </div>
                    </div>
                </div>
            </div>
            <div class="item-searcher border border-dark flex-column">
                <searcher @search-row-selected="searchItem" :search-data="searchItems" :limit-per-page="5" :column-keys="columnKeys"/>
            </div>
        </div>
        <div slot="footer">
            <button class="purchase-btn btn btn-primary" @click="close">Close</button>
        </div>
    </modal>
    <div class="card">
      <div class="card-header">Actions</div>
      <div class="card-body">
        <button class="shop-btn btn btn-warning" @click="showStoreModal = true">Shop</button>
      </div>
    </div>
    </div>
</template>

<script>
import { Modal, Searcher } from 'components/util'
import { ItemCard } from 'components/items'
import { ItemService, CharacterService } from 'services'

export default {
    name: 'character-store',
    props: ['character'],
    data() {
        return {
            showStoreModal: false,
            selectedItem: {},
            columnKeys: ['Name', 'ItemClass', 'Cost', 'AC', 'Damage', 'Slot'],
            itemQty: 1
        }
    },
    async created() {
      await this.$store.dispatch('getDisplayItems');
    },
    computed: {
        searchItems() {
            return this.$store.getters.items;
        }
    },
    methods: {
        close(){
            $("body").removeClass("modal-open");
            this.showStoreModal = false;
            this.selectedItem = {};
        },
        async searchItem(item){
            if(item){
                let response = {};
                response = await ItemService.getItemById(item.ItemId);
                this.selectedItem = response.body;
            }
        },
        async buyItem(){
            let success = true;
            let payload = {};
            payload.body = {};
            payload.characterId = this.character.CharacterId;
            let currentGold = this.character.Gold;
            if (this.selectedItem.Cost <= currentGold){
                let successMsg = `You have purchased a(n) ${this.selectedItem.ItemClass} with the name of ${this.selectedItem.Name} for ${this.selectedItem.Cost} gold.`;
                let itemAdded = {};
                itemAdded.ItemId = this.selectedItem.ItemId;
                itemAdded.Count = parseInt(this.itemQty);
                payload.body.Gold = currentGold - this.selectedItem.Cost;
                try{
                    await CharacterService.postCharacterItem(this.character.CharacterId, itemAdded);
                    await this.$store.dispatch('updateCharacter', payload);
                  }
                  catch(errorResponse){
                    console.log(`Failed to add item to char : ${this.character.CharacterId} error : ${errorResponse.bodyText}`);
                    this.$notify.failure('Failed to give item to characters');
                  }
                if(success && this.selectedItem.ItemId){
                    this.$notify.success(successMsg);
                    this.$logging.update();
                }
            } else {
              this.$notify.failure('You do not have enough gold for this item.');
            }
        }
    },
    components: {
        Modal,
        Searcher,
        ItemCard
    }
}
</script>

<style lang="scss" scoped>
.stats-leveling {
    width: 50%;
    margin-bottom: 1%;
    .stats-leveling-buttons {
        float: right;
    }
}

.new-ability {
    margin-bottom: 1%;
}
.modify-stats {
    margin-bottom: 1%;
}

.hp-input {
    width: 5%;
    border-radius: 5px;
    padding-left: 1%;
}

.pulse {
  display: block;
  cursor: pointer;
  box-shadow: 0 0 0 #cca92c;
  animation: pulse 1s infinite;
}
.pulse:hover {
  animation: none;
}

@-webkit-keyframes pulse {
  0% {
    -webkit-box-shadow: 0 0 0 0 rgba(204,169,44, 0.4);
  }
  70% {
      -webkit-box-shadow: 0 0 0 10px rgba(204,169,44, 0);
  }
  100% {
      -webkit-box-shadow: 0 0 0 0 rgba(204,169,44, 0);
  }
}
@keyframes pulse {
  0% {
    -moz-box-shadow: 0 0 0 0 rgba(204,169,44, 0.4);
    box-shadow: 0 0 0 0 rgba(204,169,44, 0.4);
  }
  70% {
      -moz-box-shadow: 0 0 0 10px rgba(204,169,44, 0);
      box-shadow: 0 0 0 10px rgba(204,169,44, 0);
  }
  100% {
      -moz-box-shadow: 0 0 0 0 rgba(204,169,44, 0);
      box-shadow: 0 0 0 0 rgba(204,169,44, 0);
  }
}
.purchase-btn {
  margin-left: auto;
}
</style>
