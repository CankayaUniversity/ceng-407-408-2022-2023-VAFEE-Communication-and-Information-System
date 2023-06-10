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
            <div class="space-y-6">
                <div>
                    <label for="email" class="block text-sm font-medium leading-6">Email address</label>
                    <div class="mt-2">
                        <input type="email" v-model="email" class="input input-bordered input-primary w-full" />
                    </div>
                </div>

                <div>
                    <div class="flex items-center justify-between">
                        <label for="password" class="block text-sm font-medium leading-6">Password</label>
                        <div class="text-sm">
                            <a href="#" class="font-semibold text-indigo-600 hover:text-indigo-500">Forgot password?</a>
                        </div>
                    </div>
                    <div class="mt-2">
                        <input type="password" v-model="password" class="input input-bordered input-primary w-full" />
                    </div>
                </div>

                <div>
                    <button type="button" @click="handleSubmit"
                        class="flex w-full justify-center rounded-md bg-indigo-600 px-3 py-1.5 text-sm font-semibold leading-6 text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600">Sign
                        in</button>
                </div>
            </div>

            <p class="mt-10 text-center text-sm text-gray-500">
                If you dont have an account,
                <RouterLink :to="{ name: 'Register' }"
                    class="font-semibold leading-6 text-indigo-600 hover:text-indigo-500">
                    Register
                </RouterLink>
            </p>
        </div>
    </div>
</template>

<script setup lang="ts">
import { useSignIn } from '@/composables/SignIn';
import { auth } from '@/firebase/config';

import { ref } from 'vue';
import { useRouter } from 'vue-router';


const router = useRouter()
const email = ref("")
const password = ref("")

const logoPath = ref('src/assets/img/logo/vafee-logo-white.png');

const handleSubmit = () => {
    useSignIn(auth, email.value, password.value)
    router.push({ name: 'Home' })

}




</script>

<style scoped></style>
