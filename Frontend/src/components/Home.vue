<script setup>

import { useAuthStore } from '@/stores/auth';

function logout(){
    const auth = useAuthStore();
    auth.logout();
}


</script>

<template>
    <div class="flex flex-col">

        bienvenido a ciberpulse labs
        <button @click="logout" class="btn btn-primary">Cerrar sesión</button>

    </div>
   
</template>