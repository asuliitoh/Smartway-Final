<script setup>

    import ModalAviso from './ModalAviso.vue';
    import { router } from '@/router/router';
    import { useOperacionesStore } from '@/stores/operaciones-store';
    
    const operacionesStore = useOperacionesStore();
    const visible = defineModel(false)
    const props = defineProps(["seleccionado"])
    
    async function eliminarOperacion(){
        await operacionesStore.deleteOperacion(props.seleccionado);
        visible.value=false;
        router.replace({name: 'operaciones'})
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