<!--TablaOperación utilizado para representar una serie de operación en una tabla-->
<script setup>

    import EntradaOperacion from './EntradaOperacion.vue';
    
    /**
     * Model que guarda la operación actual seleccionada.
     */
    const selected = defineModel({default:null}) 

    /**
     * Operaciones a representar.
     */
    const props = defineProps(['operaciones'])

    
    /**
     * Función que devuelve true si una operación concreta ha sido seleccionda (falso en caso contrario).
     * @param id Identificador de la operación.
     */
   function isSeleccionado(id){
        if ((selected.value != null) && selected.value== id) return true;
        else false;
   }

   /**
    * Función que asigna una operación como seleccionada.
    * @param id Identificador de la operación.
    */
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
                <EntradaOperacion @click="setSelected(id)" :id="id" :nombre="value.nombre" :estado="value.estado" :fechaInicio="value.fechaInicio" :fechaFin="value.fechaFinal" :seleccionado="isSeleccionado(id)" ></EntradaOperacion>
            </template>

        </tbody>
    </table>

</template>