import './assets/main.css'
import './assets/theme.css'
import { createApp } from 'vue'
import {createPinia } from 'pinia'
import App from './App.vue'
import { useAuthStore } from './stores/auth'
import { router } from './router/router'
const app = createApp(App);
const pinia = createPinia();

router.beforeEach((to) => {
  const auth = useAuthStore(pinia); 
  const isAuthenticated = ((auth.user !== null) && (auth.token !== null))
  auth.init();
  if (to.name !== 'login' && !isAuthenticated) router.replace({name: 'login'});
})

app.use(pinia);
app.use(router);
app.mount('#app');
