import { createApp } from 'vue'
import { createPinia } from 'pinia'

import VCalendar from 'v-calendar'

import "v-calendar/style.css"


import "@/assets/css/main.css"

import router from '@/router'
import App from '@/App.vue'


const app = createApp(App)
const pinia = createPinia()

app.use(pinia)
app.use(router)
app.use(VCalendar, {})

app.mount('#app')