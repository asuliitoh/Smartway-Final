import './assets/main.css'
import './assets/theme.css'
import { createApp } from 'vue'
import {createPinia } from 'pinia'
import App from './App.vue'
import { useAuthStore } from './stores/auth-store'
import { router } from './router/router'
import { useOperacionesStore } from './stores/operaciones-store'
import { useEquiposStore } from './stores/equipos-store'
import { ref } from 'vue'
import { useAgenteStore } from './stores/agente-store'
import { useEstadisticasStore } from './stores/estadisticas-store'
const app = createApp(App);
const loaded = ref(false)
const pinia = createPinia();


router.beforeEach((to) => {
  const auth = useAuthStore(pinia);
  const operaciones = useOperacionesStore();
  const equipo = useEquiposStore(); 

  auth.init();
  const isAuthenticated = ((auth.user !== null) && (auth.token !== null))

  if (!isAuthenticated){
    equipo.clear();
    operaciones.clear();
    loaded.value = false;
    if (to.name !== 'login') router.replace({name: 'login'});
  }

  else if(isAuthenticated && !loaded.value) {
    equipo.init()
    operaciones.getAllOperaciones();
    equipo.getAllEquipos();
    loaded.value = true;
  }
})

app.use(pinia);
app.use(router);
app.mount('#app');
