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

    <div class="grid grid-cols-1 md:grid-cols-[auto_auto] place-items-center gap-2 md:gap-5 lg:gap-10">
        <Stat v-bind:number="equipoStore.numeroEquiposPropios" v-bind:title="'Equipos propios'"></Stat>
        <Stat v-bind:number="equipoStore.numeroEquiposAjenos" v-bind:title="'Equipos ajenos'"></Stat>
    </div>
</template>