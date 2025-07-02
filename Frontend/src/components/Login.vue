<script setup>
    import { ref, reactive, computed } from 'vue';
    import { axiosInstance } from '@/main';
    import { router } from '@/main';
    import { useAuthStore } from '@/stores/auth';
    
    const activeLogin = ref(true)
    const id = ref('')
    const nombre=ref('')
    const apellidos=ref('')
    const passwordLogin = ref('')
    const passwordRegister = ref('')
    const auth = useAuthStore();

    function clickLogin() {
        activeLogin.value = true
    }


    function submitLogin() {
        auth.login(id.value, passwordLogin.value);
    }

    function submitRegister() {
        auth.register(nombre.value, apellidos.value, passwordRegister.value);        
    }


    function clickRegister() {
        activeLogin.value = false
    }

</script>

<template>
    <main class="flex flex-1 min-w-screen min-h-screen bg-base-300 items-center justify-center">

        <div class="h-max card bg-base-100 shadow-lg border border-gray-200 lg:card-side lg:justify-center lg:items-center">

    <img src="./images/animation.avif" alt="Login Imagen" class="w-full h-full lg:w-150 lg:h-110">
     
    <div class="card-body border-l-1 border-gray-200 bg-base justify-center items-center">
        <h2 class="card-title font-semibold text-2xl justify-center text-base-content">CiberPulse Labs</h2>
        <p v-if="activeLogin" class="text-xs text-base-content/70">Bienvenido, Agente </p>
        
        <div class="flex flex-row justify-center items-center pt-5 pb-3 gap-x-5">
            <p @click="clickLogin" :class="{'underline': activeLogin, 'text-primary/80': activeLogin}" class="cursor-pointer text-primary/40 hover:text-primary/80">Login</p>
            <p @click="clickRegister" :class="{'underline': !activeLogin, 'text-primary/80': !activeLogin}"class="cursor-pointer text-primary/40 hover:text-primary/80">Registro</p>
        </div>
        
        <div v-if="activeLogin" class="min-w-50 border-t border-base-content/20">   
            <fieldset class="fieldset">
                <legend class="fieldset-legend text-primary">Identificador de Agente</legend>
                <input v-model=id type="text" class="input text-xs text-base-content bg-base/70" placeholder="Introduce tu ID de agente"/>
            </fieldset>

            <fieldset class="fieldset">
                <legend class="fieldset-legend text-primary">Contraseña</legend>
                <input v-model="passwordLogin" type="password" class="input text-xs text-base-content bg-base/70" placeholder="Introduce tu contraseña secreta"/>
            </fieldset>
 
            <div class="card-actions pt-4 flex-col items-center gap-5">
                <button @click="submitLogin" type="button" class="btn btn-primary">Iniciar sesión</button>
                <p class="text-xs text-base-content">Nuevo agente? <span @click="clickRegister" class="cursor-pointer underline">Registrate</span></p>
            </div>


        </div>

        <div v-else class="min-w-50 border-t border-base-content/20">   
            <fieldset class="fieldset">
                <legend class="fieldset-legend text-primary">Nombre del Agente</legend>
                <input v-model="nombre" type="text" class="input text-xs text-base-content bg-base/70" placeholder="Introduce tu nombre"/>
            </fieldset>

            <fieldset class="fieldset">
                <legend class="fieldset-legend text-primary">Apellidos del Agente</legend>
                <input v-model="apellidos" type="text" class="input text-xs text-base-content bg-base/70" placeholder="Introduce tus apellidos"/>
            </fieldset>

            <fieldset class="fieldset">
                <legend class="fieldset-legend text-primary">Contraseña</legend>
                <input v-model="passwordRegister" type="password" class="input text-xs text-base-content bg-base/70" placeholder="Introduce tu contraseña secreta"/>
            </fieldset>
 
            <div class="card-actions pt-4 flex-col items-center gap-5">
                <button @click="submitRegister" type="button" class="btn btn-primary">Registrarse</button>
                <dialog></dialog>
            </div>


        </div>
      
     </div>

</div>


    </main>



</template>
