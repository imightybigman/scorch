<template>
<div>
  <div class="home-logo-container">
    <router-link :to="'/'">
      <img class="home-logo" src="../assets/DnD_transparent.png">
    </router-link>
  </div>
  <div class="character-view d-flex flex-wrap" v-if="character">
    <div class="d-flex flex-column party-navigation border">
      <div class="character-cards-container" v-for="(char, index) in party" @click="goTo(char.CharacterId)" :key="index">
        <character-tile :character="char"></character-tile>
      </div>
    </div>
    <div class="d-flex flex-column character-info border">
      <div class="d-flex flex-column character-basic-info">
        <h4>
          <strong>{{ name }}</strong>
          <small>Lv. {{ character.Level }}</small>
        </h4>
        <div class="gold-counter"><img class="gold" src="~assets/icons/gold.png"/> {{ character.Gold }} </div>
        <hp-bar :character="character"></hp-bar>
        <exp-bar :character="character"></exp-bar>
      </div>
      <div class="d-flex flex-row flex-wrap character-screen">
        <div id="character-details" class="d-flex flex-column character-details">
          <h4>Character Info</h4>
          <character-stats-card :stats="character.Stats" :proficiency="character.Proficiency" :characterClass="characterClass" :level="character.Level"></character-stats-card>
          <character-bio-card :character="character"></character-bio-card>
          <character-skills-card :skills="character.Skills"></character-skills-card>
          <character-spells-card :characterId="character.CharacterId" :spells="character.Spells"></character-spells-card>
          <div v-if="characterClass">
              <spell-slots v-if="characterClass.SpellSlots" :level="character.Level" :spellSlots="characterClass.SpellSlots"></spell-slots>
              <bonus-features :level="character.Level" :feature="characterClass.BonusFeatures" :displayName="characterClass.Name"></bonus-features>
              <bonus-features v-if="character.Class === 'Fighter'" :level="character.Level" :feature="characterClass.MartialArchetype.Features" :displayName="characterClass.MartialArchetype.Name"></bonus-features>
              <bonus-features v-if="character.Class === 'Paladin'" :level="character.Level" :feature="characterClass.SacredOath.Features" :displayName="characterClass.SacredOath.Name"></bonus-features>
              <bonus-features v-if="character.Class === 'Bard'" :level="character.Level" :feature="characterClass.CollegeFeatures.Features" :displayName="characterClass.CollegeFeatures.Name"></bonus-features>
              <bonus-features v-if="character.Class === 'Ranger'" :level="character.Level" :feature="characterClass.Archetype.Features" :displayName="characterClass.Archetype.Name"></bonus-features>
              <bonus-features v-if="character.Class === 'Warlock'" :level="character.Level" :feature="characterClass.OtherworldyPatron.Features" :displayName="characterClass.OtherworldyPatron.Name"></bonus-features>
              <companion v-if="character.Class === 'Ranger'" :companion="characterClass.Companion"></companion>
          </div>
        </div>
        <div class="d-flex flex-column character-equip">
          <h4>Character Equip</h4>
          <character-equip :character="character"></character-equip>
        </div>

      </div>
      <div class="d-flex notes black-border" style="overflow: scroll;">
        <ul style="padding: 0;">
          <li v-for="(log, index) in logs" class="list-unstyled" :key="index">
            {{ log.message }} <br />
          </li>
        </ul>
      </div>
    </div>
    <div class="d-flex flex-column character-other border">
      <character-leveling :character="character" :characterClass="characterClass"></character-leveling>
      <dice-roller :name="this.user"></dice-roller>
      <inventory :characterId="character.CharacterId"></inventory>
    </div>
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
  import { DiceRoller, Modal } from 'components/util'
  import { BonusFeatures, SpellSlots, Companion } from 'components/classFeatures'
  export default {
    name: 'character-view',
    user: '',
    data() {
      return {
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
      }
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
      BonusFeatures,
      SpellSlots,
      Companion
    }
  }

</script>

<style lang="scss" scoped>
  .black-border {
    border: 1px solid black;
    box-sizing: border-box;
  }

  .character-view {
    width: 100%;
  }

  .party-navigation {
    padding: 1%;
    flex: 1 0 auto;
    overflow-y: scroll;

    .character-cards-container {
      margin-bottom: 1%;
      border-radius: 10px;
    }

  }

  .character-info {
    flex: 2 0 auto;

    .character-screen {
      flex: 1 0 auto;

      >div {
        margin: 1%;
      }

      .character-details {
        flex: 1 0;
        > div {
          margin-bottom: 1%;
        }
      }

      .character-equip {
        flex: 1 0 auto;
      }

    }
    .character-basic-info {
      flex: 1 0 auto;
      padding: 1% 1% 0 1%;
    }
    .notes {
      flex: 1 0 auto;
      height: 200px;
    }
  }

  .character-other {
    flex: 4;
  }

.gold {
  width: 2%;
  height: 2%;
}
.gold-counter {
  float: right;
}

.level-btn {
  color: white;
}
</style>
