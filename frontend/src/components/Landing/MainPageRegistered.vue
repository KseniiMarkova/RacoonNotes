<template>
    <div class="wrapper">
        <MainPageCards v-for="(item, index) in cardItems" :key="index" :item="item"/>
    </div>
</template>

<script setup lang="ts">
import MainPageCards from './MainPageCards.vue';
import type { MainPageItemProps } from './models';

    const cardItems: MainPageItemProps[] = [
    {
        title: 'Month',
        imageSrc: 'src\\svg\\MonthlyCalendar.svg',
    },
    {
        title: 'Week',
        imageSrc: "src\\svg\\Weekly Calendar.svg",
        isBackgroundPink: true,
    },
    {
        title: 'Day',
        imageSrc: "src\\svg\\Daily Calendar.svg",
    },
    ];
</script>

<style scoped>
.wrapper {
    background-color: #EEE5DE;
    display: flex;
    flex-direction: row;
    flex-wrap: nowrap;
    justify-content: space-evenly;
    align-items: center;
    padding: 1rem;
}
</style>