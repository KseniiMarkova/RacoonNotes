<template>
    <div class="wrapper-item" :class="{'wrapper-item-even':isMainPageCardEven}">
        <div class="details-image">
            <img :src="item.imageSrc" alt="Photo month">
        </div>
        <div class="details">
            <h2>
                {{item.title}}
            </h2>
            <h3>
                {{item.description}}
            </h3>
        </div>
    </div>
</template>

<script setup lang="ts">
import { computed, type PropType } from 'vue'
import type { MainPageItemProps } from './models';
const props = defineProps({
    item: {
        type: Object as PropType<MainPageItemProps>,
        default: () => ({}),
    },
    index: Number,
})
const isMainPageCardEven = computed(() => {
  return (props.index ?? 1) % 2 === 0;
})

</script>

<style scoped>
.wrapper-item {
    height: 25rem;
    width: 80rem;
    display: flex;
    flex-direction: row;
    justify-content: space-evenly;
    flex-wrap: nowrap;
    padding: 1rem;
    align-items: stretch;
    justify-content: space-evenly;
    background: rgba(70, 130, 180, 0.46);
    border-radius: 4rem;
    margin: 1rem;
}

.wrapper-item-even{
    flex-direction: row-reverse;
    background: #B3A2B3;
}

.details {
    max-width: 40rem;
}

.details-image {
    display: flex;
    align-items: center;
}

h2 {
    font-size: 24px;
    text-align: center;
}

h3 {
    font-size: 20px;
}

img {
    max-width: 15rem;
    max-height: 20rem;
}
</style>