<template>
    <Dialog class="dialog-regisration" v-model:visible="isVisible" :header="dialogHeading" modal :style="{ width: '30vw'}">
        <SignInModal v-if="isSignInModal"/>
        <RegistrationModal v-else/>
    </Dialog>
</template>

<script setup lang="ts">
import Dialog from 'primevue/dialog';
import {userStore} from '@/stores/user/index';
import { storeToRefs } from 'pinia';
import SignInModal from './SingInModal.vue'
import RegistrationModal from './RegistrationModal.vue';
import { computed } from 'vue';

const store = userStore();
const { isVisible, isSignInModal } = storeToRefs(store);
const dialogHeading = computed(() => {
  return isSignInModal.value ? 'Sign in' : 'Registration'
})
</script>

<style>
.p-overflow-hidden {
  overflow: auto;
}
.dialog-heading{
    font-size:larger;
}
.dialog-regisration{
    background-color: #EEE5DE;
}

.card .p-inputtext:enabled:focus {
  box-shadow: none; 
}
</style>