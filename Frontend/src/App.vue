<script setup>
import { ref } from 'vue';
import Login from './components/Login.vue';
import axiosInstance from './main';

const isRegisterModalOpen = ref(false)
const registeredId = ref(null)
function login(data){
  axiosInstance.post("/Agentes/login", {id:data.id, password:data.password}).then(response => {console.log(response.data);});
}

function register(data){
  axiosInstance.post("/Agentes/registro", {nombre:data.nombre, apellidos:data.apellidos ,password:data.password}).then(response => {
    
    console.log(response.data);
    registeredId.value=response.data.id;
    if (registeredId.value) {isRegisterModalOpen.value=true;}
    console.log(isRegisterModalOpen.value);
  
  });
  
}

</script>

<template>
  <main class="flex flex-1 min-w-screen min-h-screen bg-base-300 items-center justify-center">
    <Login @login="(loginForm) => login(loginForm)" @register="(registerForm) => register(registerForm)"></Login>
  
  </main>


</template>

<style>
@import "tailwindcss";
@plugin "daisyui";
</style>
