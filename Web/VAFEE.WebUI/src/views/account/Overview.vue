<template>
    <div class="card w-96 bg-base-100 shadow-xl justify-center mb-2">
        <div class="badge badge-secondary justify-center">NEW</div>
        <figure><img src="https://img.a.transfermarkt.technology/portrait/big/147487-1674477789.png?lm=1" alt="Shoes" />
        </figure>
        <div class="card-body">
            <h2 class="card-title justify-center">
                {{ userStores.display_name }}

            </h2>
            <p>{{ userStores.email }}</p>
            <h2 class="my-4 bold">Courses</h2>
            <div class="card-actions ">
                <div class="flex-col ">
                    <ul>
                        <li>CENG 432</li>
                        <li>CENG 432</li>
                        <li>CENG 432</li>
                        <li>CENG 432</li>

                    </ul>
                </div>
            </div>
        </div>
    </div>
    <div>
        <form class="mt">
            <div class="relative z-0 w-full mb-6 group">
                <input type="text" name="user_name" id="user_name"
                    class="block py-2.5 px-0 w-full text-sm text-gray-900 bg-transparent border-0 border-b-2 border-gray-300 appearance-none dark:text-white dark:border-gray-600 dark:focus:border-blue-500 focus:outline-none focus:ring-0 focus:border-blue-600 peer"
                    placeholder=" " required />
                <label for="user_name"
                    class="peer-focus:font-medium absolute text-sm text-gray-500 dark:text-gray-400 duration-300 transform -translate-y-6 scale-75 top-3 -z-10 origin-[0] peer-focus:left-0 peer-focus:text-blue-600 peer-focus:dark:text-blue-500 peer-placeholder-shown:scale-100 peer-placeholder-shown:translate-y-0 peer-focus:scale-75 peer-focus:-translate-y-6">User
                    Name</label>
            </div>
            <div class="relative z-0 w-full mb-6 group">
                <input type="password" name="floating_password" id="floating_password"
                    class="block py-2.5 px-0 w-full text-sm text-gray-900 bg-transparent border-0 border-b-2 border-gray-300 appearance-none dark:text-white dark:border-gray-600 dark:focus:border-blue-500 focus:outline-none focus:ring-0 focus:border-blue-600 peer"
                    placeholder=" " required />
                <label for="floating_password"
                    class="peer-focus:font-medium absolute text-sm text-gray-500 dark:text-gray-400 duration-300 transform -translate-y-6 scale-75 top-3 -z-10 origin-[0] peer-focus:left-0 peer-focus:text-blue-600 peer-focus:dark:text-blue-500 peer-placeholder-shown:scale-100 peer-placeholder-shown:translate-y-0 peer-focus:scale-75 peer-focus:-translate-y-6">Password</label>
            </div>
            <div class="relative z-0 w-full mb-6 group">
                <input type="password" name="repeat_password" id="floating_repeat_password"
                    class="block py-2.5 px-0 w-full text-sm text-gray-900 bg-transparent border-0 border-b-2 border-gray-300 appearance-none dark:text-white dark:border-gray-600 dark:focus:border-blue-500 focus:outline-none focus:ring-0 focus:border-blue-600 peer"
                    placeholder=" " required />
                <label for="floating_repeat_password"
                    class="peer-focus:font-medium absolute text-sm text-gray-500 dark:text-gray-400 duration-300 transform -translate-y-6 scale-75 top-3 -z-10 origin-[0] peer-focus:left-0 peer-focus:text-blue-600 peer-focus:dark:text-blue-500 peer-placeholder-shown:scale-100 peer-placeholder-shown:translate-y-0 peer-focus:scale-75 peer-focus:-translate-y-6">Confirm
                    password</label>
            </div>


            <button type="submit"
                class="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800">Submit</button>
        </form>


    </div>
</template>

<script setup lang="ts">
import { useUserStore } from '@/stores/user';


const userStores = useUserStore();



</script>

<style scoped></style>