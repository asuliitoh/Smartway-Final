<!--Componente Header de la plataforma-->
<script setup>

import { useAuthStore } from '@/stores/auth-store';
import { router } from '@/router/router';

/**
 * Función utilizada para cerrar la sesión del agente actual.
 */
function logout(){
    const auth = useAuthStore();
    auth.logout()
}

/**
 * Función utilizada para redirigir a la página home.
 */
function redirectToHome(){
    router.replace({name: 'home'})
}

</script>

<template>
    
    <div class="grid grid-rows-2 bg-transparent md:navbar">
        <div class="flex flex-row items-center justify-center flex-1 w-full row-start-1 gap-1 md:justify-start">
            <img class="w-8 h-8" id="logo"src="/public/favicon.ico" alt="Logotipo de CyberPulse Labs">
            <a @click="redirectToHome" class="text-xs font-bold cursor-pointer md:text-lg lg:text-xl">CyberPulse Labs</a>
        </div>
        <div class="flex-none row-start-2 bg-transparent ">
        <ul class="flex flex-col items-center justify-center gap-1 text-xs md:gap-4 md:flex-row md:text-base lg:text-lg">
            <li><RouterLink to="/operaciones" class="px-2 py-1 font-semibold transition-all duration-300 rounded hover:bg-primary/20" active-class="bg-primary text-primary-content" >Operaciones</RouterLink></li>
            <li><RouterLink to="/equipos" class="px-2 py-1 font-semibold transition-all duration-300 rounded hover:bg-primary/20" active-class="bg-primary text-primary-content">Equipos</RouterLink></li>
            <li><RouterLink to="/agentes" class="px-2 py-1 font-semibold transition-all duration-300 rounded hover:bg-primary/20" active-class="bg-primary text-primary-content">Agentes</RouterLink></li>
            <li><button @click="logout" class="px-2 py-1 font-semibold transition-all duration-300 rounded hover:bg-primary/20">Cerrar sesión </button></li>
        </ul>
        </div>
    </div>

</template>
