<template>
    <div v-focustrap class="wrapperNote">
        <h2>Note's name:</h2>
        <InputText v-model="value" id="input-note-title" class="inputText-title" type="text" autofocus size="large" /><br />
        <h2>Note's description:</h2>
        <Editor v-model="value1" class="textArea-description" editorStyle="height: 320px" />
        <div class="wrapper-button-save">
            <Button type="button" label="Save Note" icon="pi pi-search" :loading="loading" @click="load" />
        </div>
    </div>
</template>

<script setup lang="ts">
import type { PropType } from 'vue';
import type { NotesItemsProps } from './modals';
import InputText from 'primevue/inputtext';
import Editor from 'primevue/editor';
import Button from 'primevue/button';
import { ref } from 'vue';
import { defineProps } from 'vue';
import { notesStore } from '@/stores/Notes/notes';

const value = ref('');
const value1 = ref('');

const loading = ref(false);

const load = () => {
    loading.value = true;
    setTimeout(() => {
        loading.value = false;
    }, 2000);
};
</script>

<style scoped lang="scss">
.wrapperNote {
    width: 85%;
    display: flex;
    flex-direction: column;
    align-content: center;
    margin: auto;
}

h2 {
    margin-left: 5%;
}

:deep() {
    .p-inputtext {
        color: #6C594C;
    }
}

:deep() {
    .p-inputtext,
    .p-editor-container .p-editor-toolbar.ql-snow,
    .p-editor-container .p-editor-content .ql-editor {
        font-size: large;
        background-color: #DAD3CE;
    }
}

.p-button{
  background: #E8D2D9;
}
:deep(.p-button[data-v-563f8311]:hover){
    background: #B3A2B3;
}
.textArea-description {
    margin-bottom: 2%;
    max-height: 100%;
}

.button-save {
    background: rgba(179, 162, 179, 0.5);
    border-radius: 4rem;
    width: 10rem;
    height: 4rem;
    display: flex;
    flex-wrap: nowrap;
    justify-content: center;
    align-items: center;
    white-space: nowrap;
}

.span-save {
    font-size: 30px;
    font-weight: 600;
    font-style: normal;
    text-transform: capitalize;
}

.wrapper-button-save {
    display: flex;
    justify-content: center;
    margin-bottom: 2rem;
}

:deep(){
    ol, ul{
    font-family: 'Outfit';
    }
}
</style>