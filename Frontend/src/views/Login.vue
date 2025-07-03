<script setup>
    import { ref} from 'vue';
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
    <main class="flex items-center justify-center flex-1 min-h-screen min-w-screen">

    <div class="border border-gray-200 shadow-lg h-max card bg-base-100 shadow-primary/40 lg:card-side lg:justify-center lg:items-center">

    <img src="./images/animation.avif" alt="Login Imagen" class="w-full h-full lg:w-150 lg:h-110">
     
    <div class="items-center justify-center border-gray-200 card-body border-l-1 bg-base">
        <h2 class="justify-center text-2xl font-semibold card-title text-base-content">CiberPulse Labs</h2>
        <p v-if="activeLogin" class="text-xs text-base-content/70">Bienvenido, Agente </p>
        
        <div class="flex flex-row items-center justify-center pt-5 pb-3 gap-x-5">
            <p @click="clickLogin" :class="{'underline': activeLogin, 'text-primary/80': activeLogin}" class="cursor-pointer text-primary/40 hover:text-primary/80">Login</p>
            <p @click="clickRegister" :class="{'underline': !activeLogin, 'text-primary/80': !activeLogin}"class="cursor-pointer text-primary/40 hover:text-primary/80">Registro</p>
        </div>
        
        <div v-if="activeLogin" class="border-t min-w-50 border-base-content/20">   
            <fieldset class="fieldset">
                <legend class="fieldset-legend text-primary">Identificador de Agente</legend>
                <input v-model=id type="text" class="text-xs input text-base-content bg-base/70" placeholder="Introduce tu ID de agente"/>
            </fieldset>

            <fieldset class="fieldset">
                <legend class="fieldset-legend text-primary">Contraseña</legend>
                <input v-model="passwordLogin" type="password" class="text-xs input text-base-content bg-base/70" placeholder="Introduce tu contraseña secreta"/>
            </fieldset>
 
            <div class="flex-col items-center gap-5 pt-4 card-actions">
                <button @click="submitLogin" type="button" class="btn btn-primary">Iniciar sesión</button>
                <p class="text-xs text-base-content">Nuevo agente? <span @click="clickRegister" class="underline cursor-pointer">Registrate</span></p>
            </div>


        </div>

        <div v-else class="border-t min-w-50 border-base-content/20">   
            <fieldset class="fieldset">
                <legend class="fieldset-legend text-primary">Nombre del Agente</legend>
                <input v-model="nombre" type="text" class="text-xs input text-base-content bg-base/70" placeholder="Introduce tu nombre"/>
            </fieldset>

            <fieldset class="fieldset">
                <legend class="fieldset-legend text-primary">Apellidos del Agente</legend>
                <input v-model="apellidos" type="text" class="text-xs input text-base-content bg-base/70" placeholder="Introduce tus apellidos"/>
            </fieldset>

            <fieldset class="fieldset">
                <legend class="fieldset-legend text-primary">Contraseña</legend>
                <input v-model="passwordRegister" type="password" class="text-xs input text-base-content bg-base/70" placeholder="Introduce tu contraseña secreta"/>
            </fieldset>
 
            <div class="flex-col items-center gap-5 pt-4 card-actions">
                <button @click="submitRegister" type="button" class="btn btn-primary">Registrarse</button>
                <dialog></dialog>
            </div>


        </div>
      
     </div>

</div>


    </main>



</template>
