<template>
    <aside ref="sidebar" class="fixed top-0 left-0 z-40 w-64 h-screen md:-translate-x-full" aria-label="Sidebar">
        <div class="h-full px-3 py-4 overflow-y-auto bg-gray-50 dark:bg-gray-800">
            <div class="flex justify-end mb-3">
                <button @click="emits('closeSidebar')" class="btn btn-ghost md:hidden">
                    <i class="fa-solid fa-arrow-left"></i>
                </button>
            </div>

            <slot name="sidebarLinkList"></slot>
        </div>
    </aside>
</template>

<script setup lang="ts">
import { onClickOutside } from '@vueuse/core'
import { ref } from 'vue';

const sidebar = ref(null)

const emits = defineEmits(['closeSidebar'])

onClickOutside(sidebar, () => emits('closeSidebar'))
</script>

<style scoped>
.slide-enter-from,
.slide-leave-to {
    transform: translateX(-100%);
}

.slide-enter-to {
    transform: translateX(0);
}

.slide-leave-from {
    transform: translateX(0);
}
</style>