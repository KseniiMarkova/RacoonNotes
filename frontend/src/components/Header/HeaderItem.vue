<template>
    <div class="header-item">
        <RouterLink :to= "{name: item.link}" class="button-items">
            <h1>
                {{ item.heading }}
            </h1>
        </RouterLink>
    </div>
</template>

<script  setup lang="ts">
import type { PropType } from 'vue';
import type { HeaderItemsProps } from './models';
import { RouterLink } from 'vue-router'

const props = defineProps({
    item: {
        type: Object as PropType<HeaderItemsProps>,
        default: () => ({}),
    },
});
</script>

<style scoped>
h1 {
    font-style: normal;
    font-weight: 400;
    font-size: 32px;
    line-height: 40px;
    text-transform: uppercase;
}
.button-items{
    display: inline;
    border: none;
    background-color: transparent;
}
</style>