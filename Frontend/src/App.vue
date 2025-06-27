<script setup>
import Login from './components/Login.vue';
import axiosInstance from './main';

function login(data){
  console.log(data)
  axiosInstance.get("/Agentes/login", {id:data.id, password:data.password}).then(response => console.log(response.data));
}

</script>

<template>
  <main class="flex flex-1 min-w-screen min-h-screen bg-base-300 items-center justify-center">
    <Login @login="(loginForm) => login(loginForm)"></Login>
  </main>
</template>

<style>
@import "tailwindcss";
@plugin "daisyui";
</style>
