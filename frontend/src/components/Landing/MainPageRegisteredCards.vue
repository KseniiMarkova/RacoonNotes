<template>
    <div class="wrapper-item" :class="{'wrapper-item-even':isMainPageRegisteredCardEven}">
        <div class="datails-image">
            <img :src="item.imageSrc" alt="Photo of block" />
        </div>
        <h2 class="heading">
            {{ item.title }}
        </h2>
    </div>
</template>

<script setup lang="ts">
import { computed, type PropType } from 'vue';
import type { MainPageItemProps } from './models';

    const props = defineProps({
        item: {
            type: Object as PropType<MainPageItemProps>,
            default: () => ({}),
        },
        index: Number,
    })
    const isMainPageRegisteredCardEven = computed(() => {
        return (props.index ?? 1) % 2 === 0;
    })
</script>

<style scoped>

</style>