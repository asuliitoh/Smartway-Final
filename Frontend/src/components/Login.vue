<script setup>
import { ref, reactive, computed } from 'vue';

var x = window.matchMedia('(min-width:1024px)')
const cardQuerie = computed ( () => ({
    'card-side': x.matches,
    'image-full': ! x.matches
}))

const activeLogin = ref(true)

function clickLogin() {
    activeLogin.value = true
}

function clickRegister() {
    activeLogin.value = false
}

</script>

<template>

<div class="card bg-base-100 shadow-lg border border-gray-200 gap-10 lg:card-side lg:justify-center lg:items-center">
     <img src="./images/login_image.jpg" alt="Login Imagen" class=" hidden lg:block rounded-xl w-fit h-fit">   
     <div class="p-20 card-body border-l-1 border-gray-200 bg-neutral/90 justify-center items-center">
        <h2 class="card-title text-2xl justify-center pb-5 text-neutral-content">CiberPulse Labs</h2>
        <p v-if="activeLogin" class="text-xs text-neutral-content/70">Bienvenido, Agente </p>
        
        <div class="flex flex-row justify-center items-center gap-x-5">
            <p @click="clickLogin" :class="{'underline': activeLogin, 'text-neutral-content/80': activeLogin}" class="cursor-pointer text-neutral-content/40 hover:text-neutral-content/80">Login</p>
            <p @click="clickRegister" :class="{'underline': !activeLogin, 'text-neutral-content/80': !activeLogin}"class="cursor-pointer text-neutral-content/40 hover:text-neutral-content/80">Registro</p>
        </div>
        
        <div v-if="activeLogin" class="min-h-full min-w-50 border-t border-neutral-content/40">   
            <fieldset class="fieldset">
                <legend class="fieldset-legend text-neutral-content">Identificador de Agente</legend>
                <input type="text" class="input text-xs text-neutral-content bg-neutral/70" placeholder="Introduce tu ID de agente"/>
            </fieldset>

            <fieldset class="fieldset">
                <legend class="fieldset-legend text-neutral-content">Contraseña</legend>
                <input type="text" class="input text-xs text-neutral-content bg-neutral/70" placeholder="Introduce tu contraseña secreta"/>
            </fieldset>
 
            <div class="card-actions pt-4 flex-col items-center gap-5">
                <button type="button" class="btn btn">Iniciar sesión</button>
                <p class="text-xs text-neutral-content">Nuevo agente? <span class="underline">Registrate</span></p>
            </div>


        </div>

        <div v-else class="min-h-full min-w-50 border-t border-neutral-content/40">   
            <fieldset class="fieldset">
                <legend class="fieldset-legend text-neutral-content">Nombre del Agente</legend>
                <input type="text" class="input text-xs text-neutral-content bg-neutral/70" placeholder="Introduce tu nombre"/>
            </fieldset>

            <fieldset class="fieldset">
                <legend class="fieldset-legend text-neutral-content">Apellidos del Agente</legend>
                <input type="text" class="input text-xs text-neutral-content bg-neutral/70" placeholder="Introduce tus apellidos"/>
            </fieldset>

            <fieldset class="fieldset">
                <legend class="fieldset-legend text-neutral-content">Contraseña</legend>
                <input type="text" class="input text-xs text-neutral-content bg-neutral/70" placeholder="Introduce tu contraseña secreta"/>
            </fieldset>
 
            <div class="card-actions pt-4 flex-col items-center gap-5">
                <button type="button" class="btn btn">Registrarse</button>
            </div>


        </div>
      
     </div>

</div>


</template>
