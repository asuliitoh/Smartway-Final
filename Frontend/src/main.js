import './assets/main.css'
import './assets/theme.css'
import axios from 'axios'
import { createApp } from 'vue'
import {createPinia } from 'pinia'
import {createRouter, createWebHistory} from 'vue-router'
import Login from './views/Login.vue';
import Home from './views/Home.vue'
import App from './App.vue'
import { useAuthStore } from './stores/auth'
import Operaciones from './views/Operaciones.vue'
import Equipos from './views/Equipos.vue'
import Agentes from './views/Agentes.vue'

//TODO: Añadir lógica que rediriga a /login SOLO si el usuario no ha iniciado sesión.
const routes = [
  {path:'/', redirect:'/login'},
  {path:'/login', name:'login', component:Login},
  {path: '/home', name: 'home', component: Home},
  {path: '/operaciones', name:'operaciones', component:Operaciones},
  {path: '/equipos', name:'equipos', component:Equipos},
  {path: '/agentes', name:'agentes', component:Agentes}

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

const auth = useAuthStore();
auth.init();

app.mount('#app');
