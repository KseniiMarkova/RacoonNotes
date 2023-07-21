<template>
    <div class="header">
        <router-link :to="{ name: 'home' }" :key="$route.fullPath">
            <img alt="Logo" class="logo" src="@/svg/Logo.svg" width="50" height="50" />
        </router-link>
        <HeaderItem v-for="(item, index) in headerItems" :key="index" :item="item"/>
        <MainRegistration/>
        <button type="button" class="button-sign-in" @click="toggleModal">
            <span class="span-sign-in">Sign in</span>
        </button>
    </div>
</template>

<script setup lang="ts">
import MainRegistration from '../RegistrationDialog/MainRegistration.vue';
import HeaderItem from './HeaderItem.vue';
import type { HeaderItemsProps } from './models';
import {userStore} from '@/stores/user/index';

const headerItems: HeaderItemsProps[] = [
    { heading: 'MONTH', link: 'month' },
    { heading: 'WEEK', link: 'week' },
    { heading: 'DAY', link: 'day' },
    { heading: 'NOTES', link: 'notes' },
    { heading: 'List', link: 'list' }
]; 
const store = userStore();

const toggleModal = () => {
    store.switchUserModalVisibility();
    store.setSignInModal();
}
</script>

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
    width: 8rem;
    height: 3rem;
    border-radius: 1rem;
}

.span-sign-in {
  font-style: normal;
  font-weight: 600;
  font-size: 26px;
}

.p-editor-container .p-editor-content .ql-editor {
    font-family: 'Outfit';
    color: #191970;
}
</style>