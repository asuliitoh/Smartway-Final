<script setup>
    import { ref } from 'vue';
    import Stat from './Stat.vue';
    import { useOperacionesStore } from '@/stores/operaciones-store';
    const props = defineProps({
        hover: Boolean
    })

    const operacionesStore = useOperacionesStore();

</script>

<template>

     <div class="grid grid-cols-3 gap-5">
       
       <Stat v-bind:number="operacionesStore.numeroOperacionesPlanificadas" v-bind:title="'Operaciones Planificadas'" v-bind:hover="props.hover" class="col-start-1"></Stat>
       <Stat v-bind:number="operacionesStore.numeroOperacionesActivas" v-bind:title="'Operaciones Activas'" v-bind:hover="props.hover" class="col-start-2"></Stat>
       <Stat v-bind:number="operacionesStore.numeroOperacionesCompletadas" v-bind:title="'Operaciones Completadas'" v-bind:hover="props.hover" class="col-start-3"></Stat>
    
    </div>

</template>