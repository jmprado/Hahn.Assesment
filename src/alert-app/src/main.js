import './assets/main.css'
import 'vuetify/styles'
import { createVuetify } from 'vuetify'
import { createPinia } from 'pinia'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'
import { createApp } from 'vue'
import App from './App.vue'
import { router } from '@/router/vue-router.js'

const pinia = createPinia()

const vuetify = createVuetify({
  components,
  directives,
})

const app = createApp(App)
app.use(pinia)
app.use(vuetify)
app.use(router)
app.mount('#app')
