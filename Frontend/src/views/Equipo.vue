<script setup>
    import LayoutSection from '@/layouts/LayoutSection.vue';
    import Card from '@/components/Cards/Card.vue';
    import Search from '@/components/Search.vue';
    import DisolverEquipo from '@/components/Modals/DisolverEquipo.vue';
    import {ref, reactive, onMounted} from 'vue';
    import { useAgenteStore } from '@/stores/agente-store';
    import { useEquiposStore } from '@/stores/equipos-store';
    import AgenteCard from '@/components/Cards/AgenteCard.vue';
    
    /**
     * Stores de Equipos, utilizado para recuperar la información del equipo actual.
     */
    const equipoStore = useEquiposStore();

    /**
     * Store de Agentes, utilizado para buscar agentes.
     */
    const store = useAgenteStore();

    /**
     * Objeto reactivo utilizado para almacenar el agente buscado.
     */
    const agenteBuscado = ref(null);

    /**
     * Booleano reactivo utilizado para saber si se ha buscado al menos una vez.
     */
    const seHaBuscado = ref(false);

    /**
     * Booleano reactivo utilizado para mostrar el modal de disolver equipo.
     */
    const disolverEquipoModal = ref(false);

    /**
     * Propiedades del componente. Router pasa equipoId mediante el path.
     */
    const props = defineProps(["equipoId"]);

    /**
     * Objeto reactivo utilizado para almacenar la información del equipo actual.
     */
    const equipo = ref(null);

    /**
     * Booleano reactivo utilizado para saber si el modo edición está habilitado o no.
     */
    const modoEdicion = ref(false);

    /**
     * Objeto reactivo utilizado para almacenar el nombre del equipo cuando se habilita el modo edición.
     */
    const nombreCampo = ref('');

    
    /**
     * Objeto reactivo utilizado para almacenar la especialidad del equipo cuando se habilita el modo edición.
     */
    const especialidadCampo = ref('');

    /**
     * Setter utilizado para establecer el agente actual buscado.
     * @param agente Agente buscado.
     */
    function setAgenteBuscado(agente){
        seHaBuscado.value = true;
        agenteBuscado.value=agente;
    }
     
    /**
     * Función utilizada para mostrar el modal de Disolver Equipo.
     * Se llama al pulsar sobre la Card "Disolver Equipo".
     */
    function disolverEquipo(){
        disolverEquipoModal.value = true;
    }

    /**
     * Función utilizada para envíar una solicitud de unión a un equipo a otro agente.
     * Se llama al pulsar el botón Añadir de la Card "Añadir Agente al Equipo".
     */
    function enviarSolicitud(){
        if (agenteBuscado.value) equipoStore.enviarSolicitud(agenteBuscado.value.id, props.equipoId);
    }
    
    /**
     * Función utilizada para recuperar la información del equipo actual.
     * Se llama al cargar la página.
     */
    async function getInformacionEquipo(){
        const response = await equipoStore.getEquipo(props.equipoId);
        equipo.value = response;
        console.log(equipo.value)
    }
    
    /**
     * Función utilizada para buscar un agente dado un identificador.
     * Se llama al pulsar Enter en el componente Search de "Añadir Agente Al Equipo".
     * @param id Identificador del agente.
     */
    async function buscarAgente(id){
        const agente = await store.getInformacionAgente(id);
        return agente;
    }

    /**
     * Función utilizada para cambiar el modo de edición.
     * Se llama al pulsar sobre la Card "Modificar Información"
     */
    async function cambiarModoEdicion(){
        modoEdicion.value = true;
    }

    /**
     * Función utilizada para limpiar el formulario de cambio de la información del equipo.
     * Se llama tras pulsar Cancelar en "Información Equipo" cuando el modo de edición está habilitado.
     */
    async function cancelarActualizacion(){
        nombreCampo.value = '';
        especialidadCampo.value = '';
        modoEdicion.value = false;
    }

    /**
     * Función utilizada para enviar el formulario de cambio de la información del equipo.
     * Se llama tras pulsar Confirmar en "Información Equipo" cuando el modo de edición está habilitado.
     */
    async function actualizarEquipo(){
        const response = await equipoStore.actualizarInformacionEquipo(props.equipoId, nombreCampo.value, especialidadCampo.value);
        if (response) {
            equipo.value.nombre = nombreCampo.value;
            equipo.value.especialidad = especialidadCampo.value;
            nombreCampo.value = '';
            especialidadCampo.value = '';
            
        }
        modoEdicion.value = false;
    }

    onMounted(getInformacionEquipo)


</script>

<template>
   <LayoutSection>
    
    <div class="h-full w-full grid grid-cols-[70%_30%] grid-rows-[auto_auto_auto] gap-5">
        <Card class="col-start-1 row-span-full">
            <template v-slot:title>
                <div class="flex flex-row justify-center w-full">
                    <p class="text-primary">Información del Equipo</p>
                </div>
            </template>

            <template v-slot:body>

                <fieldset v-if="equipo" class="h-full p-5 border border-gray-300 shadow-lg bg-primary/10 fieldset rounded-box">
                           
                        <label class="label text-primary">Identificador del equipo</label>
                        <input disabled type="text" class="w-full input disabled:bg-primary/20 disabled:border-primary/40" :placeholder = "equipo.id">

                        <label class="label text-primary">Nombre del Equipo</label>
                        <input :disabled="!modoEdicion" v-model="nombreCampo" type="text" class="w-full input bg-primary/20 border-primary/40 disabled:bg-primary/20 disabled:border-primary/40" :placeholder="equipo.nombre">

                        <label class="label text-primary">Especialidad del Equipo</label>
                        <input :disabled="!modoEdicion" v-model="especialidadCampo" type="text" class="w-full input bg-primary/20 border-primary/40 disabled:bg-primary/20 disabled:border-primary/40" :placeholder="equipo.especialidad">

                        <label class="label text-primary">Miembros del Equipo</label>
                        
                            <table class="table bg-primary/20 table-xs table-pin-rows">
                                    <thead>
                                        <th>Id</th>
                                        <td>Nombre</td>
                                        <td>Apellidos</td>  
                                    </thead>

                                <template v-for="miembro in equipo.miembros">
                                    <tr class="hover:bg-primary/10">
                                        <th>{{ miembro.id }}</th>
                                        <td>{{ miembro.nombre }}</td>
                                        <td>{{ miembro.apellidos }}</td>
                                    </tr>
                                </template>
                                </table>        
                    
                        <label class="label text-primary">Operaciones del Equipo</label>            

                            <table class="table bg-primary/20 table-xs table-pin-rows">
                                    <thead>
                                        <th>Id</th>
                                        <td>Nombre</td>
                                    </thead>

                                <template v-for="operacion in equipo.operacion">
                                    <tr class="hover:bg-primary/10">
                                        <th>{{ operacion.id }}</th>
                                        <td>{{ operacion.nombre }}</td>
                                    </tr>
                                </template>
                                </table>        
                    </fieldset>
            </template>

            <template v-slot:actions>
                <button @click="cancelarActualizacion" v-if="modoEdicion" type="button" class="btn">Cancelar</button>
                <button @click="actualizarEquipo" v-if="modoEdicion" type="button" class="btn btn-primary">Aplicar</button>
            </template>

        </Card>

        <Card @click="cambiarModoEdicion" class="col-start-2 row-start-1">
            <template v-slot:title>
                <div class="flex flex-row justify-center w-full">
                    <p class="text-primary">Modificar Información</p>
                </div>
            </template>

            <template v-slot:body>
               <p>Pulse esta sección para habilitar el <span class="font-semibold text-primary">modo edición</span> de la información del equipo.</p>
            </template>

        </Card>

        <Card class="col-start-2 row-start-2">
            <template v-slot:title>
                <div class="flex flex-row justify-center w-full">
                    <p class="text-primary">Añadir Agente al Equipo</p>
                </div>
            </template>

            
            <template v-slot:body>
                <div v-if="!agenteBuscado" class="flex flex-col gap-5">
                    <p>Para añadir un agente, debe buscarlo a traves de su identificador. En el caso de que exista el agente asociado a dicho
                    identificador, se mostrará su información general y podrá añadirlo mediante <span class="font-semibold text-primary">Añadir</span>.
                    </p>
                    <Search @searched="(agente) => {setAgenteBuscado(agente)}" v-bind:function="buscarAgente" v-bind:placeholder="'Buscar Agente'"></Search>
                </div>

                <AgenteCard v-else v-bind:agente-buscado="agenteBuscado" class="w-full"></AgenteCard>
                
                
            </template>

            <template v-slot:actions>
                <button v-if="agenteBuscado" @click="agenteBuscado = null" type="button" class="btn">Cancelar</button>
                <button @click="enviarSolicitud" type="button" class="btn btn-primary">Añadir</button>
            </template>
        </Card>

        <Card @click="disolverEquipo" class="col-start-2 row-start-3">
            <template v-slot:title>
                 <div class="flex flex-row justify-center w-full">
                    <p class="text-primary">Disolver Equipo</p>
                </div>
            </template>

            <template v-slot:body>
                <p>Una vez eliminada, toda la información asociada a esta operación se perderá definitivamente.
                <span class="font-semibold text-primary">Esta acción no se puede deshacer.</span></p>
        
            </template>

        </Card>
    </div>

     <DisolverEquipo v-model="disolverEquipoModal" :seleccionado="props.equipoId"></DisolverEquipo>
    
   </LayoutSection>

   
</template>