<template>
<div class="accordian">
    <div class="accordian-header-background" :role="id + '-role'" >
        <div class="accordian-header" data-toggle="collapse" :data-target="'#' + id" aria-expanded="false" :aria-controls="id + '-controls'">
            <span class="header-text">{{ header }}</span>
        </div>
    </div>
    <div :id="id" class="accordian-body-container collapse" :role="id + '-panel'" :aria-labelledby="id + '-controls'" :data-parent="'#' + 'parent'">
        <div class="accordian-body">
            <slot name="body">Default Body</slot>
        </div>
    </div>
</div>
</template>

<script>

import { v4 as createGuid } from 'uuid' 

export default {
    id: 'accordian',
    props: ['parent', 'header'],
    computed: {
        id() {
            return createGuid();
        }
    }
}
</script>

<style lang="scss" scoped>
.accordian {
    display: flex;
    flex-direction: column;
}

.accordian-header-background {
    padding: 1%;
    border-radius: 10px;
    background: #EB5757;
    background: -webkit-linear-gradient(to top, #000000, #EB5757);
    background: linear-gradient(to top, #000000, #EB5757);
    margin-bottom: 1%;
}

.accordian-header {
    border-radius: 8px;
    padding: 2%;
    display: flex;
    flex: 1 0;
    align-items: center;
    background: #200122;
    background: -webkit-linear-gradient(to top, #6f0000, #200122);
    background: linear-gradient(to top, #6f0000, #200122);
    color: white;
    font-weight: bold;
    cursor: pointer;
    .header-text {
        font-size: 1.2em;
    }
}

.accordian-body {
    border-radius: 8px;
    padding: 4%;
    background: #200122;
    background: -webkit-linear-gradient(to top, #6f0000, #200122);
    background: linear-gradient(to top, #6f0000, #200122);
    color: white;
}

</style>
