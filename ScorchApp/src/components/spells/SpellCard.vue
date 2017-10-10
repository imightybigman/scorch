<template>
  <div class="spell-detail">
    <div class="card">
      <div class="card-header">
        Spells
      </div>
      <div class="card-body">
        <div class="list-group spell-list">
            <a v-for="(spell, index) in spells" :key="index" class="list-group-item list-group-item-action flex-column align-items-start">
              <div class="justify-content-between">
                <h5 class="mb-1">{{ spell.Name }}</h5>
                <small>Level {{ spell.Level }}</small>
              </div>
              <p class="mb-1">Damage: {{ spell.Damage }}</p>
              <p class="mb-1">Spell Type: {{ spell.SpellType }}</p>
              <p class="mb-1">Range: {{ spell.Range }}</p>         
            </a>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'spell-detail-card',
  props: ['spells', 'listHeight'],
  data() {
    return {
    }
  },
  methods :{

  }
}
</script>

<style lang="scss" scoped>

.spell-list {
  max-height: 300px;
  overflow-y: scroll;
}


</style>
