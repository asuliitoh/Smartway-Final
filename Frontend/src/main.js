import './assets/main.css'
import './assets/theme.css'
import axios from 'axios'
import { createApp } from 'vue'
import {createPinia } from 'pinia'
import {createRouter, createWebHistory} from 'vue-router'
import Login from './components/Login.vue';
import Home from './components/Home.vue'
import App from './App.vue'
import { useAuthStore } from './stores/auth'

//TODO: Añadir lógica que rediriga a /login SOLO si el usuario no ha iniciado sesión.
const routes = [
  {path:'/', redirect:'/login'},
  {path:'/login', name:'login', component:Login},
  {path: '/home', name: 'home', component: Home},
]

const router = createRouter({
  history:createWebHistory(),
  routes,
})

router.beforeEach(async (to) => {
  const auth = useAuthStore(); 
  const logged = auth.user && auth.token;
  if (auth.user && auth.token && to.path.includes('login')) {
    return {name: 'home'}
  }


})

//Creación de una instancia Axios global, para todos los componentes Vue.
const axiosInstance = axios.create ( {
  baseURL: 'https://localhost:7038/'
});

export {axiosInstance, router}

const app = createApp(App);
app.use(createPinia());
app.use(router);
app.mount('#app');
