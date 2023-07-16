<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router';
import MainHeader from './components/Header/MainHeader.vue';
import MainFooter from './components/Footer/MainFooter.vue';
</script>

<template>
  <header>
    <MainHeader />
  </header>
  <RouterView />
  <footer>
    <MainFooter/>
  </footer>
</template>

<style scoped>

</style>
