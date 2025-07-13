<script setup>
    import LayoutSection from '@/layouts/LayoutSection.vue';
    import Card from '@/components/Cards/Card.vue';
    import { onBeforeMount, ref } from 'vue';
    import { useOperacionesStore } from '@/stores/operaciones-store';
    import { useEquiposStore } from '@/stores/equipos-store';
import EliminarOperacion from '@/components/Modals/EliminarOperacion.vue';
import AsignarEquipo from '@/components/Modals/AsignarEquipo.vue';

    const props = defineProps(["operacionId"])
    const operacion = ref(null);
    const operacionesStore = useOperacionesStore();
    const equipoStore = useEquiposStore();
    const modoEdicion = ref(false)
    const equipoOperacion = ref(null)

    const nombreCampo = ref(null);
    const estadoCampo = ref(null);
    const eliminarOperacionModal = ref(false);
    const asignarEquipoModal = ref(false);


    async function getInformacionOperacion(){
        operacion.value =  await operacionesStore.getOperacion(props.operacionId);
        estadoCampo.value = operacion.value.estado;
        if (operacion.value.equipoId) equipoOperacion.value = await equipoStore.getEquipo(operacion.value.equipoId);

    }

    function cambiarModoEdicion(){
        modoEdicion.value = true;
    }

    function cancelarActualizacion(){
        nombreCampo.value = '';
        estadoCampo.value = operacion.value.estado;    
        modoEdicion.value = false;
    }

    function eliminarOperacion(){
        eliminarOperacionModal.value = true;
    }

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
                <p class="pl-5 pt-5 text-xl text-primary">Información de la Operación</p>
            </template>

            <template v-slot:body>

                <div class="flex flex-col rounded-box shadow-lg border border-gray-200 p-5 gap-2">
                    <label class="label font-bold text-primary/60 text-xs">Identificador de la operación</label>
                    <p v-if="operacion" class="w-full font-semibold"> {{ operacion.id }} </p>
                </div>
                  
                <div class="flex flex-col rounded-box shadow-lg border border-gray-200 p-5 gap-2">
                    <label class="label font-bold text-primary/60 text-xs">Nombre de la operación</label>
                    <input v-if="operacion" v-model="nombreCampo" :disabled="!modoEdicion" type="text" class="w-full bg-transparent border-0 disabled:focus:outline-none placeholder:text-black placeholder:font-medium" :placeholder="operacion.nombre">
                </div>

                <div class="flex flex-col rounded-box shadow-lg border border-gray-200 p-5 gap-2">
                    <label class="label font-bold text-primary/60 text-xs">Estado de la operación</label>
                    <select v-if="operacion" :disabled="!modoEdicion" v-model="estadoCampo" class="w-full pt-2 pb-2 text-sm text-black font-semibold border rounded-sm bg-transparent border-gray-300">
                        <option value="Planificado">Planificado</option>
                        <option value="Activo">Activo</option>
                        <option value="Completado">Completado</option>
                    </select>
                </div>

                <div class="flex flex-col rounded-box shadow-lg border border-gray-200 p-5 gap-2">
                    <label class="label font-bold text-primary/60 text-xs">Equipo Asignado a la operación</label>                            
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
                <p>Pulse sobre esta sección para asignar esta operación a un equipo. <span class="text-primary font-semibold">Solo puedes asignarlo a un equipo propio.</span></p>
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