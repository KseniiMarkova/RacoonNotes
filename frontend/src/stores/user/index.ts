import { defineStore } from "pinia";

export const userStore = defineStore('user', {
    state: () => ({
        user:
        {
            name: '',
            email: '',
            password: '',
            country: '',
        },
        isVisible: false,
    }),
    getters:{
        getUser: (state) => state.user,
    },
    actions: {
        switchUserModalVisibility() {
            this.isVisible = !this.isVisible;
        },
    },
})
