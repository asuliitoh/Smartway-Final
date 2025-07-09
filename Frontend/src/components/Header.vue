<script setup>
import { useAuthStore } from '@/stores/auth-store';
import { router } from '@/router/router';

function logout(){
    const auth = useAuthStore();
    auth.logout()
}

function redirectToHome(){
    router.replace({name: 'home'})
}

</script>

<template>

    <div class="bg-transparent navbar">
        <div class="flex flex-row items-center flex-1 gap-1">
            <img class="w-8 h-8" id="logo"src="/public/favicon.ico" alt="Logotipo de CyberPulse Labs">
            <a @click="redirectToHome" class="font-bold cursor-pointer">CyberPulse Labs</a>
        </div>
        <div class="flex-none">
       
        <ul class="flex items-center justify-center gap-4">
            <li><RouterLink to="/operaciones" class="px-2 py-1 font-semibold transition-all duration-300 rounded hover:bg-primary/20" active-class="bg-primary text-primary-content" >Operaciones</RouterLink></li>
            <li><RouterLink to="/equipos" class="px-2 py-1 font-semibold transition-all duration-300 rounded hover:bg-primary/20" active-class="bg-primary text-primary-content">Equipos</RouterLink></li>
            <li><RouterLink to="/agentes" class="px-2 py-1 font-semibold transition-all duration-300 rounded hover:bg-primary/20" active-class="bg-primary text-primary-content">Agentes</RouterLink></li>
            <li><button @click="logout" class="px-2 py-1 font-semibold transition-all duration-300 rounded hover:bg-primary/20">Cerrar sesión </button></li>
        </ul>
        </div>
    </div>

</template>
