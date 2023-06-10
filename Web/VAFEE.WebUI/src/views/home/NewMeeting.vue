<template>
    
    <div>
        <div class="flex min-h-full flex-col justify-center px-6 py-12 lg:px-8">


            <div class="mt-10 sm:mx-auto sm:w-full sm:max-w-sm">
                <div>
                    <label for="email" class="block text-sm font-medium leading-6">Room Id</label>
                    <div class="mt-2">
                        <input type="text" v-model="roomId" class="input input-bordered input-primary w-full" />
                    </div>
                </div>
                <div class="mt-2">
                    <a class="btn btn-primary w-full" :href="roomLink">Join</a>
                </div>

            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import { computed, ref } from 'vue';




const roomLink = computed(() => {
    return "https://localhost:3000/" + roomId.value
})
const roomId = ref("")

</script>

<style scoped></style>