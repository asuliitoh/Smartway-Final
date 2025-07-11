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

    //Atributos del agente
    const store = useAgenteStore()
    const nombre = ref('')
    const apellidos = ref('')
    const rango = ref('')
    const activo = ref('')
    const agenteBuscado = ref(null)
    const seHaBuscado = ref(false)

    //Objetos reactivos utilizados para la actualización de los atributos del agente
    const nombreCampo = ref(null)
    const apellidosCampo = ref(null)
    const rangoCampo = ref(null)
    const activoCampo = ref(null)

    //Objetos reactivos utilizados para el cambio de la contraseña
    const password = ref(null)
    const newPassword = ref(null)
    const confirmPassword = ref(null)

    //Objetos reactivos utilizados para mostrar modals
    const succesfullPassword = ref(false)
    const failedPassword = ref(false)
    const failedUpdate = ref(false)
    const succesfullUpdate = ref(false)

    async function getInformacionAgenteActual() {
        const response = await store.getInformacionAgenteActual();
        nombre.value = response.nombre;
        apellidos.value = response.apellidos;
        rango.value = response.rango;
        activo.value = response.activo;
    }

    async function buscarAgente(id){
        const agente= await store.getInformacionAgente(id);
        return agente;
    }

    function setAgenteBuscado(agente){
        seHaBuscado.value = true;
        agenteBuscado.value=agente;
    }


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

        else failedUpdate.value = true


    }

    async function cancelarActualizacion(){
        nombreCampo.value = '';
        apellidosCampo.value = '';
        rangoCampo.value = '';
        activoCampo.value = '';
    }

    async function actualizarPassword(){
        const response = await store.updatePasswordAgenteActual({password:password.value, newPassword:newPassword.value, confirmPassword:confirmPassword.value})
        password.value='';
        newPassword.value='';
        confirmPassword.value='';

        if (response == true) succesfullPassword.value = true
        else failedPassword.value = true

    }   

    onMounted(getInformacionAgenteActual)

</script>

<template>

    <LayoutSection>
        <div class="h-full w-full grid grid-rows-[50%_50%] grid-cols-[80%_20%] gap-5">
                
            <Card class="row-start-1" v-bind:horizontal="true">
                <template v-slot:body>
                    <div class="w-[25%]">
                                <h2 class="card-title text-primary">Información personal</h2>
                                <p>Modifica tu información personal aqui.</p>  
                    </div>

                    <fieldset class="w-[75%] p-5 border border-gray-300 bg-primary/10 fieldset rounded-box shadow-lg">
                                
                                <div class="flex flex-row w-full gap-5">
                                    <div>
                                        <label class="label text-primary">Nombre</label>
                                        <input type="text" class="input bg-primary/20 border-primary/40" v-model="nombreCampo" :placeholder="nombre">
                                    </div>
                                    
                                    <div>
                                        <label class="label text-primary">Apellidos</label>
                                        <input type="text" class="input bg-primary/20 border-primary/40" v-model="apellidosCampo" :placeholder="apellidos">
                                    </div>

                                </div>
                                
                                <label class="label text-primary">Rango</label>
                                <input type="text" class="input bg-primary/20 border-primary/40" v-model="rangoCampo" :placeholder="rango">

                                <label class="label text-primary">Activo</label>
                                <input disabled type="text" class="input disabled:bg-primary/20 disabled:border-primary/40" v-model="activoCampo" :placeholder="activo">
                            
                            <div class="flex gap-3 justify-self-end">
                                <button @click="cancelarActualizacion" type="button" class="btn btn-ghost">Cancelar</button>
                                <button  @click="actualizarInformacionPersonal" type="button" class="font-semibold btn text-primary hover:text-primary-content btn-primary btn-ghost">Aceptar</button>
                            </div>
                    </fieldset>
                </template>
            </Card>

            <Card class="row-start-2" v-bind:horizontal="true">
                <template v-slot:body>
                    <div class="w-[25%]"> 
                        <h2 class="card-title text-primary">Cambiar contraseña</h2>
                        <p>Introduce tu contraseña actual y la nueva contraseña que desea para actualizarla.</p>
                        <div class="flex items-center justify-center"></div>
                    </div>
                    
                    <fieldset class="w-[75%] p-5 border border-gray-300 bg-primary/10 fieldset rounded-box shadow-lg">
                        <label class="label text-primary">Contraseña Actual</label>
                        <input type="password" v-model="password" class="input bg-primary/20 border-primary/40" placeholder="Introduce tu contraseña actual">

                        <label class="label text-primary">Contraseña Nueva</label>
                        <input type="password" v-model="newPassword" class="input bg-primary/20 border-primary/40" placeholder="Introduce una nueva contraseña">

                        <label class="label text-primary">Confirmar Contraseña</label>
                        <input type="password" v-model="confirmPassword" class="input bg-primary/20 border-primary/40" placeholder="Confirme la contraseña nueva">
                        
                        <div class="flex gap-3 justify-self-end">
                            <button type="button" class="btn btn-ghost">Cancelar</button>
                            <button @click="actualizarPassword" type="button" class="font-semibold btn text-primary hover:text-primary-content btn-primary btn-ghost">Aceptar</button>
                        </div>
                    </fieldset>
                </template>
            </Card>

            <Card class="col-start-2 row-span-full">
                <template v-slot:title>
                    <img src="./icons/buscar.png" alt="Buscar Agente" class="w-fit h-fit">
                    <h2 class="text-primary">Buscar Agente</h2>
                </template>

                <template v-slot:body>
                    <div class="join join-vertical">
                        <p class="self-center pt-3 pb-5 text-sm text-center">Introduzca el <span class="font-semibold text-primary">identificador del agente</span> para ver su información. Pulse Enter para buscar.</p>
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
