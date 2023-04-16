<script setup lang="ts"></script>

<template>
  <div class="navbar bg-base-100">
    <div class="flex-1">
      <a class="btn btn-ghost normal-case text-xl">Vafee</a>
    </div>
    <div class="flex-none gap-2">
      <div class="form-control">
        <input type="text" placeholder="Search" class="input input-bordered" />
      </div>
      <div class="dropdown dropdown-end">
        <label tabindex="0" class="btn btn-ghost btn-circle avatar">
          <div class="w-10 rounded-full">
            <img
              alt="..."
              src="https://pps.whatsapp.net/v/t61.24694-24/161599179_816528216240734_4810440855987425746_n.jpg?ccb=11-4&oh=01_AdQkdCTOkfFCAR8NDlx9jjqVCScXhDF2GoVc8fhnJGmoNQ&oe=6448E801"
              class="w-full align-middle rounded-t-lg"
            />
          </div>
        </label>
        <ul
          tabindex="0"
          class="mt-3 p-2 shadow menu menu-compact dropdown-content bg-base-100 rounded-box w-52"
        >
          <li>
            <a class="justify-between">
              Profile
              <span class="badge">New</span>
            </a>
          </li>
          <li><a>Settings</a></li>
          <li><a>Logout</a></li>
        </ul>
      </div>
    </div>
  </div>
  <RouterView />
</template>

<style scoped></style>
