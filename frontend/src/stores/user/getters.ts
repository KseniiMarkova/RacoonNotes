import type { userState } from "./models"

export const getters = {
    getUser(state: userState) {
        return state.user;
    },
}
