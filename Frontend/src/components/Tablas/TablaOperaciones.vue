<script setup>
    import EntradaOperacion from './EntradaOperacion.vue';
    const selected = defineModel({default:null}) 
    const props = defineProps(['operaciones'])

    
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
            <th class="font-semibold text-primary">Estado</th>
            <th class="font-semibold text-primary">Fecha Inicio</th>
            <th class="font-semibold text-primary">Fecha Fin</th>
        </thead>
        <tbody>
            <template v-for="[id, value] in props.operaciones">
                <EntradaOperacion @click="setSelected(id)" :id="id" :nombre="value.nombre" :estado="value.estado" :fechaInicio="value.fechaInicio.substr(0,10)" :fechaFin="value.fechaFinal.substr(0,10)" :seleccionado="isSeleccionado(id)" ></EntradaOperacion>
            </template>

        </tbody>
    </table>

</template>