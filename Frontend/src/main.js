import './assets/main.css'
import './assets/theme.css'
import axios from 'axios'
import { createApp } from 'vue'
import {createPinia } from 'pinia'
import App from './App.vue'

//Creación de una instancia Axios global, para todos los componentes Vue.
const axiosInstance = axios.create ( {
  baseURL: 'https://localhost:7038/'
});

export default axiosInstance;

const app = createApp(App);
app.config.globalProperties.$axios = axiosInstance;
app.use(createPinia());
app.mount('#app');
