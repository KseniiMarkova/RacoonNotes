<template>
    <div class="header-item">
        <h1>
            {{ item.heading }}
        </h1>
    </div>
</template>

<script  setup lang="ts">
import type { PropType } from 'vue';
import type { HeaderItemsProps } from './models';

const props = defineProps({
    item: {
        type: Object as PropType<HeaderItemsProps>,
        default: () => ({}),
    },
})
</script>

<style scoped>

h1 {
    font-style: normal;
    font-weight: 400;
    font-size: 32px;
    line-height: 40px;
    text-transform: uppercase;
}
</style>