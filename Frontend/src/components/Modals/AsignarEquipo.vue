<!--AsignarEquipo es un Modal que permite al agente actual la asignación de un equipo a una operación determinada.-->
<script setup>
    
    import TablaEquipos from '../Tablas/TablaEquipos.vue';
    import Modal from './Modal.vue';
    import { useEquiposStore } from '@/stores/equipos-store';
    import { ref } from 'vue';
    import { useOperacionesStore } from '@/stores/operaciones-store';
    
    /**
     * Identificador de la operación al cual asignar equipo.
     */
    const props = defineProps(["operacionId"])

    /**
     * Model que define si el Modal es visible o no.
     */
    const visible = defineModel(false);

    /**
     * Store de Equipos, utilizado para recuperar los equipos propios del agente actual.
     */
    const equiposStore = useEquiposStore();
    
    /**
     * Store de Operaciones, utilizado para asignar el equipo a la operación.
     */
    const operacionesStore = useOperacionesStore();
    
    /**
     * Objeto reactivo que almacena el identificador del equipo seleccionado.
     */
    const equipoSeleccionado = ref(null);

    /**
     * Función llamada al pulsar el botón Cancelar. Se restauran los valores de los
     * objetos reactivos utilizados y se oculta el Modal.
     */
    function clear(){
        equipoSeleccionado.value = null;
        visible.value = false;
    }

    /**
     * Función llamada al pulsar el botón Aceptar. Mediante el store de operaciones,
     * se procede a asignar el equipo seleccionado a la operación.
     */
    function asignarEquipo(){
        operacionesStore.asignarEquipo(props.operacionId, equipoSeleccionado.value)
    }

</script>

<template>
    <Modal v-if="visible">
        <template v-slot:header>
            <p class="text-xl font-bold text-primary/80">Asignar Equipo</p>
            <p class="pb-3 text-sm text-gray-600">Solo puedes asignar una operación a un equipo que <span class="font-semibold text-primary">tú</span> hayas creado.</p>
        </template>

        <template v-slot:body>            
                <TablaEquipos v-model="equipoSeleccionado" v-bind:equipos="equiposStore.equiposPropios"></TablaEquipos>
        </template>

          <template v-slot:actions>
            <button @click="clear" type="button" class="btn">Cancelar</button>
            <button v-if="equipoSeleccionado" @click="asignarEquipo" type="button" class="btn btn-primary">Asignar</button>
        </template>
    </Modal>
</template>