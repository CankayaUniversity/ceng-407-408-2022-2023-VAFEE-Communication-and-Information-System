<script setup lang="ts">
// import Footer from '@/components/Footer.vue';
import { useRoute } from 'vue-router';
import Navbar from '@/components/Navbar/Navbar.vue';
import { onMounted } from 'vue';

import { getUser } from "@/composables/getUser"
import { computed } from "vue"



const route = useRoute();
const navbarShouldRender = computed(() => {
    return (route.name === "Login" || route.name === "Register") ? false : true
})
onMounted(() => {
    getUser()
})

</script>

<template>
    <Navbar v-if="navbarShouldRender"></Navbar>
    <div class="md:container px-2 md:px-0 mx-auto my-6">
        <RouterView></RouterView>
    </div>
    <!-- <Footer></Footer> -->
</template>

<style scoped></style>
