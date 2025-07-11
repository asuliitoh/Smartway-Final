<script setup>
    
    import { useEquiposStore } from '@/stores/equipos-store';

    import ModalAviso from './ModalAviso.vue';
    const visible = defineModel(false)
    const equipoStore = useEquiposStore()
    const props = defineProps(["seleccionado"])
    import { router } from '@/router/router';

    async function disolverEquipo(){
        await equipoStore.deleteEquipo(props.seleccionado);
        visible.value=false;
        router.replace({name: 'equipos'})
    }


</script>

<template>
     <ModalAviso v-if="visible">
        <template v-slot:title>
            <p>Disolver Equipo</p>
        </template>

        <template v-slot:body>
            <p>¿Estas seguro de esta acción? Ten en cuenta que aquellas operaciones que tenga asignadas quedarán sin equipo.</p>
        </template>

        <template v-slot:actions>
            <button @click="visible = false" type="button" class="btn ">Cancelar</button>
            <button @click="disolverEquipo" type="button" class="btn btn-primary">Aceptar</button>
        </template>

    </ModalAviso>
</template>