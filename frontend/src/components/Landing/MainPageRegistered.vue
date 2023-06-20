<template>
    <div class="wrapper">
        <MainPageCards v-for="(item, index) in cardItems" :key="index" :item="item" />
    </div>
    <div class="notes-block">
        <div class="notes-item-block">
            <img src="src\\svg\\Notes.svg" alt="Photo of block" class="img-title" />
            <h2>
                Notes
            </h2>
        </div>
        <div class="list-notes-block">
            <h3 class="list-notes-title">
                List of Notes:
            </h3>
            <ul>
                <ol>page1</ol>
                <ol>name of page 2</ol>
                <ol>a long name of page 3</ol>
                <ol>a reale reale reale long name page 4</ol>
            </ul>
        </div>
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
    display: flex;
    flex-direction: row;
    flex-wrap: nowrap;
    justify-content: space-evenly;
    align-items: center;
    
}

.notes-block{
    height: 25rem;
    width: 90%;
    display: flex;
    flex-direction: row;
    align-items: center;
    justify-content: space-evenly;
    background: #B3A2B3;
    border-radius: 4rem;
    margin: 1% 5% 1% 5%;
    padding: 1rem;
}

.notes-item-block{
    display: flex;
    flex-direction: column;
    align-items: center;    
}

.list-notes-block{
    display: flex;
    flex-direction: column;
    align-items: flex-start;
    height: 100%;
    width: 70%;
}

.list-notes-title{
    display: flex;
    justify-content: center;
    align-items: center;
    width: 100%;
    font-weight: bold;
}

h2 {
    font-size: 24px;
    text-align: center;
    margin-top: 1rem;
}

.img-title{
    margin-top: 1rem;
}
</style>