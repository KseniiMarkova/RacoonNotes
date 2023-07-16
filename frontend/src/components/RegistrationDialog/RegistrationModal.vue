<template>
    <div class="flex justify-content-center p-fluid">
        <div v-focustrap class="card">
            <div class="p-float-label p-input-icon-right mt-4 mb-4">
                <InputText id="input" v-model="name" type="text" autofocus />
                <label for="input">Name</label>
                <i class="pi pi-user"></i>
            </div>
            <div class="p-float-label p-input-icon-right mb-4">
                <InputText id="email" v-model="email" type="email" />
                <label for="email">Email</label>
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
            <div class="field field-checkbox">
                <Checkbox id="accept" v-model="accept" name="accept" value="Accept" />
                <label for="accept">I agree to the terms and conditions*</label>
            </div>
            <Button type="submit" label="Submit" class="bg-blue-200 mt-2 shadow-none hover:bg-blue-400"></Button>
            <Button label="Sign in" link class="shadow-none pb-0" @click="store.setSignInModal"></Button>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref, } from 'vue';
import { userStore } from '@/stores/user/index';
import Password from 'primevue/password';
import InputText from 'primevue/inputtext';
import Checkbox from 'primevue/checkbox';
import Button from 'primevue/button';


const name = ref();
const email = ref();
const password = ref();
const accept = ref();
const store = userStore();
</script>

<style></style>