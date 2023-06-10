<template>
    <li class="mb-10 ml-4">
        <div
            class="absolute w-3 h-3 bg-gray-200 rounded-full -left-1.5 border border-white dark:border-gray-900 dark:bg-gray-700">
        </div>
        <time class="mb-1 text-sm font-normal leading-none text-gray-400 dark:text-gray-500">February 2022</time>
        <slot name="timelineTitle"></slot>
        <slot name="timelineContent"></slot>
    </li>
</template>

<script setup lang="ts">

</script>

<style scoped></style>