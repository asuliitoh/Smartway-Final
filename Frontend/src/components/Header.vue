<script setup>
import { useAuthStore } from '@/stores/auth';
import { router } from '@/main';

function logout(){
    const auth = useAuthStore();
    auth.logout();
}

function redirectToOperaciones(){
    router.replace({name: 'operaciones'})
}

function redirectToEquipos(){
    router.replace({name: 'equipos'})
}

function redirectToAgentes(){
    router.replace({name: 'agentes'})
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
            <ul class="px-1 menu menu-horizontal">                
                <li><a @click="redirectToOperaciones" class="font-semibold hover:bg-primary/20">Operaciones</a></li>
                <li><a @click="redirectToEquipos" class="font-semibold hover:bg-primary/20">Equipos</a></li>
                <li><a @click="redirectToAgentes" class="font-semibold hover:bg-primary/20">Agentes</a></li>
                <li><a @click="logout" class="font-semibold hover:bg-primary/20" id="nosotros">Cerrar sesión</a></li>
            </ul>
        </div>
    </div>



</template>

<style scoped>

</style>