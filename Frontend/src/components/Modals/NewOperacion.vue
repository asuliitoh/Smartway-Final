<script setup>
    import Modal from './Modal.vue';
    import { useOperacionesStore } from '@/stores/operaciones-store';
    import { ref } from 'vue';
    
    //Objeto reactivo para mostrar u ocultar el modal
    const visible = defineModel(false)

    //Store utilizado para Operaciones
    const operacionesStore = useOperacionesStore();
    
    //Objetos reactivos utilizados para el formulario
    const nombre = ref(null)
    const estado = ref("Ninguno")
    const fechaInicio = ref(null)
    const fechaFinal = ref(null)

    function newOperacion(){
        if ((nombre.value != null) && (estado.value != null) && (fechaInicio.value != null) && (fechaFinal.value != null)){
        operacionesStore.newOperacion({nombre:nombre.value,
            estado:estado.value,
            fechainicio:fechaInicio.value,
            fechafinal:fechaFinal.value    
        })
        visible.value=false;
        }
    }

    function clear(){
        nombre.value = null;
        estado.value = "Ninguno";
        fechaInicio.value = null;
        fechaFinal.value = null;
        visible.value = false;
    }

</script>

<template>

    <Modal>
        <template v-slot:header>
            <p class="text-xl font-bold text-primary/80">Crear Nueva Operación</p>
            <p class="pb-3 text-sm text-gray-600">Configura los detalles de tu nueva operación</p>
        </template>

        <template v-slot:body>
            <div class="flex flex-col gap-4">

                <div class="flex flex-col gap-2">
                    <label class="text-xs label text-primary">Nombre de la operación</label>
                    <input type="text" v-model="nombre" class="w-full input bg-primary/10 border-primary/20" placeholder="Introduce el nombre de la operación">
                </div>

                <div class="flex flex-col gap-2">
                    <label class="text-xs label text-primary">Estado</label>
                    <select v-model="estado" class="w-full p-2 text-sm text-gray-500 border rounded-sm bg-primary/10 border-primary/20">
                        <option disabled value="Ninguno">Selecciona el estado</option>
                        <option value="Planificado">Planificado</option>
                        <option value="Activo">Activo</option>
                        <option value="Completado">Completado</option>
                    </select>
                </div>

                <div class="flex flex-col items-center justify-center gap-2 p-2 border border-primary/20 rounded-box bg-primary/10">
                    <label class="text-xs label text-primary">Periodo de operación</label>
                    <div class="flex flex-row items-center justify-center gap-x-2">
                        <div class="flex flex-col">
                            <label class="text-xs label text-primary">Fecha de inicio</label>
                            <input v-model="fechaInicio" type="date" class="w-full text-sm text-gray-500 input bg-primary/10 border-primary/20"/>
                        </div>
                        
                        <div class="flex flex-col">
                            <label class="text-xs label text-primary">Fecha final</label>
                            <input v-model="fechaFinal" type="date" class="w-full text-sm text-gray-500 input bg-primary/10 border-primary/20"/>
                        </div>
                    
                    </div>
                    
                </div>
            </div>            

        </template>

          <template v-slot:actions>
            <button @click="clear" type="button" class="btn">Cancelar</button>
            <button @click="newOperacion" type="button" class="btn btn-primary">Crear</button>
        </template>
        
    </Modal>

</template>