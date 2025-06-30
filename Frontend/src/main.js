import './assets/main.css'
import './assets/theme.css'
import axios from 'axios'
import { createApp } from 'vue'
import {createPinia } from 'pinia'
import {createRouter, createWebHistory} from 'vue-router'
import Login from './components/Login.vue';
import App from './App.vue'

const routes = [
  {path:'/Agentes/login', component:Login},
  {path: '/Agentes/registro', component: Login},
]

const router = createRouter({
  history:createWebHistory(),
  routes,
})

//Creación de una instancia Axios global, para todos los componentes Vue.
const axiosInstance = axios.create ( {
  baseURL: 'https://localhost:7038/'
});

export default axiosInstance;

const app = createApp(App);
app.use(createPinia());
app.use(router);
app.mount('#app');
