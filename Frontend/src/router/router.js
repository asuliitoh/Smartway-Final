import {createRouter, createWebHistory} from 'vue-router'
import Login from '@/views/Login.vue'
import Home from '@/views/Home.vue'
import Operaciones from '@/views/Operaciones.vue'
import Equipos from '@/views/Equipos.vue'
import Equipo from '@/views/Equipo.vue'
import Agentes from '@/views/Agentes.vue'
import Operacion from '@/views/Operacion.vue'

//TODO: Añadir lógica que rediriga a /login SOLO si el usuario no ha iniciado sesión.
const routes = [
  {path:'/', redirect:'/login'},
  {path:'/login', name:'login', component:Login},
  {path: '/home', name: 'home', component: Home},
  {path: '/operaciones', name:'operaciones', component:Operaciones},
  {path: '/equipos', name:'equipos', component:Equipos},
  {path: '/equipos/:equipoId', name: 'equipo', component:Equipo, props: route => ({equipoId: Number(route.params.equipoId)})},
  {path: '/agentes', name:'agentes', component:Agentes},
  {path: '/operaciones/:operacionId', component:Operacion,  name: 'operacion', props: route => ({operacionId: Number(route.params.operacionId)})}

]

const router = createRouter({
  history:createWebHistory(),
  routes,
})

export {router}