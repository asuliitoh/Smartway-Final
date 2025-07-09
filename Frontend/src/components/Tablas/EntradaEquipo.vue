<script setup>

const props = defineProps({
    id: Number,
    nombre: String,
    especialidad: String,
    seleccionado: Boolean,  
})

</script>

<template>

    <tr class="transition duration-300" :class=" {'bg-primary/30': seleccionado, 'hover:bg-primary/10': !seleccionado}">
        <th>{{ props.id }}</th>
        <td>{{ props.nombre }}</td>
        <td>{{ props.especialidad }}</td>
    </tr>

</template>