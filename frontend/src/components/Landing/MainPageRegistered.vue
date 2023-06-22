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
            <h2 class="list-notes-title">
                List of Notes:
            </h2>
            <div class="list-container">
                <ol class="two-coluumn-list">
                    <li>page1</li>
                    <li>name of page 2</li>
                    <li>a long name of page 3</li>
                    <li>a reale reale reale long name page 4</li>
                    <li>page1</li>
                    <li>name of page 2</li>
                    <li>page1</li>
                    <li>name of page 2</li>
                    <li>a long name of page 3</li>
                    <li>a reale reale reale long name page 4</li>
                    <li>page1</li>
                    <li>name of page 2</li>
                </ol>
            </div>
            <button class="list-notes-button">more...</button>
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
    position: relative;
}

.notes-item-block{
    display: flex;
    flex-direction: column;
    align-items: center;   
    margin: 1rem; 
}

h2 {
    margin-bottom: 1rem;
}

.img-title{
    margin: 1rem 0 1rem 0;
}
.list-notes-block{
    height: 25rem;
    width: 70%;
    display: flex;
    flex-direction: column;
    align-items: flex-start;
    justify-content: flex-start;
}

.list-notes-title{
    display: flex;
    justify-content: center;
    align-items: center;
    width: 100%;
    height: 10%;
    margin: 1rem 0 1rem 0;
}

.list-notes-button{
    display: flex;
    width: 100%;
    height: 10%;
    justify-content: center;
    background: none;
    border: none;
    padding: 0;
    font-size: 24px;
    font-family: 'Over the Rainbow';
    font-style: normal;
    color: rgba(25, 25, 112, 0.8);
    cursor: pointer;
    margin: 1rem 0 1rem 0;
    position: absolute;
    bottom: 0;
}

.list-container{
    width: 100%;
    height: 65%;
    display: flex;
    flex-direction: row;
    justify-content: space-evenly;
    column-gap: 1rem;
    column-count: 2;
    overflow: auto;
    margin: 1rem 0 2rem 0;
}

.two-coluumn-list{
    column-count: inherit;
}

li{
    margin: 0 1rem 1rem 2rem;
}

.notes-item-block img{
    max-width: 100%;
}
</style>