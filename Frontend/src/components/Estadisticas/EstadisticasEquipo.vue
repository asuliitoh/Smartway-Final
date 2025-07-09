<script setup>
import { ref } from 'vue';
import Stat from './Stat.vue';
 const props = defineProps({
        hover: Boolean
    })
</script>

<template>

    <div class="grid grid-cols-2 gap-5 pt-5">
        <Stat v-bind:number="'0'" v-bind:title="'Equipos propios'" v-bind:hover="props.hover" class="col-start-1"></Stat>
        <Stat v-bind:number="'0'" v-bind:title="'Equipos ajenos'" v-bind:hover="props.hover" class="col-start-2"></Stat>
    </div>

</template>