<script setup>

      
const props = defineProps({
    id: Number,
    nombre: String,
    estado: String,
    fechaInicio: String,
    fechaFin: String,
    seleccionado: Boolean
})

</script>

<template>

      <tr class="transition duration-300 hover:bg-primary/10" :class="{'bg-primary/30': seleccionado, 'hover:bg-primary/10': !seleccionado}">
            <th>{{ props.id }}</th>
            <td>{{ props.nombre }}</td>
            <td>{{ props.estado }}</td>
            <td>{{ props.fechaInicio }}</td>
            <td>{{ props.fechaFin }}</td>
        </tr>

</template>