<!--TablaEquipos es utilizad para representar una serie de equipos en una tabla-->
<script setup>

   import EntradaEquipo from './EntradaEquipo.vue';
   /**
    *  Equipos a representar.
    */
   const props = defineProps(['equipos'])

   /**
    * Model que define si el Modal es visible o no.
    */
   const selected = defineModel({default:null})

   /**
    * Función que devuelve true si se ha seleccionado un equipo concreto (falso en caso contrario).
    * @param id Identificador del equipo.
    */
   function isSeleccionado(id){
        if ((selected.value != null) && selected.value== id) return true;
        else false;
   }

   /**
    * Función que asigna un equipo como equipo seleccionado.
    * @param id 
    */
   function setSelected(id){
        selected.value = id;
   }

</script>

<template>
    <div class="overflow-auto">
    <table class="table table-xs sm:table-sm md:table-md bg-primary/20 table-pin-rows">
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
    </div>

</template>