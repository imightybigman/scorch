<template>
    <div class="dm-view">
        <vue-tabs>
            <v-tab title="General">
                <dungeon-master-main></dungeon-master-main>
            </v-tab>

            <v-tab title="Battle Planner">
            Second tab content
            </v-tab>

            <v-tab title="Campaign Notes">
                <dungeon-master-notes></dungeon-master-notes>
            </v-tab>
        </vue-tabs>
    </div>
</template>

<script>
import { VueTabs, VTab } from 'vue-nav-tabs'
import { DungeonMasterMain, DungeonMasterNotes } from 'components/dungeonMaster'
import 'vue-nav-tabs/themes/vue-tabs.css'

export default {
    name : 'dm-view',
    components: {
        VueTabs,
        VTab,
        DungeonMasterMain,
        DungeonMasterNotes
    }
}
</script>

<style lang="scss" scoped>
.dm-view {
    margin: 0 auto;
    width: 90%;
}
</style>