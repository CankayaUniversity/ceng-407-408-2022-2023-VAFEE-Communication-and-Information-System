<template>
    <div class="container mx-auto shadow-lg rounded-lg">
        <!-- headaer -->
        <div class="px-5 py-5 flex justify-between items-center bg-white border-b-2">
            <div class="font-semibold text-2xl">Vafee Chat</div>

            <div class="h-12 w-12 p-2 bg-yellow-500 rounded-full text-white font-semibold flex items-center justify-center">
                RA
            </div>
        </div>
        <!-- end header -->
        <!-- Chatting -->
        <div class="flex flex-row justify-between bg-white">
            <!-- chat list -->
            <div class="flex flex-col w-2/5 border-r-2 overflow-y-auto">
                <!-- search compt -->
                <div class="border-b-2 py-4 px-2">
                    <input type="text" placeholder="search chatting"
                        class="py-2 px-2 border-2 border-gray-200 rounded-2xl w-full" />
                </div>
                <!-- end search compt -->
                <!-- user list -->
                <RouterLink :to="{ name: 'Home' }">
                    <div class="flex flex-row py-4 px-2 justify-center items-center border-b-2" v-for="user in users"
                        :key="user.uid">
                        <div class="w-1/4">
                            <img :src="user.photo_url === null ? '/src/assets/img/goat.jpg' : user.photo_url"
                                class="object-cover h-12 w-12 rounded-full" alt="" />
                        </div>
                        <div class="w-full">
                            <div class="text-lg font-semibold">{{ user.display_name }}</div>
                            <span class="text-gray-500">Pick me at 9:00 Am</span>
                        </div>
                    </div>
                </RouterLink>

                <!-- end user list -->
            </div>
            <!-- end chat list -->
            <!-- message -->
            <RouterView></RouterView>
            

        </div>
    </div>
</template>
    
<script setup lang="ts">
import { onMounted } from 'vue';
import { collection, getDocs } from "firebase/firestore";
import { firestore } from '@/firebase/config';
import { ref } from 'vue';


const chats = ref([])
const users = ref([])

// let users = []
onMounted(async () => {


    const querySnapshotUsers = await getDocs(collection(firestore, "users"));
    querySnapshotUsers.forEach((doc) => {
        // doc.data() is never undefined for query doc snapshots
        // console.log(doc.id, " => ", doc.data());

        users.value.push(doc.data())
    });


    const querySnapshotChats = await getDocs(collection(firestore, "chats"));
    querySnapshotChats.forEach((doc) => {
        // doc.data() is never undefined for query doc snapshots
        console.log(doc.id, " => ", doc.data());
    });




})
</script>
    
<style scoped>
.mainDiv {
    max-width: 700px;
    margin: 0 auto;
}
</style>