<!--Operación muestra los detalles de una operación, permite modificar su información, asignar un equipo y eliminar la propia operación-->
<script setup>
    import LayoutSection from '@/layouts/LayoutSection.vue';
    import Card from '@/components/Cards/Card.vue';
    import { onBeforeMount, ref } from 'vue';
    import { useOperacionesStore } from '@/stores/operaciones-store';
    import { useEquiposStore } from '@/stores/equipos-store';
    import EliminarOperacion from '@/components/Modals/EliminarOperacion.vue';
    import AsignarEquipo from '@/components/Modals/AsignarEquipo.vue';

    /**
     * Store de Operaciones, utilizado para recuperar y actualizar la información de la operación, asignarle un equipo y eliminar la operación.
     */
    const operacionesStore = useOperacionesStore();

    /**
     * Store de Equipos, utilizado para recuperar la información del equipo asignado a la operación.
     */
    const equipoStore = useEquiposStore();

    /**
     * Identificador de la operación a mostrar.
     */
    const props = defineProps(["operacionId"])

    /**
     * Objeto reactivo que almacena la operación concreta.
     */
    const operacion = ref(null);

    /**
     * Objeto reactivo que almacena el equipo asignado a la operación.
     */
    const equipoOperacion = ref(null)

    /**
     * Booleano reactivo que activa/desactiva el modo edición de la información de la operación.
     */
    const modoEdicion = ref(false)
    
    /**
     * Objeto reactivo que almacena el nombre de la operación introducido por el agente.
     */
    const nombreCampo = ref(null);

    /**
     * Objeto reactivo que almacena el estado de la operación introducido por el agente.
     */
    const estadoCampo = ref(null);

    /**
     * Booleano reactivo utilizado para mostrar/ocultar un modal para eliminar una operación.
     */
    const eliminarOperacionModal = ref(false);

    /**
     * Booleano reactivo utilizado para mostrar/ocultar un modal para asignar un equipo.
     */
    const asignarEquipoModal = ref(false);

    /**
     * Función utilizada para obtener la información de la operación concreta.
     */
    async function getInformacionOperacion(){
        operacion.value =  await operacionesStore.getOperacion(props.operacionId);
        estadoCampo.value = operacion.value.estado;
        if (operacion.value.equipoId) equipoOperacion.value = await equipoStore.getEquipo(operacion.value.equipoId);

    }

    /**
     * Función utilizada para activar el modo edición de la información de la operación.
     */
    function cambiarModoEdicion(){
        modoEdicion.value = true;
    }

    /**
     * Función utilizado para cancelar la actualización de la información de la operación.
     * Restaura los objetos reactivos utilizados y desactiva el modo de edición.
     */
    function cancelarActualizacion(){
        nombreCampo.value = '';
        estadoCampo.value = operacion.value.estado;    
        modoEdicion.value = false;
    }

    /**
     * Función utilizada para mostrar el Modal de eliminar operación.
     */
    function eliminarOperacion(){
        eliminarOperacionModal.value = true;
    }

    /**
     * Función utilizada para mostrar el Modal de asignar equipo.
     */
    function asignarEquipo(){
        asignarEquipoModal.value = true;
    }

    onBeforeMount(getInformacionOperacion)

</script>

<template>
   <LayoutSection>
    
    <div class="h-full w-full grid grid-cols-[70%_30%] grid-rows-[auto_auto_auto] gap-5">
        <Card class="col-start-1 row-span-full">
            <template v-slot:title>
                <p class="pt-5 pl-5 text-xl text-primary">Información de la Operación</p>
            </template>

            <template v-slot:body>

                <div class="flex flex-col gap-2 p-5 border border-gray-200 shadow-lg rounded-box">
                    <label class="text-xs font-bold label text-primary/60">Identificador de la operación</label>
                    <p v-if="operacion" class="w-full font-semibold"> {{ operacion.id }} </p>
                </div>
                  
                <div class="flex flex-col gap-2 p-5 border border-gray-200 shadow-lg rounded-box">
                    <label class="text-xs font-bold label text-primary/60">Nombre de la operación</label>
                    <input v-if="operacion" v-model="nombreCampo" :disabled="!modoEdicion" type="text" class="w-full bg-transparent border-0 disabled:focus:outline-none placeholder:text-black placeholder:font-medium" :placeholder="operacion.nombre">
                </div>

                <div class="flex flex-col gap-2 p-5 border border-gray-200 shadow-lg rounded-box">
                    <label class="text-xs font-bold label text-primary/60">Estado de la operación</label>
                    <select v-if="operacion" :disabled="!modoEdicion" v-model="estadoCampo" class="w-full pt-2 pb-2 text-sm font-semibold text-black bg-transparent border border-gray-300 rounded-sm">
                        <option value="Planificado">Planificado</option>
                        <option value="Activo">Activo</option>
                        <option value="Completado">Completado</option>
                    </select>
                </div>

                <div class="flex flex-col gap-2 p-5 border border-gray-200 shadow-lg rounded-box">
                    <label class="text-xs font-bold label text-primary/60">Equipo Asignado a la operación</label>                            
                    <table v-if="equipoOperacion"  class="table bg-primary/20 table-xs table-pin-rows">
                        <thead>
                            <th>Id</th>
                            <td>Nombre</td>
                            <td>Especialidad</td>  
                        </thead>

                        <tr class="hover:bg-primary/10">
                            <th>{{ equipoOperacion.id }}</th>
                            <td>{{ equipoOperacion.nombre }}</td>
                            <td>{{ equipoOperacion.especialidad }}</td>
                        </tr>

                    </table>        
                    <p v-else class="font-semibold text-error">Esta operación no tiene ningún equipo asignado.</p>
                </div>     
            </template>
            <template v-slot:actions>
                <button @click="cancelarActualizacion" v-if="modoEdicion" type="button" class="btn">Cancelar</button>
                <button @click="actualizarOperacion" v-if="modoEdicion" type="button" class="btn btn-primary">Aplicar</button>
            </template>
        </Card>

        <Card @click="asignarEquipo" class="col-start-2 row-start-1">
            <template v-slot:title>
                <div class="flex flex-row justify-center w-full">
                    <p class="text-primary">Asignar Equipo</p>
                </div>
            </template>
            
            <template v-slot:body>
                <p>Pulse sobre esta sección para asignar esta operación a un equipo. <span class="font-semibold text-primary">Solo puedes asignarlo a un equipo propio.</span></p>
            </template>

        </Card>

        <Card @click="cambiarModoEdicion" class="col-start-2 row-start-2">
            <template v-slot:title>
                <div class="flex flex-row justify-center w-full">
                    <p class="text-primary">Modificar Información</p>
                </div>
            </template>
          
            <template v-slot:body>
                   <p>Pulse esta sección para habilitar el <span class="font-semibold text-primary">modo edición</span> de la información del equipo.</p>
            </template>

        </Card>

        <Card @click="eliminarOperacion" class="col-start-2 row-start-3">
            <template v-slot:title>
                <div class="flex flex-row justify-center w-full">
                    <p class="text-primary">Eliminar Operación</p>
                </div>
            </template>
            
            <template v-slot:body>               
                <p>Una vez eliminada, toda la información asociada a esta operación se perderá definitivamente.
                <span class="font-semibold text-primary">Esta acción no se puede deshacer.</span></p>
            </template>

        </Card>
    </div>

    <EliminarOperacion v-model="eliminarOperacionModal" :seleccionado="props.operacionId"></EliminarOperacion>
    <AsignarEquipo v-model="asignarEquipoModal" :operacionId="props.operacionId"></AsignarEquipo>
   </LayoutSection>
</template>