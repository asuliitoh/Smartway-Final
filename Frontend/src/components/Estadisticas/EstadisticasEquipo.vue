<!--EstadísticasEquipo es utilizado para mostrar estadísticas del agente actual los equipos.-->
<script setup>

    import Stat from './Stat.vue';
    import { useEquiposStore } from '@/stores/equipos-store';

    /**
     * Store de Equipos, utilizado para obtener el número de equipos propios y ajenos.
     */
    const equipoStore = useEquiposStore();

</script>

<template>

    <div class="grid grid-cols-2 gap-5 pt-5">
        <Stat v-bind:number="equipoStore.numeroEquiposPropios" v-bind:title="'Equipos propios'" class="col-start-1"></Stat>
        <Stat v-bind:number="equipoStore.numeroEquiposAjenos" v-bind:title="'Equipos ajenos'" class="col-start-2"></Stat>
    </div>
</template>