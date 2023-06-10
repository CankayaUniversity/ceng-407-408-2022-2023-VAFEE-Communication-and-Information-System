import { User } from "@/interfaces";
import { defineStore } from "pinia";

export const useAppInfoStore = defineStore('appInfo', {
    state: () => ({
        users: [] as User[],
        
    }),
    getters: {},
    actions: {},
})