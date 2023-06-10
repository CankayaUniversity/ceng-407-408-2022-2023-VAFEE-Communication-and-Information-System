import { Announcement, Course, Message } from "@/interfaces"
import { defineStore } from "pinia"

export const useUserStore = defineStore("user", {
    state: () => ({
        id: null as string | null,
        name: null as string | null,
        username: null as string | null,
        email: null as string | null,
        image: null as string | null,
        courses: [] as Course[],
        messages: [] as Message[],
        announcements: [] as Announcement[],

    }),
    getters: {
        isLoggedIn: (state) => !!state.id,
    },
    actions: {},
})