<template>
    <div>
        <div class="grid grid-cols-4 gap-4">
            <div class="card w-full h-full bg-primary text-primary-content hover:cursor-pointer hover:bg-slate-300 hover:text-slate-700 transition-colors " v-for="course in courses"
            >
                <div class="card-body">
                    <h2 class="card-title">{{ course.code }}</h2>
                    <p>{{ course.description }}</p>
                    {{ course.users }}
                </div>  
            </div>
        </div>

    </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue';
import { collection, getDocs } from "firebase/firestore";
import { firestore } from '@/firebase/config';


const courses = ref([])


onMounted(async () => {


    const querySnapshot = await getDocs(collection(firestore, "classes"));
    querySnapshot.forEach((doc) => {
        // doc.data() is never undefined for query doc snapshots
        console.log(doc.id, " => ", doc.data());
        courses.value.push(doc.data())
    });
})
</script>

<style scoped></style>