<!--Agentes permite al usuario gestionar su información personal, cambiar contraseña y buscar otros agentes registrados-->
<script setup>
    
    import Card from '@/components/Cards/Card.vue';
    import LayoutSection from '@/layouts/LayoutSection.vue';
    import Search from '@/components/Search.vue';
    import { useAgenteStore } from '@/stores/agente-store';
    import {onMounted } from 'vue';
    import { ref, computed} from 'vue';
    import ModalFallo from '@/components/Modals/ModalFallo.vue';
    import ModalCorrecto from '@/components/Modals/ModalCorrecto.vue';
    import AgenteCard from '@/components/Cards/AgenteCard.vue';

    /**
     * Store de agentes, utilizado para recuperar la información del agente actual, de cualquier otro agente y para actualizar al agente.
     */
    const store = useAgenteStore();

    /**
     * Nombre del agente actual.
     */
    const nombre = ref('');

    /**
     * Apellidos del agente actual.
     */
    const apellidos = ref('');

    /**
     * Rango del agente actual.
     */
    const rango = ref('');

    /**
     * Atributo 'activo' del agente actual.
     */
    const activo = ref('');

    /**
     * Objeto reactivo que almacena el último agente buscado.
     */
    const agenteBuscado = ref(null);

    /**
     * Booleano utilizado para saber si se ha buscado a un agente o no al menos una vez.
     */
    const seHaBuscado = ref(false);

    /**
     * Objeto reactivo utilizado para la actualización del nombre del agente actual.
     */
    const nombreCampo = ref(null);

    /**
     * Objeto reactivo utilizado para la actualización de los apellidos del agente actual.
     */
    const apellidosCampo = ref(null);

    /**
     * Objeto reactivo utilizado para la actualización del rango del agente actual.
     */
    const rangoCampo = ref(null);
    
    /**
     * Objeto reactivo utilizado para la actualización del atributo 'activo' del agente actual.
     */
    const activoCampo = ref(null);

    /**
     * Objeto reactivo utilizado para la actualización de la contraseña del agente actual. Almacena la contraseña actual introducida.
     */
    const password = ref(null);

    /**
     * Objeto reactivo utilizado para la actualización de la contraseña del agente actual. Almacena la nueva contraseña introducida.
     */
    const newPassword = ref(null);

    /**
     * Objeto reactivo utilizado para la actualización de la contraseña del agente actual. Almacena la confirmación de contraseña introducida.
     */
    const confirmPassword = ref(null);

    /**
     * Booleano reactivo para mostrar/ocultar un Modal al actualizar la contraseña correctamente.
     */
    const succesfullPassword = ref(false);

    /**
     * Booleano reactivo para mostrar/ocultar un Modal al fallar en la actualización de contraseña.
     */
    const failedPassword = ref(false);

    /**
     * Booleano reactivo para mostrar/ocultar un Modal al actualizarse correctamente la información personal..
     */
    const succesfullUpdate = ref(false);

    /**
     * Booleano reactivo para mostrar/ocultar un Modal al fallar en la actualización de información personal.
     */
    const failedUpdate = ref(false);

    /**
     * Función utilizada para cargar la información del agente actual.
     */
    async function getInformacionAgenteActual() {
        const response = await store.getInformacionAgenteActual();
        nombre.value = response.nombre;
        apellidos.value = response.apellidos;
        rango.value = response.rango;
        activo.value = response.activo;
    }

    /**
     * Función utilizada para buscar un agente determinado.
     * @param id Identificador del agente a buscar.
     */
    async function buscarAgente(id){
        const agente= await store.getInformacionAgente(id);
        return agente;
    }

    /**
     * Función utilizada para almacenar el último agente buscado.
     * @param agente Agente buscado.
     */
    function setAgenteBuscado(agente){
        seHaBuscado.value = true;
        agenteBuscado.value=agente;
    }

    /**
     * Función utilizada para actualizar la información personal del agente actual.
     */
    async function actualizarInformacionPersonal(){

        const agenteActualizar = computed(() => {
            return {
                nombre: nombreCampo.value ?? nombre.value,
                apellidos: apellidosCampo.value ?? apellidos.value,
                rango: rangoCampo.value ?? rango.value,
                activo: activoCampo.value ?? activo.value
        }})
        const response = await store.updateInformacionAgenteActual(agenteActualizar.value)
        if (response != null) {
            succesfullUpdate.value = true;
            nombre.value = response.nombre;
            apellidos.value = response.apellidos;
            rango.value = response.rango;
            activo.value = response.activo;
            nombreCampo.value = '';
            apellidosCampo.value = '';
            rangoCampo.value = '';
            activoCampo.value = '';
        }

        else failedUpdate.value = true;


    }

    /**
     * Función utilizada para restaurar los objetos reactivos utilizados para la actualización de la información personal.
     */
    async function cancelarActualizacion(){
        nombreCampo.value = '';
        apellidosCampo.value = '';
        rangoCampo.value = '';
        activoCampo.value = '';
    }

    /**
     * Función utilizada para cambiar la contraseña del agente actual.
     */
    async function actualizarPassword(){
        const response = await store.updatePasswordAgenteActual({password:password.value, newPassword:newPassword.value, confirmPassword:confirmPassword.value});
        password.value='';
        newPassword.value='';
        confirmPassword.value='';
        if (response == true) succesfullPassword.value = true;
        else failedPassword.value = true;

    }   
    onMounted(getInformacionAgenteActual)

</script>

<template>

    <LayoutSection>
        <div class="h-full w-full grid grid-cols-1 grid-rows-[auto_auto_auto] lg:grid-rows-[50%_50%] lg:grid-cols-[80%_20%] gap-5">
                
            <Card class="lg:row-start-1" v-bind:horizontal="true">
                <template v-slot:body>
                    <div class="w-full md:w-1/3">
                        <h2 class="font-semibold text-center md:text-left h2-section-card">Información personal</h2>
                        <p class="p-card">Modifica tu información personal aqui.</p>  
                    </div>

                
                   <fieldset class="grid w-full min-h-0 grid-cols-1 gap-5 p-5 border border-gray-300 shadow-lg h-min md:w-2/3 bg-primary/10 sm:grid-cols-2 rounded-box">
                                
                               
                                <div class="flex flex-col">
                                    <label class="w-full text-xs text-left sm:text-sm text-primary">Nombre</label>
                                    <input type="text" class="w-full min-w-0 input bg-primary/20 border-primary/40" v-model="nombreCampo" :placeholder="nombre">
                                </div>
                                
                                <div class="flex flex-col">
                                    <label class="w-full text-xs text-left sm:text-sm text-primary">Apellidos</label>
                                    <input type="text" class="w-full min-w-0 input bg-primary/20 border-primary/40" v-model="apellidosCampo" :placeholder="apellidos">
                                </div>

                               
                                
                                <div class="flex flex-col">
                                    <label class="w-full text-xs text-left sm:text-sm text-primary">Rango</label>
                                    <input type="text" class="w-full min-w-0 input bg-primary/20 border-primary/40" v-model="rangoCampo" :placeholder="rango">
                                </div>
                                
                                <div class="flex flex-col">
                                    <label class="w-full text-xs text-left sm:text-sm text-primary">Activo</label>
                                    <input disabled type="text" class="w-full min-w-0 input disabled:bg-primary/20 disabled:border-primary/40" v-model="activoCampo" :placeholder="activo">
                                </div>

                                
                            
                            <div class="flex flex-col justify-end gap-3 sm:col-span-2 sm:flex-row">
                                <button @click="cancelarActualizacion" type="button" class="btn btn-ghost">Cancelar</button>
                                <button  @click="actualizarInformacionPersonal" type="button" class="font-semibold btn text-primary hover:text-primary-content btn-primary btn-ghost">Aceptar</button>
                            </div>       
                    </fieldset>
                </template>
            </Card>

            <Card class="lg:row-start-2" v-bind:horizontal="true">
                <template v-slot:body>
                    <div class="w-full md:w-1/3"> 
                        <h2 class="font-semibold text-center md:text-left h2-section-card">Cambiar contraseña</h2>
                        <p class="p-card">Introduce tu contraseña actual y la nueva contraseña que desea para actualizarla.</p>
                        
                    </div>
                    
                    <fieldset class="grid min-h-0 grid-cols-1 gap-5 p-5 border border-gray-300 shadow-lg md:w-2/3 h-fit bg-primary/10 rounded-box">
                        
                        <div class="flex flex-col">
                            <label class="w-full text-xs text-left sm:text-sm text-primary">Contraseña Actual</label>
                            <input type="password" v-model="password" class="w-full input bg-primary/20 border-primary/40" placeholder="Introduce tu contraseña actual">
                        </div>
                        

                        <div class="flex flex-col">
                            <label class="w-full text-xs text-left sm:text-sm text-primary">Contraseña Nueva</label>
                            <input type="password" v-model="newPassword" class="w-full input bg-primary/20 border-primary/40" placeholder="Introduce una nueva contraseña">    
                        </div>

                        

                        <div class="flex flex-col">
                            <label class="w-full text-xs text-left sm:text-sm text-primary">Confirmar Contraseña</label>
                            <input type="password" v-model="confirmPassword" class="w-full input bg-primary/20 border-primary/40" placeholder="Confirme la contraseña nueva">    
                        </div>

                        
                        
                        <div class="flex flex-col justify-end gap-3 sm:flex-row">
                            <button type="button" class="btn-section-card btn-ghost">Cancelar</button>
                            <button @click="actualizarPassword" type="button" class="font-semibold btn-section-card hover:text-primary-content btn-primary text-primary btn-ghost">Aceptar</button>
                        </div>
                    </fieldset>
                </template>
            </Card>

            <Card class="lg:col-start-2 lg:row-span-full">
                <template v-slot:title>
                    <img src="./icons/buscar.png" alt="Buscar Agente" class="img-section-card">
                    <h2 class="h2-section-card">Buscar Agente</h2>
                </template>

                <template v-slot:body>
                    <div class="join join-vertical">
                        <p class="pb-5 p-card">Introduzca el <span class="font-semibold text-primary">identificador del agente</span> para ver su información. Pulse Enter para buscar.</p>
                        <Search @searched="(agente) => {setAgenteBuscado(agente)}" class="w-[75%] self-center row-start-1 col-span-full" v-bind:function="buscarAgente" v-bind:placeholder="'Buscar Agente'"></Search>
                    </div>
                    
                    <AgenteCard v-if="agenteBuscado" v-bind:agente-buscado="agenteBuscado" class="mt-10"></AgenteCard>
                    <p v-else-if="seHaBuscado" class="pt-2 text-xs text-primary">No se ha encontrado ningún agente con dicho identificador.</p>
                </template>
            </Card>
            </div> 
            
            
            <ModalCorrecto v-if="succesfullPassword" v-model="succesfullPassword">
                <template v-slot:title>
                    <h2>Se ha cambiado la contraseña correctamente</h2>
                </template>
            </ModalCorrecto>

            <ModalFallo v-if="failedPassword" v-model="failedPassword">
                <template v-slot:title>
                    <h2>No se ha podido cambiar la contraseña</h2>
                </template>

                <template v-slot:body>
                    <p> Por favor, revise los campos y vuelva a intentarlo.</p>
                </template>

            </ModalFallo>
            
            <ModalCorrecto v-if="succesfullUpdate" v-model="succesfullUpdate">
                <template v-slot:title>
                    <h2>Se ha actualizado la información personal correctamente</h2>
                </template>
            </ModalCorrecto>

            <ModalCorrecto v-if="failedUpdate" v-model="failedUpdate">
                <template v-slot:title>
                    <h2>Ha ocurrido un error durante la actualización de la información personal</h2>
                </template>

                <template v-slot:body>
                    <p>Por favor, inténtelo de nuevo.</p>
                </template>
            </ModalCorrecto>
            
    </LayoutSection>

</template>
