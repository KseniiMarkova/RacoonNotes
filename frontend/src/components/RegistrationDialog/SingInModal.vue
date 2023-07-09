<template>
    <div class="flex justify-content-center p-fluid">
        <div v-focustrap class="card">
            <div class="p-float-label p-input-icon-right mt-4 mb-4">
                <InputText id="email" v-model="email" type="email" class="shadow-none" />
                <label for="username">Email</label>
                <i class="pi pi-envelope"></i>
            </div>
            <div class="field">
                <div class="p-float-label">
                    <Password v-model="password" toggleMask>
                        <template #header>
                            <h6>Pick a password</h6>
                        </template>
                        <template #footer>
                            <div class="mt-0">Suggestions</div>
                            <ul class="pl-1 ml-1 mt-0" style="line-height: 1.5">
                                <li>At least one lowercase</li>
                                <li>At least one uppercase</li>
                                <li>At least one numeric</li>
                                <li>Minimum 8 characters</li>
                            </ul>
                        </template>
                    </Password>
                    <label for="password">Password</label>
                </div>
            </div>
            <Button type="submit" label="Sing in" class="bg-blue-200 mt-2 mb-2 shadow-none hover:bg-blue-400"></Button>
            <Button label="Registration" link class="shadow-none" @click="store.setRegistrationModal"></Button>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import { userStore } from '@/stores/user/index';
import Password from 'primevue/password';
import InputText from 'primevue/inputtext';
import Button from 'primevue/button';

const store = userStore();

const email = ref();
const password = ref();
</script>

<style></style>