<script setup lang="ts">
import HeaderItem from './HeaderItem.vue';
import type { HeaderItemsProps } from './models';
const headerItems: HeaderItemsProps[] = [
    {heading: 'MONTH'},
    {heading: 'WEEK'},
    {heading: 'DAY'},
    {heading: 'NOTES'},
    {heading: 'Links'}
]; 

</script>

<template>
    <div class="header">
        <img alt="Logo" class="logo" src="@/svg/Logo.svg" width="50" height="50" />
        <HeaderItem v-for="(item, index) in headerItems" :key="index" :item="item"/>
        <button type="button" class="button-sign-in"> <span class="span-sign-in">Sign in</span> </button>
    </div>
</template>

<style scoped>
.header {
    width: 100%;
    display: flex;
    top: 0;
    left: 0;
    width: 100%;
    background-color: #DAD3CE;
    flex-direction: row;
    justify-content: space-evenly;
    align-items: center;
    padding: 1rem;
}

.button-sign-in {
    width: 9rem;
    height: 3.5rem;
    background-color: rgba(179, 162, 179, 0.5);
    border-radius: 1rem;
    display: flex;
    flex-wrap: nowrap;
    justify-content: center;
    align-items: center;
    white-space: nowrap;
}

.span-sign-in {
    font-style: normal;
    font-weight: 600;
    font-size: 32px;
}

</style>