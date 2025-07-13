<!--AgenteCard es utilizado para mostrar la información de un agente, dado -->
<script setup>

    /**
     * Agente actual con la información a representar.
     */
    const props = defineProps({
    agenteBuscado: {
        type: Object,
        required: true,
    },
    })
</script>

<template>
  
  <div class="p-6 mx-auto border shadow-lg rounded-box border-primary/20 bg-primary/10">    
    
    <div class="flex flex-col mb-4">
      <h2 class="text-lg font-medium text-primary">{{ agenteBuscado.nombre }} {{ agenteBuscado.apellidos }}</h2>
      <p class="self-start text-sm text-primary">ID#{{ agenteBuscado.id }}</p>
    </div>

    <div class="text-sm">
      <div class="flex justify-between">
        <p class="text-primary">Rango</p>
        <p class="font-medium">{{ agenteBuscado.rango }}</p>
      </div>

      <div class="flex justify-between">
        <p class="text-primary">Activo</p>
        <p class="font-medium">{{ agenteBuscado.activo ? 'Sí' : 'No' }}</p>
      </div>

    </div>
  </div>
</template>

