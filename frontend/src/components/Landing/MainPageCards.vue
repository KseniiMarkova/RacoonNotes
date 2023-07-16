<template>
    <div class="wrapper-item" 
    :class="[{'wrapper-item-color':item.isBackgroundPink},
    {'wrapper-item-direction':item.isDescriptionOnRight},
    {'wrapper-item-registered':!item.description},]">
        <div class="details-image"> 
            <img :src="item.imageSrc" :alt="item.title" class="img-title">
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
    width: 90%;
    display: flex;
    flex-direction: row;
    justify-content: space-evenly;
    flex-wrap: nowrap;
    align-items: stretch;
    background: rgba(70, 130, 180, 0.46);
    border-radius: 4rem;
    margin: 1rem;
    overflow: hidden;
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
    margin: 2% 5% 1% 5%;
}
.details {
    max-width: 70%;
}

.details-title{
    display: flex;
    align-items: flex-end;
}
.details-image {
    display: flex;
    align-items: center;
}

.details-image img{
    max-width: 100%;
}

h2 {
    font-size: 24px;
    text-align: center;
    margin-bottom: 1rem;
    font-weight: bold;
}

h3 {
    font-size: 20px;
    font-weight: bold;
}

</style>