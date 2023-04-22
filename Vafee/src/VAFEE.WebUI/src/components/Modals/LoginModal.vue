<template>
    <div class="modal" v-if="props.show" :class="modalClass">
        <div class="modal-box">

            <input type="text" placeholder="Email or Username" v-model="emailOrUsername"
                class="input input-bordered input-primary w-full mb-4" />
            <input type="password" placeholder="Password" v-model="password"
                class="input input-bordered input-primary w-full" />

            <div class="modal-action">
                <button @click="login" class="btn">Login</button>
                <button @click="$emit('closeModal')" class="btn">Cancel</button>

            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import { computed, ref } from 'vue';



const props = defineProps({
    show: Boolean
})


const emailOrUsername = ref('');
const password = ref('');


const modalClass = computed(() => ({
    'modal-open': props.show
}))


const login = async () => {
    await fetch("https://localhost:7173/api/Students/GetAll", {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
        },

    }).then(res => res.json()).then(data => console.log(data));

}

</script>

<style scoped></style>