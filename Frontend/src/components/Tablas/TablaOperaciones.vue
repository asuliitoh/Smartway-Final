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

    <table class="table table-pin-rows">
        <thead>
            <th>Id</th>
            <th>Nombre</th>
            <th>Estado</th>
            <th>Fecha Inicio</th>
            <th>Fecha Fin</th>
        </thead>
        <tbody>
            <template v-for="[id, value] in props.operaciones">
                <EntradaOperacion @click="setSelected(id)" :id="id" :nombre="value.nombre" :estado="value.estado" :fechaInicio="value.fechaInicio.substr(0,10)" :fechaFin="value.fechaFinal.substr(0,10)" :seleccionado="isSeleccionado(id)" ></EntradaOperacion>
            </template>

        </tbody>
    </table>

</template>