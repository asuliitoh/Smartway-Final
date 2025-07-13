import {createRouter, createWebHistory} from 'vue-router'
import Login from '@/views/Login.vue'
import Home from '@/views/Home.vue'
import Operaciones from '@/views/Operaciones.vue'
import Equipos from '@/views/Equipos.vue'
import Equipo from '@/views/Equipo.vue'
import Agentes from '@/views/Agentes.vue'
import Operacion from '@/views/Operacion.vue'

/**
 * Rutas definidas de la plataforma.
 */
const routes = [
  {path:'/', redirect:'/login'}, //Redirige a login por defecto
  {path:'/login', name:'login', component:Login}, //Página Login
  {path: '/home', name: 'home', component: Home}, //Página Home
  {path: '/operaciones', name:'operaciones', component:Operaciones}, //Página Operaciones
  {path: '/equipos', name:'equipos', component:Equipos}, //Página Equipos
  {path: '/equipos/:equipoId', name: 'equipo', component:Equipo, props: route => ({equipoId: Number(route.params.equipoId)})}, //Página Equipo Seleccionado
  {path: '/agentes', name:'agentes', component:Agentes}, //Página Agentes
  {path: '/operaciones/:operacionId', component:Operacion,  name: 'operacion', props: route => ({operacionId: Number(route.params.operacionId)})} //Página Operación

]

/**
 * Instanciación del router.
 */
const router = createRouter({
  history:createWebHistory(),
  routes,
})

export {router}