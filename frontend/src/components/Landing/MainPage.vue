<script setup lang="ts">
import MainPageItem from './MainPageCards.vue'
import type { MainPageItemProps } from './models';
const pageItems: MainPageItemProps[] = [
    {
        title: 'Month',
        imageSrc: 'src\\svg\\MonthlyCalendar.svg',
        description: "description information description information description information description information description information description information description information description information description informationdescription informationdescription information",
    },
    {
        title: 'Week',
        imageSrc: "src\\svg\\Weekly Calendar.svg",
        description: "description information description information description information description information description information description information description information description information description informationdescription informationdescription information",
    },
    {
        title: 'Day',
        imageSrc: "src\\svg\\Daily Calendar.svg",
        description: "description information description information description information description information description information description information description information description information description informationdescription informationdescription information",
    },
    {
        title: 'Notes',
        imageSrc: "src\\svg\\Notes.svg",
        description: "description information description information description information description information description information description information description information description information description informationdescription informationdescription information",
    },
];

</script>

<template>
    <div class="wrapper">
        <MainPageItem v-for="(item, index) in pageItems" :key="index" :item="item" :index="index + 1" />
        <div class="sign-up-block">
            <p class="span-sign-up">If you want to use Racoon Notes:</p>
            <button type="button" class="button-sign-up"><span class="span-sign-up">Sign up</span></button>
        </div>
    </div>
</template>


<style scoped>
.wrapper {
    background-color: #EEE5DE;
    display: flex;
    flex-direction: column;
    flex-wrap: nowrap;
    justify-content: space-evenly;
    align-items: center;
    padding: 1rem;

}

.sign-up-block{
    width: 80rem;
    height: 6rem;
    display: flex;
    background: rgba(70, 130, 180, 0.3);
    border-radius: 70px;
    justify-content: space-evenly;
    align-items: center;

}

.button-sign-up{
    background: rgba(179, 162, 179, 0.5);
    border-radius: 4rem;
    width: 15rem;
    height: 4rem;
    display: flex;
    flex-wrap: nowrap;
    justify-content: center;
    align-items: center;
    white-space: nowrap;
}

.span-sign-up{
    font-family: 'Outfit';
    font-size: 40px;
    font-weight: 600;
    font-style: normal;
    text-transform: capitalize;
    color: #191970;
}

</style>