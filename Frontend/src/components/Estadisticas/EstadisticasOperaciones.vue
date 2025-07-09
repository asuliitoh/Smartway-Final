<script setup>
    import { ref } from 'vue';
    import Stat from './Stat.vue';
    const props = defineProps({
        hover: Boolean
    })

</script>

<template>

     <div class="grid grid-cols-3 gap-5">
       
       <Stat v-bind:number="'0'" v-bind:title="'Operaciones Planificadas'" v-bind:hover="props.hover" class="col-start-1"></Stat>
       <Stat v-bind:number="'0'" v-bind:title="'Operaciones Activas'" v-bind:hover="props.hover" class="col-start-2"></Stat>
       <Stat v-bind:number="'0'" v-bind:title="'Operaciones Completadas'" v-bind:hover="props.hover" class="col-start-3"></Stat>
    
    </div>

</template>