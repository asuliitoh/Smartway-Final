<!--Equipo muestra los detalles de un equipo concreto, permite editar su información, añadir nuevos agentes y la disolución del equipo-->
<script setup>

    import LayoutSection from '@/layouts/LayoutSection.vue';
    import Card from '@/components/Cards/Card.vue';
    import Search from '@/components/Search.vue';
    import DisolverEquipo from '@/components/Modals/DisolverEquipo.vue';
    import {ref, onMounted} from 'vue';
    import { useAgenteStore } from '@/stores/agente-store';
    import { useEquiposStore } from '@/stores/equipos-store';
    import AgenteCard from '@/components/Cards/AgenteCard.vue';
    
    /**
     * Propiedades del componente. Router pasa equipoId mediante el path.
     */
    const props = defineProps(["equipoId"]);

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
    
    <div class="h-full w-full grid grid-rows-[auto_auto_auto_auto] grid-cols-1 lg:grid-cols-[70%_30%] lg:grid-rows-[auto_auto_auto] gap-5">
        <Card class="lg:col-start-1 lg:row-span-full">
            <template v-slot:title>
                <h2 class="w-full text-center h2-section-card lg:text-left">Información del Equipo</h2>
            </template>

            <template v-slot:body>
                <fieldset v-if="equipo" class="w-full min-w-0 p-2 border border-gray-300 shadow-lg h-min bg-primary/10 rounded-box">
                           
                        <label class="w-full text-xs text-left sm:text-sm text-primary">Identificador del equipo</label>
                        <input disabled type="text" class="w-full min-w-0 input disabled:bg-primary/20 disabled:border-primary/40" :placeholder = "equipo.id">

                        <label class="w-full text-xs text-left sm:text-sm text-primary">Nombre del equipo</label>
                        <input :disabled="!modoEdicion" v-model="nombreCampo" type="text" class="w-full min-w-0 input bg-primary/20 border-primary/40 disabled:bg-primary/20 disabled:border-primary/40" :placeholder="equipo.nombre">

                        <label class="w-full text-xs text-left sm:text-sm text-primary">Especialidad del equipo</label>
                        <input :disabled="!modoEdicion" v-model="especialidadCampo" type="text" class="w-full min-w-0 input bg-primary/20 border-primary/40 disabled:bg-primary/20 disabled:border-primary/40" :placeholder="equipo.especialidad">

                        <label class="w-full min-w-0 text-xs text-left sm:text-sm text-primary">Miembros del equipo</label>
                            <div class="overflow-auto">
                            <table class="table min-w-0 overflow-auto bg-primary/20 table-xs sm:table-sm md:table-md table-pin-rows">
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
                            </div>
                        <label class="w-full text-xs text-left sm:text-sm text-primary">Operaciones del equipo</label>            
                             <div class="overflow-auto">
                            <table class="table overflow-auto bg-primary/20 table-xs sm:table-sm md:table-md table-pin-rows">
                                    <thead>
                                        <th>Id</th>
                                        <td>Nombre</td>
                                    </thead>

                                <template v-for="operacion in equipo.operaciones">
                                    <tr class="hover:bg-primary/10">
                                        <th>{{ operacion.id }}</th>
                                        <td>{{ operacion.nombre }}</td>
                                    </tr>
                                </template>
                                </table>        
                                </div>
                    </fieldset>
            </template>

            <template v-slot:actions>
                <button @click="cancelarActualizacion" v-if="modoEdicion" type="button" class="btn">Cancelar</button>
                <button @click="actualizarEquipo" v-if="modoEdicion" type="button" class="btn btn-primary">Aplicar</button>
            </template>

        </Card>

        <Card @click="cambiarModoEdicion" class="lg:col-start-2 lg:row-start-1">
            <template v-slot:title>
                <h2 class="w-full text-center h2-section-card">Modificar Información</h2>
            </template>

            <template v-slot:body>
               <p>Pulse esta sección para habilitar el <span class="font-semibold text-primary">modo edición</span> de la información del equipo.</p>
            </template>

        </Card>

        <Card class="lg:col-start-2 lg:row-start-2">
            <template v-slot:title>
                 <h2 class="w-full text-center h2-section-card">Añadir Agente al Equipo</h2>
            </template>

            
            <template v-slot:body>
                <div v-if="!agenteBuscado" class="flex flex-col gap-5">
                    <p class="p-card">Para añadir un agente, debe buscarlo a traves de su identificador. En el caso de que exista el agente asociado a dicho
                    identificador, se mostrará su información general y podrá añadirlo mediante <span class="font-semibold text-primary">Añadir</span>.
                    </p>
                    <Search @searched="(agente) => {setAgenteBuscado(agente)}" v-bind:function="buscarAgente" v-bind:placeholder="'Buscar Agente'"></Search>
                </div>

                <AgenteCard v-else v-bind:agente-buscado="agenteBuscado" class="w-full"></AgenteCard>
                
                
            </template>

            <template v-slot:actions>
                <button v-if="agenteBuscado" @click="agenteBuscado = null" type="button" class="btn-section-card">Cancelar</button>
                <button @click="enviarSolicitud" type="button" class="btn-section-card btn-primary">Añadir</button>
            </template>
        </Card>

        <Card @click="disolverEquipo" class="lg:col-start-2 lg:row-start-3">
            <template v-slot:title>
                 <h2 class="w-full text-center h2-section-card">Disolver Equipo</h2>
            </template>

            <template v-slot:body>
                <p class="p-card">Una vez eliminada, toda la información asociada a este equipo se perderá definitivamente.
                <span class="font-semibold text-primary">Esta acción no se puede deshacer.</span></p>
        
            </template>

        </Card>
    </div>

     <DisolverEquipo v-model="disolverEquipoModal" :seleccionado="props.equipoId"></DisolverEquipo>
    
   </LayoutSection>

   
</template>