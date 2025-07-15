<!--EstadisticasOperaciones es utilizado para mostrar las estadísticas del agente actual sobre sus operaciones-->
<script setup>
    
    import Stat from './Stat.vue';
    import { useOperacionesStore } from '@/stores/operaciones-store';
    
    /**
     * Store de Operaciones, utilizado para recuperar el número de operaciones del agente actual según el estado de la operación.
     */
    const operacionesStore = useOperacionesStore();

</script>

<template>

     <div class="grid grid-cols-1 gap-5 sm:grid-cols-3 xl:grid-cols-3 place-items-center xl:gap-10">
       <Stat v-bind:number="operacionesStore.numeroOperacionesPlanificadas" v-bind:title="'Operaciones Planificadas'"></Stat>
       <Stat v-bind:number="operacionesStore.numeroOperacionesActivas" v-bind:title="'Operaciones Activas'"></Stat>
       <Stat v-bind:number="operacionesStore.numeroOperacionesCompletadas" v-bind:title="'Operaciones Completadas'"></Stat>
    </div>

</template>