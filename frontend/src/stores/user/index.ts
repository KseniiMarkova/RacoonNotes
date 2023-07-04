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
        isSignInModal: true,
    }),
    getters:{
        getUser: (state) => state.user,
    },
    actions: {
        switchUserModalVisibility() {
            this.isVisible = !this.isVisible;
        },
        setSignInModal(){
            this.isSignInModal = true;
        },
        setRegistrationModal(){
            this.isSignInModal = false;
        },
    },
})
