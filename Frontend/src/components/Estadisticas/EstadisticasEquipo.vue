<script setup>


    import Stat from './Stat.vue';
    const props = defineProps({
            hover: Boolean
        })

    import { useEquiposStore } from '@/stores/equipos-store';
    const equipoStore = useEquiposStore();
</script>

<template>

    <div class="grid grid-cols-2 gap-5 pt-5">
        <Stat v-bind:number="equipoStore.numeroEquiposPropios" v-bind:title="'Equipos propios'" v-bind:hover="props.hover" class="col-start-1"></Stat>
        <Stat v-bind:number="equipoStore.numeroEquiposAjenos" v-bind:title="'Equipos ajenos'" v-bind:hover="props.hover" class="col-start-2"></Stat>
    </div>

</template>