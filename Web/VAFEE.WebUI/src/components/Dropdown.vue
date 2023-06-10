<template>
    <div class="dropdown">
        <label tabindex="0" class="m-1">
            <slot name="dropdownButton"></slot>
        </label>
        <ul tabindex="0" class="dropdown-content menu p-2 shadow bg-base-100 rounded-box w-52">
            <slot name="dropdownItems"></slot>
        </ul>
    </div>
</template>

<script setup lang="ts">

</script>

<style scoped></style>