import { defineStore } from "pinia";
import { getters } from "./getters";
import { actions } from "./actions";
import type { userState } from "./models"

export const userStore = defineStore('user', {
    state: (): userState => ({
        user: '',
    }),
    getters: getters,
    actions: actions,
  })
  