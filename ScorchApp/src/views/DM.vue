<template>
    <div class="dm-view">
        <vue-tabs>
            <v-tab title="Party">
                <dungeon-master-main></dungeon-master-main>
            </v-tab>

            <v-tab title="Inventory Manager">
                <dungeon-master-inventory-manager></dungeon-master-inventory-manager>
            </v-tab>

            <v-tab title="Campaign Notes">
                <dungeon-master-notes></dungeon-master-notes>
            </v-tab>

            <v-tab title="Log">
                This'll be the log... too many tabs?
            </v-tab>

        </vue-tabs>
    </div>
</template>

<script>
import { VueTabs, VTab } from 'vue-nav-tabs'
import { DungeonMasterMain, DungeonMasterNotes, DungeonMasterInventoryManager } from 'components/dungeonMaster'
import 'vue-nav-tabs/themes/vue-tabs.css'

export default {
    name : 'dm-view',
    components: {
        VueTabs,
        VTab,
        DungeonMasterMain,
        DungeonMasterNotes,
        DungeonMasterInventoryManager
    }
}
</script>

<style lang="scss" scoped>
.dm-view {
    margin: 0 auto;
    width: 90%;
}
</style>