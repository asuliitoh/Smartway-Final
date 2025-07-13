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

     <div class="grid grid-cols-3 gap-5">
       <Stat v-bind:number="operacionesStore.numeroOperacionesPlanificadas" v-bind:title="'Operaciones Planificadas'" class="col-start-1"></Stat>
       <Stat v-bind:number="operacionesStore.numeroOperacionesActivas" v-bind:title="'Operaciones Activas'" class="col-start-2"></Stat>
       <Stat v-bind:number="operacionesStore.numeroOperacionesCompletadas" v-bind:title="'Operaciones Completadas'" class="col-start-3"></Stat>
    </div>

</template>