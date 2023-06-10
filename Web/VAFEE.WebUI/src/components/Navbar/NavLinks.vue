<template>
    <ul class="space-y-2 font-medium" v-if="isForMobileMenu">
        <li>
            <RouterLink v-for="link in links" :key="link.name" :to="{ name: link.name }"
                class="flex items-center p-2 text-gray-900 rounded-lg dark:text-white hover:bg-gray-100 dark:hover:bg-gray-700">
                <!-- <svg aria-hidden="true"
                    class="w-6 h-6 text-gray-500 transition duration-75 dark:text-gray-400 group-hover:text-gray-900 dark:group-hover:text-white"
                    fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
                    <path d="M2 10a8 8 0 018-8v8h8a8 8 0 11-16 0z"></path>
                    <path d="M12 2.252A8.014 8.014 0 0117.748 8H12V2.252z"></path>
                </svg> -->
                <span class="ml-3">{{ link.displayName }}</span>
                <!-- <span
                        class="inline-flex items-center justify-center px-2 ml-3 text-sm font-medium text-gray-800 bg-gray-200 rounded-full dark:bg-gray-700 dark:text-gray-300">Pro</span> -->
            </RouterLink>
        </li>
    </ul>

    <ul class="flex gap-4" v-else>
        <li v-for="link in links" :key="link.name">
            <RouterLink :to="{ name: link.name }" class="link link-hover text-slate-100">{{ link.displayName }}</RouterLink>
        </li>
    </ul>
</template>

<script setup lang="ts">
import { ref } from 'vue';


defineProps({
    isForMobileMenu: {
        type: Boolean,
        required: true
    }
})


const links = ref([
    { name: 'Home', displayName: 'Home' },
    { name: 'Courses', displayName: 'Courses' },
    { name: 'Schedule', displayName: 'Schedule' },
    { name: 'Chat', displayName: 'Chats' },
    { name: 'Enroll', displayName: 'Enrollment' },
    // { name: 'Meetings', displayName: 'Meetings' },
    // { name: 'Feed', displayName: 'Feed' }
])

const normalMenuItemClasses = [
    'text-sm font-semibold text-slate-100 hover:text-slate-400 transition-colors',
]

const mobileMenuItemClasses = [
    'transition-colors',
    'hover:bg-gray-900',
    'text-white',
    'block',
    'rounded-md',
    'px-3',
    'py-2',
    'text-base',
    'font-medium'
]


</script>

<style scoped></style>