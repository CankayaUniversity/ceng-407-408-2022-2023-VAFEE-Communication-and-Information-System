<template>
    <div>
        <div class="navbar bg-base-100">
            <div class="flex-none">
                <button class="btn btn-square btn-ghost">
                    <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24"
                        class="inline-block w-5 h-5 stroke-current">
                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M4 6h16M4 12h16M4 18h16">
                        </path>
                    </svg>
                </button>
            </div>
            <div class="flex-1">
                <a class="btn btn-ghost normal-case text-xl">VAFEE</a>
            </div>
            <div class="flex-none">
                <button @click="launchLoginModal" class="btn btn-ghost normal-case text-xl">Login</button>
                <button class="btn btn-square btn-ghost">
                    <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24"
                        class="inline-block w-5 h-5 stroke-current">
                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                            d="M5 12h.01M12 12h.01M19 12h.01M6 12a1 1 0 11-2 0 1 1 0 012 0zm7 0a1 1 0 11-2 0 1 1 0 012 0zm7 0a1 1 0 11-2 0 1 1 0 012 0z">
                        </path>
                    </svg>
                </button>
            </div>
        </div>
    </div>
    <Teleport to="#app">
        <LoginModal :show="showLoginModal" @closeModal="showLoginModal = false"></LoginModal>
    </Teleport>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import LoginModal from './Modals/LoginModal.vue';
import { useRouter } from 'vue-router';

const router = useRouter();

const showLoginModal = ref(false);

const launchLoginModal = () => {
    showLoginModal.value = true;
}
</script>

<style scoped></style>