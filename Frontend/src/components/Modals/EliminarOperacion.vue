<!--EliminarOperación es un Modal permite al agente actual eliminar una operación en concreto.-->
<script setup>

    import ModalAviso from './ModalAviso.vue';
    import { router } from '@/router/router';
    import { useOperacionesStore } from '@/stores/operaciones-store';
    
    /**
     * Store de Operaciones, utilizado para eliminar la operación.
     */
    const operacionesStore = useOperacionesStore();

    /**
     * Modal que define si el Modal es visible o no.
     */
    const visible = defineModel(false);

    /**
     * Identificador de la operación seleccionada.
     */
    const props = defineProps(["seleccionado"]);
    
    /**
     * Función utilizada para eliminar la operación seleccionada.
     */
    async function eliminarOperacion(){
        try{
            await operacionesStore.deleteOperacion(props.seleccionado);
            visible.value=false;
            router.replace({name: 'operaciones'});
        }catch(error){
            console.error(error);
        }
    }

</script>


<template>
     <ModalAviso v-if="visible">
        <template v-slot:title>
            <p>Eliminar Operación</p>
        </template>

        <template v-slot:body>
            <p>¿Estas seguro de esta acción? Toda la información será eliminada de manera definitiva.</p>
        </template>

        <template v-slot:actions>
            <button @click="visible = false" type="button" class="btn ">Cancelar</button>
            <button @click="eliminarOperacion" type="button" class="btn btn-primary">Aceptar</button>
        </template>
    </ModalAviso>
</template>