<script setup>

      
const props = defineProps({
    id: Number,
    nombre: String,
    estado: String,
    fechaInicio: Date,
    fechaFin: Date  
})

</script>

<template>

      <tr class="transition duration-300 hover:bg-primary/10">
            <th>{{ props.id }}</th>
            <td>{{ props.nombre }}</td>
            <td>{{ props.estado }}</td>
            <td>{{ props.fechaInicio }}</td>
            <td>{{ props.fechaFin }}</td>
        </tr>

</template>