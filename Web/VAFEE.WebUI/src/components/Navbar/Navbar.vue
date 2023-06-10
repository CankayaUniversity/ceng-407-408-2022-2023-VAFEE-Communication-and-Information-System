<template>
    <Sidebar @closeSidebar="sidebarOpen = false" class="transition-transform duration-200"
        :class="sidebarOpen ? 'translate-x-0' : '-translate-x-full'">
        <template #sidebarLinkList>
            <NavLinks :isForMobileMenu="true"></NavLinks>
        </template>
    </Sidebar>

    <div class="navbar bg-blue-800 justify-between">
        <div class="">
            <button @click="sidebarOpen = !sidebarOpen" class="btn btn-ghost md:hidden">
                <i class="fa-solid fa-bars text-slate-100"></i>
            </button>
            <RouterLink :to="{ name: 'Home' }">
                <img :src="logoPath" class="h-10 hidden md:block" alt="VAFEE Logo" />
            </RouterLink>
        </div>
        <div class="md:hidden">
            <RouterLink :to="{ name: 'Home' }">
                <img :src="logoPath" class="h-10" alt="VAFEE Logo" />
            </RouterLink>
        </div>
        <div class="hidden md:inline-flex" v-if="userStore.isLoggedIn">
            <NavLinks :isForMobileMenu="false"></NavLinks>
        </div>
        <div class="">
            <!-- <FlyoutMenu v-if="userStore.isLoggedIn"> </FlyoutMenu> -->
            <!-- <RouterLink class="btn  btn-ghost btn-circle" v-if="userStore.isLoggedIn" :to="{ name: 'Chat' }"><i
                    class="fa-solid fa-arrow-right-to-bracket"></i></RouterLink> -->
            <RouterLink class="btn  btn-ghost btn-circle" v-if="!userStore.isLoggedIn" :to="{ name: 'Login' }"><i
                    class="fa-solid fa-arrow-right-to-bracket"></i></RouterLink>
            <Dropdown class="dropdown-end" v-if="userStore.isLoggedIn">
                <template #dropdownButton>
                    <label tabindex="0" class="btn btn-ghost btn-circle avatar">
                        <div class="w-10 rounded-full">
                            <img
                                src="https://media.licdn.com/dms/image/C5603AQGes12EAQyfpg/profile-displayphoto-shrink_200_200/0/1652104923838?e=1688601600&v=beta&t=NQVIJ7IrF61sFKwO1-0ib-r0lDtFIvh9ajTaAFwELmE" />
                        </div>
                    </label>
                </template>
                <template #dropdownItems>
                    <li>
                        <RouterLink :to="{ name: 'Profile' }">Profile</RouterLink>
                    </li>
                    <!-- <li>
                        <RouterLink :to="{}">Merhaba</RouterLink>
                    </li> -->
                    <li>
                        <button @click="handleLogout">Logout</button>
                    </li>
                </template>
            </Dropdown>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import Dropdown from '../Dropdown.vue';
import Sidebar from './Sidebar.vue';
import NavLinks from './NavLinks.vue';
import FlyoutMenu from '../FlyoutMenu.vue';
import { useUserStore } from '@/stores/user';
import { useSignOut } from '@/composables/SignOut';
import { auth } from '@/firebase/config';

const logoPath = ref('src/assets/img/logo/vafee-logo-white.png');
const userStore = useUserStore();
const sidebarOpen = ref(false);


const handleLogout = () => {
    useSignOut(auth)

}
</script>

<style scoped></style>