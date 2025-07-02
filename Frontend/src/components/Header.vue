<script setup>
import { useAuthStore } from '@/stores/auth';

function logout(){
    const auth = useAuthStore();
    auth.logout();
}

</script>

<template>

    <div class="navbar bg-transparent">
        <div class="flex-1 flex flex-row gap-1 items-center">
            <img class="w-8 h-8" id="logo"src="/public/favicon.ico" alt="Logotipo de CiberPulse Labs">
            <h2 class="font-bold">CiberPulse Labs</h2>
        </div>
        <div class="flex-none">
            <ul class="menu menu-horizontal px-1">
                <li><a class="font-semibold hover:bg-primary/20">Inicio</a></li>
                <li><a class="font-semibold hover:bg-primary/20">Operaciones</a></li>
                <li><a class="font-semibold hover:bg-primary/20">Equipos</a></li>
                <li><a @click="logout" class="font-semibold hover:bg-primary/20" id="nosotros">Cerrar sesión</a></li>
            </ul>
        </div>
    </div>



</template>

<style scoped>

</style>