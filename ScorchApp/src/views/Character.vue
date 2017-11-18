<template>
<div class="character-view d-flex flex-wrap" v-if="character">
  <div class="d-flex flex-column party-navigation border scrollbar">
    <div class="character-cards-container" v-for="(char, index) in party" @click="goTo(char.CharacterId)" :key="index">
      <character-tile :character="char"></character-tile>
    </div>
  </div>
  <div class="d-flex flex-column character-info border">
    <div class="d-flex flex-row character-basic-info">
        <character-tile :character="character"></character-tile>
<<<<<<< HEAD
        <character-stats-card slot="body" :stats="character.Stats" :level="character.Level" :characterClass="characterClass || {}"></character-stats-card>
=======
        <character-stats-card :stats="character.Stats" :level="character.Level" :characterClass="characterClass || {}"></character-stats-card>                
>>>>>>> dnd/dev
    </div>
    <div class="d-flex flex-row justify-content-between character-screen">
      <div class="d-flex flex-column character-details">
        <accordian :header="'Bio'">
          <character-bio-card slot="body" :character="character"></character-bio-card>
        </accordian>
        <accordian :header="'Skills'">
          <character-skills-card slot="body" :skills="character.Skills"></character-skills-card>
        </accordian>
        <div v-if="characterClass">
            <accordian :header="characterClass.Name">
              <bonus-features slot="body" :level="character.Level" :feature="characterClass.BonusFeatures"></bonus-features>
            </accordian>
            <accordian v-if="character.Class === 'Fighter'" :header="characterClass.MartialArchetype.Name">
              <bonus-features slot="body" :level="character.Level" :feature="characterClass.MartialArchetype.Features"></bonus-features>
            </accordian>
            <accordian v-if="character.Class === 'Paladin'" :header="characterClass.SacredOath.Name">
              <bonus-features slot="body" :level="character.Level" :feature="characterClass.SacredOath.Features"></bonus-features>
            </accordian>
            <accordian v-if="character.Class === 'Bard'" :header="characterClass.CollegeFeatures.Name">
              <bonus-features slot="body" :level="character.Level" :feature="characterClass.CollegeFeatures.Features"></bonus-features>
            </accordian>
            <accordian v-if="character.Class === 'Ranger'" :header="characterClass.Archetype.Name">
              <bonus-features slot="body" :level="character.Level" :feature="characterClass.Archetype.Features"></bonus-features>
            </accordian>
            <accordian v-if="character.Class === 'Warlock'" :header="characterClass.OtherworldyPatron.Name">
              <bonus-features slot="body" :level="character.Level" :feature="characterClass.OtherworldyPatron.Features"></bonus-features>
            </accordian>
            <accordian v-if="character.Class === 'Ranger'" :header="'Companion'">
              <companion slot="body" :companion="characterClass.Companion"></companion>
            </accordian>
        </div>
      </div>
      <div class="d-flex flex-column character-advanced-info">
        <vue-tabs>
          <v-tab title="Equip">
            <character-equip :character="character"></character-equip>
          </v-tab>
          <v-tab title="Spells">
          <div class="d-flex flex-column spells card">
            <spell-card :character="character" :spells="character.Spells" :characterClass="characterClass || {}"></spell-card>
          </div>
          </v-tab>
        </vue-tabs>
      </div>
    </div>
    <div class="d-flex notes black-border scrollbar">
      <ul>
        <li v-for="(log, index) in logs" class="list-unstyled" :key="index">
          {{ log.message }} <br />
        </li>
      </ul>
    </div>
  </div>
  <div class="d-flex flex-column character-other border">
    <character-leveling :character="character" :characterClass="characterClass"></character-leveling>
    <dice-roller :name="name" :dex="getDexMod()" :id="getCharId()"></dice-roller>
    <inventory :characterId="character.CharacterId"></inventory>
  </div>
</div>
</template>

<script>

import {  CharacterTile,
          CharacterEquip,
          CharacterStatsCard,
          CharacterDetailCard,
          CharacterSkillsCard,
          CharacterSpellsCard,
          CharacterBioCard,
          CharacterLeveling,
          ExpBar,
          HpBar } from 'components/character'

import { Inventory } from 'components/inventory'
import { SpellInfo, SpellList, SpellCard } from 'components/spells'
import { DiceRoller, Modal, Accordian } from 'components/util'
import { BonusFeatures, SpellSlots, Companion } from 'components/classFeatures'
import { AbilityModifierService } from 'services'
import { VueTabs, VTab } from 'vue-nav-tabs'
import 'vue-nav-tabs/themes/vue-tabs.css'

export default {
  name: 'character-view',
  data() {
    return {
      user: '',
      logs: [

      ]
    }
  },
  async created() {
    await this.$store.dispatch('getParty');
    // we want to load each class when we need them cuz they are biiiiiiiggggggg
    await this.$store.dispatch('loadClass', this.character.Class);
  },
  props: ['characterId'],
  sockets: {
    newLog: function(message) {
      this.logs.unshift({ message: message });
    },
    notify: function(data) {
      if (this.characterId === data.user){
        if (data.type == 'success') {
          this.$notify.success(data.message);
        } else if (data.type == 'warning') {
          this.$notify.failure(data.message);
        } else {
          this.$notify.info(data.message);
        }
      }
    }
  },
  computed: {
    name() {
        let firstName = this.character.Firstname || '';
        let lastName = this.character.Lastname || '';
        this.user = `${firstName} ${lastName}`;
        return `${firstName} ${lastName}`;
    },
    party() {
      return this.$store.getters.myParty;
    },
    character() {
      return this.$store.getters.getCharacterById(this.characterId);
    },
    characterClass() {
      return this.$store.getters.getClass(this.character.Class);
    }
  },
  methods: {
    goTo(characterId) {
      this.$router.push('/character/' + characterId)
    },
    getDexMod() {
        return AbilityModifierService.getAbilityModifier(this.character.Stats.Dexterity);
    },
    getCharId() {
      return this.characterId;
    },
  },
  watch: {
    async character(newCharacter) {
      await this.$store.dispatch('loadClass', newCharacter.Class);
    }
  },
  components: {
    CharacterTile,
    CharacterStatsCard,
    CharacterDetailCard,
    CharacterSkillsCard,
    CharacterSpellsCard,
    CharacterEquip,
    CharacterBioCard,
    CharacterLeveling,
    ExpBar,
    HpBar,
    Inventory,
    DiceRoller,
    Modal,
    Accordian,
    BonusFeatures,
    SpellSlots,
    Companion,
    VueTabs,
    VTab,
    SpellInfo,
    SpellList,
    SpellCard
  }
}

</script>

<style lang="scss" scoped>
@import '~styles/shared.scss';

  .black-border {
    border: 1px solid black;
    box-sizing: border-box;
  }

  .character-view {
    width: 100%;
  }

  .party-navigation {
    padding: 1%;
    flex: 1 1 auto;
    overflow-y: scroll;

    .character-cards-container {
      margin-bottom: 1%;
      border-radius: 10px;
    }
  }

  .character-info {
    flex: 2 0 auto;

    .character-screen {
      flex: 4 0 auto;
      padding: 1% 0;

      .character-details {
        flex: 1 0;
        margin: 0 1%;
        > div {
          margin-bottom: 1%;
        }
      }

      .character-advanced-info {
        flex: 2 0;
        min-height: 600px;
      }

    }
    .character-basic-info {
      flex: 1 0 auto;
      padding: 1% 1% 0 1%;
    }
    .notes {
      flex: 2 0 auto;
      height: 200px;
      overflow-y: scroll;
      margin: 0 1%;
    }
  }

  .character-other {
    flex: 5;
  }

.level-btn {
  color: white;
  }
</style>
