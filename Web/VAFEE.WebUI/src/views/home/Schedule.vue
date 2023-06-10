<template>
    <!-- <div class="flex md:flex-row gap-y-2 flex-col-reverse md:gap-2">
        <div class="w-full md:w-2/4 h-full">
            <div class="flex flex-col w-full border-opacity-50">
                <div class="grid h-auto card bg-base-300 rounded-box place-items-center">
                    sa
                </div>
                <div class="divider"></div>
                <div class="grid h-auto card bg-base-300 rounded-box place-items-center">content</div>
            </div>
        </div>
        <div class="w-full md:w-2/4 h-full">
            <VCalendar :is-dark="true" expanded class="border-purple-600"></VCalendar>
        </div>
    </div> -->
    <div
        class="w-full flex flex-col lg:flex-row justify-center items-stretch mx-auto lg:mx-0 bg-gray-100 dark:bg-gray-800 border-2 border-gray-300 dark:border-blue-800 rounded-2xl">

        <!--Sol Bölüm-->
        <div class="w-full lg:w-1/4  mx-auto lg:max-w-none lg:border-r border-gray-300 dark:border-gray-500">
            <!--Sol Üst-->
            <div class="flex flex-col p-6 space-y-4 border-b border-gray-300 dark:border-gray-500">


            </div>
            <!-- VCalendar Weekly (Sol-Orta) -->
            <VCalendar view="weekly" borderless expanded transparent :is-dark="true" />
            <!-- Yapılacaklar, Reminders (Sol-Alt)-->
            <div class="py-4 px-6 w-full h-[18rem] overflow-y-auto">

            </div>
        </div>
        <!--Sağ Bölüm-->
        <div class="lg:w-3/4 h-[18rem] overflow-y-auto lg:flex flex-grow">
            <div class="w-full h-full relative overflow-hidden">
                <div class="flex gap-2 p-3">
                    <RouterLink :to="{ name: 'NewMeeting' }" class="btn btn-primary">New Meeting
                    </RouterLink>
                </div>
                <div class="divider"></div> 
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import { useNow, useDateFormat } from '@vueuse/core'
import { onMounted, ref } from 'vue';
import { collection, getDocs } from "firebase/firestore";
import { firestore } from '@/firebase/config';

const formatted = useDateFormat(useNow(), 'HH:mm')


const tasks = ref([])
const todos = ref([])

onMounted(async () => {

    const querySnapshot = await getDocs(collection(firestore, "todo"));
    querySnapshot.forEach((doc) => {
        // doc.data() is never undefined for query doc snapshots
        console.log(doc.id, " => ", doc.data());
        let data = doc.data()
        todos.value.push(data)
    });

    console.log(tasks.value);
})

</script>

<style scoped></style>