<template>
    <div class="dm-view">
        <vue-tabs>
            <v-tab title="Party">
                <dungeon-master-main></dungeon-master-main>
            </v-tab>

            <v-tab title="Data Manager">
                <dungeon-master-inventory-manager></dungeon-master-inventory-manager>
            </v-tab>

            <v-tab title="Campaign Notes">
                <dungeon-master-story></dungeon-master-story>
            </v-tab>

            <v-tab title="Log">
                <dungeon-master-logs></dungeon-master-logs>
            </v-tab>
            <v-tab title="Fight">
                <dungeon-master-fight></dungeon-master-fight>
            </v-tab>

        </vue-tabs>
    </div>
</template>

<script>
import { VueTabs, VTab } from 'vue-nav-tabs'
import { DungeonMasterMain, DungeonMasterStory, DungeonMasterLogs, DungeonMasterFight, DungeonMasterInventoryManager } from 'components/dungeonMaster'
import 'vue-nav-tabs/themes/vue-tabs.css'

export default {
    name : 'dm-view',
    components: {
        VueTabs,
        VTab,
        DungeonMasterMain,
        DungeonMasterStory,
        DungeonMasterInventoryManager,
        DungeonMasterLogs,
        DungeonMasterFight
    }
}
</script>

<style lang="scss" scoped>
.dm-view {
    margin: 0 auto;
    width: 90%;
}
</style>
