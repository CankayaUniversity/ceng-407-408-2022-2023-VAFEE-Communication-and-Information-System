<template>
    <div class="flex gap-24">
        <div class="w-1/4">
            <aside id="default-sidebar" class="z-40 transition-transform -translate-x-full sm:translate-x-0"
                aria-label="Sidebar">
                <div class="h-full px-3 py-4 overflow-y-auto bg-gray-50 dark:bg-gray-800 rounded-2xl">
                    <ul class="space-y-2 font-medium">
                        <li>
                            <RouterLink :to="{ name: 'Overview' }"
                                class="flex items-center p-2 text-gray-900 rounded-lg dark:text-white hover:bg-gray-100 dark:hover:bg-gray-700">
                                <!-- <svg aria-hidden="true"
                                    class="w-6 h-6 text-gray-500 transition duration-75 dark:text-gray-400 group-hover:text-gray-900 dark:group-hover:text-white"
                                    fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
                                    <path d="M2 10a8 8 0 018-8v8h8a8 8 0 11-16 0z"></path>
                                    <path d="M12 2.252A8.014 8.014 0 0117.748 8H12V2.252z"></path>
                                </svg> -->
                                <span class="ml-3">Overview</span>
                            </RouterLink>
                        </li>
                        <li>
                            <RouterLink :to="{ name: '' }"
                                class="flex items-center p-2 text-gray-900 rounded-lg dark:text-white hover:bg-gray-100 dark:hover:bg-gray-700">
                                <!-- <svg aria-hidden="true"
                                    class="w-6 h-6 text-gray-500 transition duration-75 dark:text-gray-400 group-hover:text-gray-900 dark:group-hover:text-white"
                                    fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
                                    <path d="M2 10a8 8 0 018-8v8h8a8 8 0 11-16 0z"></path>
                                    <path d="M12 2.252A8.014 8.014 0 0117.748 8H12V2.252z"></path>
                                </svg> -->
                                <span class="ml-3">Email Confirmation</span>
                            </RouterLink>
                        </li>
                        <li>
                            <RouterLink :to="{ name: '' }"
                                class="flex items-center p-2 text-gray-900 rounded-lg dark:text-white hover:bg-gray-100 dark:hover:bg-gray-700">
                                <!-- <svg aria-hidden="true"
                                    class="w-6 h-6 text-gray-500 transition duration-75 dark:text-gray-400 group-hover:text-gray-900 dark:group-hover:text-white"
                                    fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
                                    <path d="M2 10a8 8 0 018-8v8h8a8 8 0 11-16 0z"></path>
                                    <path d="M12 2.252A8.014 8.014 0 0117.748 8H12V2.252z"></path>
                                </svg> -->
                                <span class="ml-3">Security</span>
                            </RouterLink>
                        </li>
                        
                    </ul>
                </div>
            </aside>
        </div>
        <div class="w-3/4">
            <div class="p-4 w-full h-full bg-gray-50 dark:bg-gray-800 rounded-2xl">
                <RouterView></RouterView>
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">

</script>

<style></style>
