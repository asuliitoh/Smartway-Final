<script setup>
   import EntradaEquipo from './EntradaEquipo.vue';
   import { ref } from 'vue';
   const props = defineProps(['equipos'])
   const selected = defineModel({default:null})

   function isSeleccionado(id){
        if ((selected.value != null) && selected.value== id) return true;
        else false;
   }

   function setSelected(id){
        selected.value = id;
   }

</script>

<template>
   
    <table class="table bg-primary/20 table-pin-rows">
        <thead>
            <th class="font-bold text-primary">Id</th>
            <th class="font-semibold text-primary">Nombre</th>
            <th class="font-semibold text-primary">Especialidad</th>     
        </thead>
        <tbody>
            <template v-for="[id, value] in props.equipos">
                <EntradaEquipo @click="setSelected(id)" :id="id" :nombre="value.nombre" :especialidad="value.especialidad" :seleccionado="isSeleccionado(id)" ></EntradaEquipo>
            </template>
        </tbody>
    </table>

</template>