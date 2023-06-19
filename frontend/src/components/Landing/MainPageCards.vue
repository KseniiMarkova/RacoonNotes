<template>
    <div class="wrapper-item" 
    :class="[{'wrapper-item-color':item.isBackgroundPink},
    {'wrapper-item-direction':item.isDescriptionOnRight},
    {'wrapper-item-registered':!item.description},]">
        <div class="details-image">
            <img :src="item.imageSrc" alt="Photo of block">
        </div>
        <div v-if="item.description" class="details">
            <h2>
                {{item.title}}
            </h2>
            <h3>
                {{item.description}}
            </h3>
        </div>
        <div v-else class="details-title">
            <h2>
                {{ item.title }}
            </h2>
        </div>
    </div>
</template>

<script setup lang="ts">
import type { PropType } from 'vue';
import type { MainPageItemProps } from './models';

const props = defineProps({
    item: {
        type: Object as PropType<MainPageItemProps>,
        default: () => ({}),
    },
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

.wrapper-item-color{
    background: #B3A2B3;
}

.wrapper-item-direction{
    flex-direction: row-reverse;
}

.wrapper-item-registered{
    flex-direction: column;
    align-items: center;
}
.details {
    max-width: 40rem;
}

.details-title{
    display: flex;
    align-items: flex-end;
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