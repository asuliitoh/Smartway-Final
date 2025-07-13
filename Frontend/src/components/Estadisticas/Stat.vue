<!--Stat es utilizado para mostrar una estádistica concreta del agente actual o de la plataforma-->
<script setup>

    /**
     * Número y nombre de la estadística.
     */
    const props = defineProps({
        number: Number,
        title: String,
    })

</script>

<template>
    <div class="transition duration-300 shadow-xl card bg-base-100 hover:bg-primary/20">
        <div class="items-center justify-center card-body">
            <h2 class="card-title"> {{ props.number }} </h2>
            <p class="text-xs">{{ props.title }}</p>
        </div>
    </div>
</template>