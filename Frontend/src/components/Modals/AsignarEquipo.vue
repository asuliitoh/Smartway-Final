<script setup>
    
    import { onBeforeMount } from 'vue';
    import TablaEquipos from '../Tablas/TablaEquipos.vue';
    import Modal from './Modal.vue';
    import { useEquiposStore } from '@/stores/equipos-store';
    import { ref } from 'vue';
    import { useOperacionesStore } from '@/stores/operaciones-store';
    
    const props = defineProps(["operacionId"])
    const visible = defineModel(false);
    const equiposStore = useEquiposStore();
    const operacionesStore = useOperacionesStore();
    const equipoSeleccionado = ref(null);
    function getEquipos(){
        equiposStore.getAllEquipos();
    }

    function clear(){
        equipoSeleccionado.value = null;
        visible.value = false;
    }

    function asignarEquipo(){

        operacionesStore.asignarEquipo(props.operacionId, equipoSeleccionado.value)
    }

    onBeforeMount(getEquipos)

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