<template>
    <div class="flex min-h-full flex-col justify-center px-6 py-12 lg:px-8">
        <div class="sm:mx-auto sm:w-full sm:max-w-sm">
            <RouterLink :to="{ name: 'Home' }">
                <img class="mx-auto h-10 w-auto" :src="logoPath" alt="VAFEE Logo">
            </RouterLink>
            <h2 class="mt-10 text-center text-2xl font-bold leading-9 tracking-tight">Sign in to your account
            </h2>
        </div>

        <div class="mt-10 sm:mx-auto sm:w-full sm:max-w-sm">
            <form class="space-y-6" @submit.prevent="register">
                <div>
                    <label for="email" class="block text-sm font-medium leading-6">Email address</label>
                    <div class="mt-2">
                        <input v-model="email" type="text" class="input input-bordered input-primary w-full" />
                    </div>
                </div>

                <div>
                    <div class="flex items-center justify-between">
                        <label for="password" class="block text-sm font-medium leading-6">Password</label>
                    </div>
                    <div class="mt-2">
                        <input v-model="password" type="password" class="input input-bordered input-primary w-full" />
                    </div>
                </div>

                <div>
                    <div class="flex items-center justify-between">
                        <label for="password" class="block text-sm font-medium leading-6">Confirm Password</label>
                    </div>
                    <div class="mt-2">
                        <input type="password" class="input input-bordered input-primary w-full" />
                    </div>
                </div>

                <div>
                    <button type="submit"
                        class="flex w-full justify-center rounded-md bg-indigo-600 px-3 py-1.5 text-sm font-semibold leading-6 text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600">Sign
                        in</button>
                </div>
            </form>

            <p class="mt-10 text-center text-sm text-gray-500">
                Already have an account?
                <RouterLink :to="{ name: 'Login' }" class="font-semibold leading-6 text-indigo-600 hover:text-indigo-500">
                    Login
                </RouterLink>
            </p>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref } from 'vue';
const logoPath = ref('src/assets/img/logo/vafee-logo-white.png');
import { useSignUp } from "@/composables/SignUp"
import { auth } from '@/firebase/config';


const email = ref("")
const password = ref("")

const register = () => {
    useSignUp(auth, email, password)
}



</script>

<style scoped></style>
