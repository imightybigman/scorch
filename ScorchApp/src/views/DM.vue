<template>
    <div class="dm-view">
        <vue-tabs>
            <v-tab title="DM Main">
                <dungeon-master-main></dungeon-master-main>
            </v-tab>

            <v-tab title="Second tab">
            Second tab content
            </v-tab>

            <v-tab title="Third tab">
            Third tab content
            </v-tab>
        </vue-tabs>
    </div>
</template>

<script>
import { VueTabs, VTab } from 'vue-nav-tabs'
import DungeonMasterMain from '@/components/DungeonMasterMain.vue'
import 'vue-nav-tabs/themes/vue-tabs.css'

export default {
    name : 'dm-view',
    components: {
        VueTabs,
        VTab,
        DungeonMasterMain
    }
}
</script>

<style lang="scss" scoped>
.dm-view {
    margin: 0 auto;
    width: 90%;
}
</style>