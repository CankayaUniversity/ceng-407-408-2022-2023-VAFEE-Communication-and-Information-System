<template>
    <div class="grid xxs:grid-cols-1 xs:grid-cols-2 sm:grid-cols-3 md:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 gap-4">
        <RouterLink :to="{}" v-for="course in courses" :key="course.code">
            <Card class="max-h-64 overflow-hidden">
                <template #cardTitle>
                    <h1 class="card-title">{{ course.code }}</h1>
                </template>
                <template #cardBodyContent>
                    <p class="text-sm">{{ course.description }}</p>
                </template>
            </Card>
        </RouterLink>
    </div>
    <div class="my-4">
        <ol class="relative border-l border-gray-200 dark:border-gray-700">
            <li class="mb-10 ml-4 last:mb-0" v-for="announcement in announcements" :key="announcement.content">
                <div
                    class="absolute w-3 h-3 bg-gray-200 rounded-full first:mt-0 mt-1.5 -left-1.5 border border-white dark:border-gray-900 dark:bg-gray-700">
                </div>
                <time class="mb-1 text-sm font-normal leading-none text-gray-400 dark:text-gray-500">{{ announcement.date.toDate() }}</time>
                <h3 class="text-lg font-semibold text-gray-900 dark:text-white">{{ announcement.title }}</h3>
                <p class="mb-4 text-base font-normal text-gray-500 dark:text-gray-400">{{ announcement.content }}</p>

            </li>

        </ol>
    </div>
</template>

<script setup lang="ts">
import Card from '@/components/Card.vue';
import { collection, getDocs } from "firebase/firestore";
import { ref, onMounted } from 'vue';
import { useUserStore } from "@/stores/user"
import { firestore } from '@/firebase/config';
const userStore = useUserStore()


const courses = ref([])
const announcements = ref([])
const users = ref([])
onMounted(async () => {


    

    const querySnapshotCourses = await getDocs(collection(firestore, "classes"));
    querySnapshotCourses.forEach((doc) => {
        // doc.data() is never undefined for query doc snapshots
        console.log(doc.id, " => ", doc.data());
        courses.value.push(doc.data())
    });

    const querySnapshotAnnouncement = await getDocs(collection(firestore, "announcements"));
    querySnapshotAnnouncement.forEach((doc) => {
        // doc.data() is never undefined for query doc snapshots
        console.log(doc.id, " => ", doc.data());
        console.log(doc.data().date.toDate());
        
        announcements.value.push(doc.data())
    });


    



    



})

</script>

<style scoped></style>